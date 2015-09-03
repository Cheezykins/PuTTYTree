using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PuTTYTree
{
    public partial class MainTree : Form
    {
        private SessionCollection _sessions;

        public MainTree()
        {
            InitializeComponent();

            string regLocation = loadRegLocation();

            _sessions = SessionCollection.loadSessions(regLocation);

            render();
        }

        public void render()
        {
            puttyView.Nodes.Clear();
            puttyView.Nodes.Add(_sessions.render());
            puttyView.ExpandAll();
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CreateDirectory dirForm = new CreateDirectory())
            {
                dirForm.ShowDialog();
                if (dirForm.DialogResult == DialogResult.OK)
                {
                    TreeNode newNode = puttyView.SelectedNode.Nodes.Add(dirForm.DirectoryName);
                    newNode.ImageIndex = 2;
                    newNode.SelectedImageIndex = newNode.ImageIndex;
                    newNode.Name = dirForm.DirectoryName;
                    puttyView.SelectedNode.ExpandAll();

                    Properties.Settings.Default.Directories.Add(newNode.FullPath);
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void folderCtxMnu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (puttyView.SelectedNode.Name == "")
            {
                // in a putty session context
                cloneToolStripMenuItem.Enabled = true;
                createFolderToolStripMenuItem.Enabled = false;
            }
            else
            {
                // in a folder context.
                cloneToolStripMenuItem.Enabled = false;
                createFolderToolStripMenuItem.Enabled = true;
            }
        }

        private string loadRegLocation()
        {
            return Properties.Settings.Default.PuTTYRegPath;
        }

        private void OpenPutty(TreeNode treeNode)
        {

            string savedPuttyPath = Properties.Settings.Default.PuTTYPath;

            if (File.Exists(savedPuttyPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Properties.Settings.Default.PuTTYPath;
                startInfo.Arguments = string.Format("-load \"{0}\"", treeNode.Text);
                Process.Start(startInfo);
            }
            else
            {
                using (LocatePutty puttyForm = new LocatePutty())
                {
                    puttyForm.ShowDialog();
                    if (puttyForm.DialogResult == DialogResult.OK)
                    {
                        Properties.Settings.Default.PuTTYPath = puttyForm.puttyPath;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPutty(puttyView.SelectedNode);
        }

        private void puttyView_ItemDrag(object sender, ItemDragEventArgs e)
        {
        }

        private void puttyView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                puttyView.SelectedNode = e.Node;
            }
        }

        private void puttyView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenPutty(puttyView.SelectedNode);
        }
    }
}