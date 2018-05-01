namespace CyclingApp
{
    partial class CyclingMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSingleFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ftpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.enterMaximumHeartRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabSelector = new System.Windows.Forms.TabControl();
            this.singleView = new System.Windows.Forms.TabPage();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareTab = new System.Windows.Forms.TabPage();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadFile1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFile2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabSelector.SuspendLayout();
            this.singleView.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.compareTab.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.ftpMenu,
            this.enterMaximumHeartRateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(17, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(432, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSingleFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSingleFileToolStripMenuItem
            // 
            this.loadSingleFileToolStripMenuItem.Name = "loadSingleFileToolStripMenuItem";
            this.loadSingleFileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadSingleFileToolStripMenuItem.Text = "Load Single File";
            this.loadSingleFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // ftpMenu
            // 
            this.ftpMenu.Name = "ftpMenu";
            this.ftpMenu.Size = new System.Drawing.Size(69, 20);
            this.ftpMenu.Text = "Enter FTP";
            this.ftpMenu.Click += new System.EventHandler(this.ftpMenu_Click);
            // 
            // enterMaximumHeartRateToolStripMenuItem
            // 
            this.enterMaximumHeartRateToolStripMenuItem.Name = "enterMaximumHeartRateToolStripMenuItem";
            this.enterMaximumHeartRateToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
            this.enterMaximumHeartRateToolStripMenuItem.Text = "Enter Maximum Heart Rate";
            this.enterMaximumHeartRateToolStripMenuItem.Click += new System.EventHandler(this.enterMaximumHeartRateToolStripMenuItem_Click);
            // 
            // tabSelector
            // 
            this.tabSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelector.Controls.Add(this.singleView);
            this.tabSelector.Controls.Add(this.compareTab);
            this.tabSelector.Location = new System.Drawing.Point(13, 29);
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.SelectedIndex = 0;
            this.tabSelector.Size = new System.Drawing.Size(625, 533);
            this.tabSelector.TabIndex = 1;
            // 
            // singleView
            // 
            this.singleView.Controls.Add(this.menuStrip3);
            this.singleView.Location = new System.Drawing.Point(4, 22);
            this.singleView.Name = "singleView";
            this.singleView.Padding = new System.Windows.Forms.Padding(3);
            this.singleView.Size = new System.Drawing.Size(617, 507);
            this.singleView.TabIndex = 0;
            this.singleView.Text = "Single View";
            this.singleView.UseVisualStyleBackColor = true;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(3, 3);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(611, 24);
            this.menuStrip3.TabIndex = 0;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // compareTab
            // 
            this.compareTab.Controls.Add(this.menuStrip2);
            this.compareTab.Location = new System.Drawing.Point(4, 22);
            this.compareTab.Name = "compareTab";
            this.compareTab.Padding = new System.Windows.Forms.Padding(3);
            this.compareTab.Size = new System.Drawing.Size(617, 507);
            this.compareTab.TabIndex = 1;
            this.compareTab.Text = "Compare Details";
            this.compareTab.UseVisualStyleBackColor = true;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFile1ToolStripMenuItem,
            this.loadFile2ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(611, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "FileDialog";
            this.fileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FileOk);
            // 
            // loadFile1ToolStripMenuItem
            // 
            this.loadFile1ToolStripMenuItem.Name = "loadFile1ToolStripMenuItem";
            this.loadFile1ToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadFile1ToolStripMenuItem.Text = "Load File 1";
            // 
            // loadFile2ToolStripMenuItem
            // 
            this.loadFile2ToolStripMenuItem.Name = "loadFile2ToolStripMenuItem";
            this.loadFile2ToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.loadFile2ToolStripMenuItem.Text = "Load File 2";
            // 
            // CyclingMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 603);
            this.Controls.Add(this.tabSelector);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip3;
            this.Name = "CyclingMain";
            this.Text = "Cycling App";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabSelector.ResumeLayout(false);
            this.singleView.ResumeLayout(false);
            this.singleView.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.compareTab.ResumeLayout(false);
            this.compareTab.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl tabSelector;
        private System.Windows.Forms.TabPage singleView;
        private System.Windows.Forms.TabPage compareTab;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.ToolStripMenuItem ftpMenu;
        private System.Windows.Forms.ToolStripMenuItem enterMaximumHeartRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSingleFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFile1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFile2ToolStripMenuItem;
    }
}

