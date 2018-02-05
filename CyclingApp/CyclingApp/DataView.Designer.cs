namespace CyclingApp
{
    partial class DataView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.summaryExpand = new WinFormsExpander.Expander();
            this.menuStrip1.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.removeFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(441, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.loadFileToolStripMenuItem.Text = "Load File";
            // 
            // removeFileToolStripMenuItem
            // 
            this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
            this.removeFileToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.removeFileToolStripMenuItem.Text = "Remove File";
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.summaryExpand);
            this.dataPanel.Location = new System.Drawing.Point(4, 28);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(434, 567);
            this.dataPanel.TabIndex = 1;
            // 
            // summaryExpand
            // 
            this.summaryExpand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryExpand.AutoScroll = true;
            this.summaryExpand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.summaryExpand.CollapseImage = ((System.Drawing.Image)(resources.GetObject("summaryExpand.CollapseImage")));
            // 
            // summaryExpand.Content
            // 
            this.summaryExpand.Content.AutoScroll = true;
            this.summaryExpand.Content.AutoScrollMinSize = new System.Drawing.Size(150, 50);
            this.summaryExpand.ExpandImage = ((System.Drawing.Image)(resources.GetObject("summaryExpand.ExpandImage")));
            this.summaryExpand.Header = "Summary";
            this.summaryExpand.Location = new System.Drawing.Point(4, 4);
            this.summaryExpand.MinimumSize = new System.Drawing.Size(0, 53);
            this.summaryExpand.Name = "summaryExpand";
            this.summaryExpand.Size = new System.Drawing.Size(427, 201);
            this.summaryExpand.TabIndex = 0;
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DataView";
            this.Size = new System.Drawing.Size(441, 601);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.Panel dataPanel;
        private WinFormsExpander.Expander summaryExpand;
    }
}
