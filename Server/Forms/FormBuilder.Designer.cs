namespace Server.Forms
{
    partial class FormBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuilder));
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.chkBsod = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemoveIP = new System.Windows.Forms.Button();
            this.btnAddIP = new System.Windows.Forms.Button();
            this.textIP = new System.Windows.Forms.TextBox();
            this.listBoxIP = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemovePort = new System.Windows.Forms.Button();
            this.btnAddPort = new System.Windows.Forms.Button();
            this.chkPaste_bin = new System.Windows.Forms.CheckBox();
            this.listBoxPort = new System.Windows.Forms.ListBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.txtMutex = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtPaste_bin = new System.Windows.Forms.TextBox();
            this.chkAnti = new System.Windows.Forms.CheckBox();
            this.chkAntiProcess = new System.Windows.Forms.CheckBox();
            this.btnShellcode = new System.Windows.Forms.Button();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.chkIcon = new System.Windows.Forms.CheckBox();
            this.btnIcon = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.textFilename = new System.Windows.Forms.TextBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.txtFileVersion = new System.Windows.Forms.TextBox();
            this.txtOriginalFilename = new System.Windows.Forms.TextBox();
            this.txtProductVersion = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxFolder = new System.Windows.Forms.ComboBox();
            this.txtTrademarks = new System.Windows.Forms.TextBox();
            this.btnClone = new System.Windows.Forms.Button();
            this.btnAssembly = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(194, 6);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 13);
            this.label17.TabIndex = 109;
            this.label17.Text = "Group";
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(345, 185);
            this.numDelay.Margin = new System.Windows.Forms.Padding(2);
            this.numDelay.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(56, 20);
            this.numDelay.TabIndex = 108;
            this.numDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(194, 187);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 107;
            this.label16.Text = "Sleep (s)";
            // 
            // chkBsod
            // 
            this.chkBsod.AutoSize = true;
            this.chkBsod.Location = new System.Drawing.Point(329, 29);
            this.chkBsod.Margin = new System.Windows.Forms.Padding(2);
            this.chkBsod.Name = "chkBsod";
            this.chkBsod.Size = new System.Drawing.Size(56, 17);
            this.chkBsod.TabIndex = 105;
            this.chkBsod.Text = "BSOD";
            this.chkBsod.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 103;
            this.label5.Text = "Mutex";
            // 
            // btnRemoveIP
            // 
            this.btnRemoveIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveIP.Location = new System.Drawing.Point(127, 129);
            this.btnRemoveIP.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveIP.Name = "btnRemoveIP";
            this.btnRemoveIP.Size = new System.Drawing.Size(29, 24);
            this.btnRemoveIP.TabIndex = 72;
            this.btnRemoveIP.Text = "-";
            this.btnRemoveIP.UseVisualStyleBackColor = true;
            this.btnRemoveIP.Click += new System.EventHandler(this.BtnRemoveIP_Click);
            // 
            // btnAddIP
            // 
            this.btnAddIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIP.Location = new System.Drawing.Point(48, 129);
            this.btnAddIP.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(29, 24);
            this.btnAddIP.TabIndex = 71;
            this.btnAddIP.Text = "+";
            this.btnAddIP.UseVisualStyleBackColor = true;
            this.btnAddIP.Click += new System.EventHandler(this.BtnAddIP_Click);
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(48, 12);
            this.textIP.Margin = new System.Windows.Forms.Padding(2);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(109, 20);
            this.textIP.TabIndex = 69;
            // 
            // listBoxIP
            // 
            this.listBoxIP.FormattingEnabled = true;
            this.listBoxIP.Location = new System.Drawing.Point(48, 34);
            this.listBoxIP.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxIP.Name = "listBoxIP";
            this.listBoxIP.Size = new System.Drawing.Size(109, 82);
            this.listBoxIP.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Port";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(48, 183);
            this.textPort.Margin = new System.Windows.Forms.Padding(2);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(109, 20);
            this.textPort.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "IP";
            // 
            // btnRemovePort
            // 
            this.btnRemovePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemovePort.Location = new System.Drawing.Point(127, 302);
            this.btnRemovePort.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemovePort.Name = "btnRemovePort";
            this.btnRemovePort.Size = new System.Drawing.Size(29, 26);
            this.btnRemovePort.TabIndex = 67;
            this.btnRemovePort.Text = "-";
            this.btnRemovePort.UseVisualStyleBackColor = true;
            this.btnRemovePort.Click += new System.EventHandler(this.BtnRemovePort_Click);
            // 
            // btnAddPort
            // 
            this.btnAddPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPort.Location = new System.Drawing.Point(48, 302);
            this.btnAddPort.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPort.Name = "btnAddPort";
            this.btnAddPort.Size = new System.Drawing.Size(29, 24);
            this.btnAddPort.TabIndex = 66;
            this.btnAddPort.Text = "+";
            this.btnAddPort.UseVisualStyleBackColor = true;
            this.btnAddPort.Click += new System.EventHandler(this.BtnAddPort_Click);
            // 
            // chkPaste_bin
            // 
            this.chkPaste_bin.AutoSize = true;
            this.chkPaste_bin.Location = new System.Drawing.Point(192, 228);
            this.chkPaste_bin.Margin = new System.Windows.Forms.Padding(2);
            this.chkPaste_bin.Name = "chkPaste_bin";
            this.chkPaste_bin.Size = new System.Drawing.Size(67, 17);
            this.chkPaste_bin.TabIndex = 64;
            this.chkPaste_bin.Text = "Pastebin";
            this.chkPaste_bin.UseVisualStyleBackColor = true;
            this.chkPaste_bin.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // listBoxPort
            // 
            this.listBoxPort.FormattingEnabled = true;
            this.listBoxPort.Location = new System.Drawing.Point(48, 204);
            this.listBoxPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.listBoxPort.Name = "listBoxPort";
            this.listBoxPort.Size = new System.Drawing.Size(109, 82);
            this.listBoxPort.TabIndex = 65;
            // 
            // txtGroup
            // 
            this.txtGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "Group", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtGroup.Location = new System.Drawing.Point(196, 27);
            this.txtGroup.Margin = new System.Windows.Forms.Padding(2);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(110, 20);
            this.txtGroup.TabIndex = 110;
            this.txtGroup.Text = global::Server.Properties.Settings.Default.Group;
            // 
            // txtMutex
            // 
            this.txtMutex.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "Mutex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMutex.Location = new System.Drawing.Point(196, 84);
            this.txtMutex.Margin = new System.Windows.Forms.Padding(2);
            this.txtMutex.Name = "txtMutex";
            this.txtMutex.Size = new System.Drawing.Size(205, 20);
            this.txtMutex.TabIndex = 104;
            this.txtMutex.Text = global::Server.Properties.Settings.Default.Mutex;
            // 
            // txtProduct
            // 
            this.txtProduct.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "ProductName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(908, 31);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(2);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(10, 20);
            this.txtProduct.TabIndex = 74;
            this.txtProduct.Text = global::Server.Properties.Settings.Default.ProductName;
            this.txtProduct.Visible = false;
            // 
            // txtPaste_bin
            // 
            this.txtPaste_bin.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "Paste_bin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPaste_bin.Enabled = false;
            this.txtPaste_bin.Location = new System.Drawing.Point(192, 266);
            this.txtPaste_bin.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaste_bin.Name = "txtPaste_bin";
            this.txtPaste_bin.Size = new System.Drawing.Size(140, 20);
            this.txtPaste_bin.TabIndex = 63;
            this.txtPaste_bin.Text = global::Server.Properties.Settings.Default.Paste_bin;
            // 
            // chkAnti
            // 
            this.chkAnti.AutoSize = true;
            this.chkAnti.Location = new System.Drawing.Point(196, 135);
            this.chkAnti.Name = "chkAnti";
            this.chkAnti.Size = new System.Drawing.Size(63, 17);
            this.chkAnti.TabIndex = 111;
            this.chkAnti.Text = "Anti-VM";
            this.chkAnti.UseVisualStyleBackColor = true;
            // 
            // chkAntiProcess
            // 
            this.chkAntiProcess.AutoSize = true;
            this.chkAntiProcess.Location = new System.Drawing.Point(293, 136);
            this.chkAntiProcess.Name = "chkAntiProcess";
            this.chkAntiProcess.Size = new System.Drawing.Size(93, 17);
            this.chkAntiProcess.TabIndex = 112;
            this.chkAntiProcess.Text = "Block taskmgr";
            this.chkAntiProcess.UseVisualStyleBackColor = true;
            // 
            // btnShellcode
            // 
            this.btnShellcode.Location = new System.Drawing.Point(185, 302);
            this.btnShellcode.Name = "btnShellcode";
            this.btnShellcode.Size = new System.Drawing.Size(234, 49);
            this.btnShellcode.TabIndex = 113;
            this.btnShellcode.Text = "Build!";
            this.btnShellcode.UseVisualStyleBackColor = true;
            this.btnShellcode.Click += new System.EventHandler(this.btnShellcode_Click);
            // 
            // txtCopyright
            // 
            this.txtCopyright.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtCopyright", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCopyright.Enabled = false;
            this.txtCopyright.Location = new System.Drawing.Point(908, 123);
            this.txtCopyright.Margin = new System.Windows.Forms.Padding(2);
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.Size = new System.Drawing.Size(10, 20);
            this.txtCopyright.TabIndex = 84;
            this.txtCopyright.Text = global::Server.Properties.Settings.Default.txtCopyright;
            this.txtCopyright.Visible = false;
            // 
            // chkIcon
            // 
            this.chkIcon.AutoSize = true;
            this.chkIcon.Location = new System.Drawing.Point(898, 34);
            this.chkIcon.Margin = new System.Windows.Forms.Padding(2);
            this.chkIcon.Name = "chkIcon";
            this.chkIcon.Size = new System.Drawing.Size(15, 14);
            this.chkIcon.TabIndex = 94;
            this.chkIcon.UseVisualStyleBackColor = true;
            this.chkIcon.Visible = false;
            this.chkIcon.CheckedChanged += new System.EventHandler(this.ChkIcon_CheckedChanged);
            // 
            // btnIcon
            // 
            this.btnIcon.Enabled = false;
            this.btnIcon.Location = new System.Drawing.Point(898, 51);
            this.btnIcon.Margin = new System.Windows.Forms.Padding(2);
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(10, 41);
            this.btnIcon.TabIndex = 92;
            this.btnIcon.Text = "Choose icon";
            this.btnIcon.UseVisualStyleBackColor = true;
            this.btnIcon.Visible = false;
            this.btnIcon.Click += new System.EventHandler(this.BtnIcon_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(908, 69);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(10, 20);
            this.txtDescription.TabIndex = 76;
            this.txtDescription.Text = global::Server.Properties.Settings.Default.txtDescription;
            this.txtDescription.Visible = false;
            // 
            // txtCompany
            // 
            this.txtCompany.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCompany.Enabled = false;
            this.txtCompany.Location = new System.Drawing.Point(908, 96);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(10, 20);
            this.txtCompany.TabIndex = 83;
            this.txtCompany.Text = global::Server.Properties.Settings.Default.txtCompany;
            this.txtCompany.Visible = false;
            // 
            // txtIcon
            // 
            this.txtIcon.Enabled = false;
            this.txtIcon.Location = new System.Drawing.Point(894, 94);
            this.txtIcon.Margin = new System.Windows.Forms.Padding(2);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(10, 20);
            this.txtIcon.TabIndex = 93;
            this.txtIcon.Visible = false;
            // 
            // textFilename
            // 
            this.textFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "Filename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textFilename.Enabled = false;
            this.textFilename.Location = new System.Drawing.Point(892, 103);
            this.textFilename.Margin = new System.Windows.Forms.Padding(2);
            this.textFilename.Name = "textFilename";
            this.textFilename.Size = new System.Drawing.Size(10, 20);
            this.textFilename.TabIndex = 99;
            this.textFilename.Text = global::Server.Properties.Settings.Default.Filename;
            this.textFilename.Visible = false;
            // 
            // picIcon
            // 
            this.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIcon.ErrorImage = null;
            this.picIcon.InitialImage = null;
            this.picIcon.Location = new System.Drawing.Point(908, 48);
            this.picIcon.Margin = new System.Windows.Forms.Padding(2);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(10, 10);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 91;
            this.picIcon.TabStop = false;
            this.picIcon.Visible = false;
            // 
            // txtFileVersion
            // 
            this.txtFileVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtFileVersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtFileVersion.Enabled = false;
            this.txtFileVersion.Location = new System.Drawing.Point(892, 229);
            this.txtFileVersion.Margin = new System.Windows.Forms.Padding(2);
            this.txtFileVersion.Name = "txtFileVersion";
            this.txtFileVersion.Size = new System.Drawing.Size(10, 20);
            this.txtFileVersion.TabIndex = 88;
            this.txtFileVersion.Text = global::Server.Properties.Settings.Default.txtFileVersion;
            this.txtFileVersion.Visible = false;
            // 
            // txtOriginalFilename
            // 
            this.txtOriginalFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtOriginalFilename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtOriginalFilename.Enabled = false;
            this.txtOriginalFilename.Location = new System.Drawing.Point(908, 177);
            this.txtOriginalFilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtOriginalFilename.Name = "txtOriginalFilename";
            this.txtOriginalFilename.Size = new System.Drawing.Size(10, 20);
            this.txtOriginalFilename.TabIndex = 86;
            this.txtOriginalFilename.Text = global::Server.Properties.Settings.Default.txtOriginalFilename;
            this.txtOriginalFilename.Visible = false;
            // 
            // txtProductVersion
            // 
            this.txtProductVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtProductVersion", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtProductVersion.Enabled = false;
            this.txtProductVersion.Location = new System.Drawing.Point(908, 205);
            this.txtProductVersion.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductVersion.Name = "txtProductVersion";
            this.txtProductVersion.Size = new System.Drawing.Size(10, 20);
            this.txtProductVersion.TabIndex = 87;
            this.txtProductVersion.Text = global::Server.Properties.Settings.Default.txtProductVersion;
            this.txtProductVersion.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(865, 287);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 100;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBoxFolder
            // 
            this.comboBoxFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolder.Enabled = false;
            this.comboBoxFolder.FormattingEnabled = true;
            this.comboBoxFolder.Items.AddRange(new object[] {
            "%AppData%",
            "%Temp%"});
            this.comboBoxFolder.Location = new System.Drawing.Point(908, 335);
            this.comboBoxFolder.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxFolder.Name = "comboBoxFolder";
            this.comboBoxFolder.Size = new System.Drawing.Size(10, 21);
            this.comboBoxFolder.TabIndex = 101;
            this.comboBoxFolder.Visible = false;
            // 
            // txtTrademarks
            // 
            this.txtTrademarks.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Server.Properties.Settings.Default, "txtTrademarks", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTrademarks.Enabled = false;
            this.txtTrademarks.Location = new System.Drawing.Point(908, 150);
            this.txtTrademarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtTrademarks.Name = "txtTrademarks";
            this.txtTrademarks.Size = new System.Drawing.Size(10, 20);
            this.txtTrademarks.TabIndex = 85;
            this.txtTrademarks.Text = global::Server.Properties.Settings.Default.txtTrademarks;
            this.txtTrademarks.Visible = false;
            // 
            // btnClone
            // 
            this.btnClone.Enabled = false;
            this.btnClone.Location = new System.Drawing.Point(898, 4);
            this.btnClone.Margin = new System.Windows.Forms.Padding(2);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(10, 25);
            this.btnClone.TabIndex = 90;
            this.btnClone.Text = "Clone";
            this.btnClone.UseVisualStyleBackColor = true;
            this.btnClone.Visible = false;
            this.btnClone.Click += new System.EventHandler(this.BtnClone_Click);
            // 
            // btnAssembly
            // 
            this.btnAssembly.AutoSize = true;
            this.btnAssembly.Location = new System.Drawing.Point(879, 4);
            this.btnAssembly.Margin = new System.Windows.Forms.Padding(2);
            this.btnAssembly.Name = "btnAssembly";
            this.btnAssembly.Size = new System.Drawing.Size(15, 14);
            this.btnAssembly.TabIndex = 89;
            this.btnAssembly.UseVisualStyleBackColor = true;
            this.btnAssembly.Visible = false;
            this.btnAssembly.CheckedChanged += new System.EventHandler(this.BtnAssembly_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(818, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(475, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "Shhhh dont mind this, i was too lazy to do it properly. Be happy your getting thi" +
    "s old ass src anyways";
            // 
            // FormBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 364);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShellcode);
            this.Controls.Add(this.chkAntiProcess);
            this.Controls.Add(this.chkAnti);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chkBsod);
            this.Controls.Add(this.txtMutex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxFolder);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textFilename);
            this.Controls.Add(this.chkIcon);
            this.Controls.Add(this.txtIcon);
            this.Controls.Add(this.btnIcon);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.btnClone);
            this.Controls.Add(this.btnAssembly);
            this.Controls.Add(this.txtFileVersion);
            this.Controls.Add(this.txtProductVersion);
            this.Controls.Add(this.txtOriginalFilename);
            this.Controls.Add(this.txtTrademarks);
            this.Controls.Add(this.txtCopyright);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.btnRemoveIP);
            this.Controls.Add(this.btnAddIP);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.listBoxIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemovePort);
            this.Controls.Add(this.txtPaste_bin);
            this.Controls.Add(this.btnAddPort);
            this.Controls.Add(this.chkPaste_bin);
            this.Controls.Add(this.listBoxPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Builder";
            this.Load += new System.EventHandler(this.Builder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkBsod;
        private System.Windows.Forms.TextBox txtMutex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Button btnRemoveIP;
        private System.Windows.Forms.Button btnAddIP;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.ListBox listBoxIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemovePort;
        private System.Windows.Forms.TextBox txtPaste_bin;
        private System.Windows.Forms.Button btnAddPort;
        private System.Windows.Forms.CheckBox chkPaste_bin;
        private System.Windows.Forms.ListBox listBoxPort;
        private System.Windows.Forms.CheckBox chkAnti;
        private System.Windows.Forms.CheckBox chkAntiProcess;
        private System.Windows.Forms.Button btnShellcode;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.CheckBox chkIcon;
        private System.Windows.Forms.Button btnIcon;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.TextBox textFilename;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.TextBox txtFileVersion;
        private System.Windows.Forms.TextBox txtOriginalFilename;
        private System.Windows.Forms.TextBox txtProductVersion;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxFolder;
        private System.Windows.Forms.TextBox txtTrademarks;
        private System.Windows.Forms.Button btnClone;
        private System.Windows.Forms.CheckBox btnAssembly;
        private System.Windows.Forms.Label label3;
    }
}
