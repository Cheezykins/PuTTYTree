namespace PuTTYTree
{
    partial class MainTree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Sessions");
            this.puttyView = new System.Windows.Forms.TreeView();
            this.folderCtxMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderCtxMnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // puttyView
            // 
            this.puttyView.ContextMenuStrip = this.folderCtxMnu;
            this.puttyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.puttyView.FullRowSelect = true;
            this.puttyView.Location = new System.Drawing.Point(0, 0);
            this.puttyView.Name = "puttyView";
            treeNode1.Name = "root";
            treeNode1.Text = "Sessions";
            this.puttyView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.puttyView.Size = new System.Drawing.Size(284, 410);
            this.puttyView.TabIndex = 0;
            // 
            // folderCtxMnu
            // 
            this.folderCtxMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.createFolderToolStripMenuItem});
            this.folderCtxMnu.Name = "folderCtxMnu";
            this.folderCtxMnu.Size = new System.Drawing.Size(145, 92);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cloneToolStripMenuItem.Text = "Clone";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.createFolderToolStripMenuItem.Text = "Create Folder";
            // 
            // MainTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 410);
            this.Controls.Add(this.puttyView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainTree";
            this.ShowIcon = false;
            this.Text = "PuTTY Tree";
            this.TopMost = true;
            this.folderCtxMnu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView puttyView;
        private System.Windows.Forms.ContextMenuStrip folderCtxMnu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
    }
}

