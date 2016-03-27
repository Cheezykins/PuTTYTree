using System;
using System.Windows.Forms;

namespace PuTTYTree
{
    public partial class CreateDirectory : Form
    {
        public string DirectoryName;

        public CreateDirectory()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Directory name must not be empty", "Error");
                DialogResult = DialogResult.None;
            }
            else
            {
                DirectoryName = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}