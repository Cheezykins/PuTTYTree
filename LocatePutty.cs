using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace PuTTYTree
{
    public partial class LocatePutty : Form
    {
        public string puttyPath;

        public LocatePutty()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pathBox.Text = openFileDialog1.FileName;
            puttyPath = pathBox.Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(puttyPath))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You must enter a location for putty");
                DialogResult = DialogResult.None;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}