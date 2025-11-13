using Server.Helper;
using System;
using System.Windows.Forms;
using static Server.Helper.RegistrySeeker;
using DarkModeForms;

namespace Server.Forms
{
    public partial class FormRegValueEditBinary : Form
    {
        private DarkModeCS dm = null;
        private readonly RegValueData _value;

        private const string INVALID_BINARY_ERROR = "The binary value was invalid and could not be converted correctly.";
        public FormRegValueEditBinary(RegValueData value)
        {
            _value = value;

            InitializeComponent();
            dm = new DarkModeCS(this)
            {
                //[Optional] Choose your preferred color mode here:
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };

            this.valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
            hexEditor.HexTable = value.Data;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            byte[] bytes = hexEditor.HexTable;
            if (bytes != null)
            {
                try
                {
                    _value.Data = bytes;
                    this.DialogResult = DialogResult.OK;
                    this.Tag = _value;
                }
                catch
                {
                    ShowWarning(INVALID_BINARY_ERROR, "Warning");
                    this.DialogResult = DialogResult.None;
                }
            }

            this.Close();
        }

        private void ShowWarning(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
