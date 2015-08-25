using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System;

namespace PuTTYTree
{
    public partial class MainTree : Form
    {

        public MainTree()
        {
            InitializeComponent();

            //HKEY_CURRENT_USER\Software\SimonTatham\PuTTY\Sessions\

            using (RegistryKey sessions = RegistryManager.getKey(Registry.CurrentUser, @"Software\\SimonTatham\\PuTTY\\Sessions"))
            {
                if (sessions != null)
                {
                    foreach (string session in RegistryManager.getSubKeys(sessions))
                    {
                        
                    }

                    puttyView.ExpandAll();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}