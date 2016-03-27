using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PuTTYTree.Properties;

namespace PuTTYTree
{
    public partial class MainTree : Form
    {
        private readonly SessionCollection _sessions;

        public MainTree()
        {
            InitializeComponent();

            var regLocation = loadRegLocation();

            _sessions = SessionCollection.LoadSessions(regLocation);

            Render();
        }

        public void Render()
        {
            puttyView.Nodes.Clear();
            puttyView.Nodes.Add(_sessions.Render());
            puttyView.ExpandAll();
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dirForm = new CreateDirectory())
            {
                dirForm.ShowDialog();
                if (dirForm.DialogResult == DialogResult.OK)
                {
                    var newNode = puttyView.SelectedNode.Nodes.Add(dirForm.DirectoryName);
                    newNode.ImageIndex = 2;
                    newNode.SelectedImageIndex = newNode.ImageIndex;
                    newNode.Name = dirForm.DirectoryName;
                    puttyView.SelectedNode.ExpandAll();

                    Settings.Default.Directories.Add(newNode.FullPath);
                    Settings.Default.Save();
                }
            }
        }

        private void folderCtxMnu_Opening(object sender, CancelEventArgs e)
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
            return Settings.Default.PuTTYRegPath;
        }

        private void OpenPutty(TreeNode treeNode)
        {
            var savedPuttyPath = Settings.Default.PuTTYPath;

            if (File.Exists(savedPuttyPath))
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = Settings.Default.PuTTYPath,
                    Arguments = $"-load \"{treeNode.Text}\""
                };
                Process.Start(startInfo);
            }
            else
            {
                using (var puttyForm = new LocatePutty())
                {
                    puttyForm.ShowDialog();
                    if (puttyForm.DialogResult != DialogResult.OK) return;
                    Settings.Default.PuTTYPath = puttyForm.puttyPath;
                    Settings.Default.Save();
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