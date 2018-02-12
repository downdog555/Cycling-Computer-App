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
            this.Panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.summaryExpand = new WinFormsExpander.Expander();
            this.euroSelection = new System.Windows.Forms.RadioButton();
            this.usSelection = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
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
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.Panel1.Controls.Add(this.summaryExpand);
            this.Panel1.Location = new System.Drawing.Point(4, 28);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(434, 573);
            this.Panel1.TabIndex = 1;
            // 
            // summaryExpand
            // 
            this.summaryExpand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryExpand.AutoScroll = true;
            this.summaryExpand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.summaryExpand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.summaryExpand.CollapseImage = ((System.Drawing.Image)(resources.GetObject("summaryExpand.CollapseImage")));
            // 
            // summaryExpand.Content
            // 
            this.summaryExpand.Content.AutoScroll = true;
            this.summaryExpand.Content.AutoScrollMinSize = new System.Drawing.Size(150, 50);
            this.summaryExpand.ExpandImage = ((System.Drawing.Image)(resources.GetObject("summaryExpand.ExpandImage")));
            this.summaryExpand.Location = new System.Drawing.Point(3, 3);
            this.summaryExpand.MinimumSize = new System.Drawing.Size(0, 53);
            this.summaryExpand.Name = "summaryExpand";
            this.summaryExpand.Size = new System.Drawing.Size(434, 235);
            this.summaryExpand.TabIndex = 2;
            // 
            // euroSelection
            // 
            this.euroSelection.AutoSize = true;
            this.euroSelection.Location = new System.Drawing.Point(164, 6);
            this.euroSelection.Name = "euroSelection";
            this.euroSelection.Size = new System.Drawing.Size(74, 17);
            this.euroSelection.TabIndex = 2;
            this.euroSelection.TabStop = true;
            this.euroSelection.Text = "Euro Units";
            this.euroSelection.UseVisualStyleBackColor = true;
            this.euroSelection.CheckedChanged += new System.EventHandler(this.euroSelection_CheckedChanged);
            this.euroSelection.EnabledChanged += new System.EventHandler(this.euroSelection_EnabledChanged);
            // 
            // usSelection
            // 
            this.usSelection.AutoSize = true;
            this.usSelection.Location = new System.Drawing.Point(255, 5);
            this.usSelection.Name = "usSelection";
            this.usSelection.Size = new System.Drawing.Size(67, 17);
            this.usSelection.TabIndex = 3;
            this.usSelection.TabStop = true;
            this.usSelection.Text = "US Units";
            this.usSelection.UseVisualStyleBackColor = true;
            this.usSelection.CheckedChanged += new System.EventHandler(this.usSelection_CheckedChanged);
            this.usSelection.Click += new System.EventHandler(this.usSelection_Click);
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.usSelection);
            this.Controls.Add(this.euroSelection);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DataView";
            this.Size = new System.Drawing.Size(441, 601);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel Panel1;
        private WinFormsExpander.Expander summaryExpand;
        private System.Windows.Forms.RadioButton euroSelection;
        private System.Windows.Forms.RadioButton usSelection;
    }
}
