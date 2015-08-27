using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System;
using System.Collections;

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

        private string loadRegLocation()
        {

            return Properties.Settings.Default.PuTTYRegPath;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPutty(puttyView.SelectedNode);
        }

        private void OpenPutty(TreeNode treeNode)
        {
            MessageBox.Show(String.Format("Starting putty session {0}", treeNode.Text));
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

        private void folderCtxMnu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (puttyView.SelectedNode.Name == "")
            {
                // in a putty session context
                cloneToolStripMenuItem.Enabled = true;

            }
            else
            {
                // in a folder context.
                cloneToolStripMenuItem.Enabled = false;
            }
        }

        private void puttyView_ItemDrag(object sender, ItemDragEventArgs e)
        {

        }
    }
}