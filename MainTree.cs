using System;
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

                TreeNode newNode = puttyView.SelectedNode.Nodes.Add(dirForm.DirectoryName);
                newNode.ImageIndex = 2;
                newNode.SelectedImageIndex = newNode.ImageIndex;
                newNode.Name = dirForm.DirectoryName;
                puttyView.SelectedNode.ExpandAll();

                Properties.Settings.Default.Directories.Add(newNode.FullPath);
                Properties.Settings.Default.Save();
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
            MessageBox.Show(String.Format("Starting putty session {0}", treeNode.Text));
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