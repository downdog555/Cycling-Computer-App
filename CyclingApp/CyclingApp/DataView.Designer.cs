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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.euroSelection = new System.Windows.Forms.RadioButton();
            this.usSelection = new System.Windows.Forms.RadioButton();
            this.basePanel = new System.Windows.Forms.Panel();
            this.enterValues = new System.Windows.Forms.GroupBox();
            this.maxHRValue = new System.Windows.Forms.Label();
            this.maxHRLabel = new System.Windows.Forms.Label();
            this.ftpValue = new System.Windows.Forms.Label();
            this.ftpLabel = new System.Windows.Forms.Label();
            this.rideDetailsBox = new System.Windows.Forms.GroupBox();
            this.activeSensorsBox = new System.Windows.Forms.GroupBox();
            this.dateOfRide = new System.Windows.Forms.Label();
            this.timeOfRide = new System.Windows.Forms.Label();
            this.lengthOfRide = new System.Windows.Forms.Label();
            this.recordingInterval = new System.Windows.Forms.Label();
            this.recordingIntervalLabel = new System.Windows.Forms.Label();
            this.lengthOfRideLabel = new System.Windows.Forms.Label();
            this.timeRideLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.hrDataPanel = new System.Windows.Forms.Panel();
            this.allHrData = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.graphsButton = new System.Windows.Forms.Button();
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.summaryButton = new System.Windows.Forms.Button();
            this.ftpCheckBox = new System.Windows.Forms.CheckBox();
            this.hrCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.basePanel.SuspendLayout();
            this.enterValues.SuspendLayout();
            this.rideDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.removeFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // removeFileToolStripMenuItem
            // 
            this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
            this.removeFileToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.removeFileToolStripMenuItem.Text = "Remove File";
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
            this.euroSelection.Click += new System.EventHandler(this.euroSelection_Click);
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
            this.usSelection.Click += new System.EventHandler(this.usSelection_Click);
            // 
            // basePanel
            // 
            this.basePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basePanel.AutoScroll = true;
            this.basePanel.Controls.Add(this.enterValues);
            this.basePanel.Controls.Add(this.rideDetailsBox);
            this.basePanel.Controls.Add(this.hrDataPanel);
            this.basePanel.Controls.Add(this.allHrData);
            this.basePanel.Controls.Add(this.graphPanel);
            this.basePanel.Controls.Add(this.graphsButton);
            this.basePanel.Controls.Add(this.summaryPanel);
            this.basePanel.Controls.Add(this.summaryButton);
            this.basePanel.Location = new System.Drawing.Point(4, 28);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(694, 762);
            this.basePanel.TabIndex = 4;
            // 
            // enterValues
            // 
            this.enterValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterValues.Controls.Add(this.maxHRValue);
            this.enterValues.Controls.Add(this.maxHRLabel);
            this.enterValues.Controls.Add(this.ftpValue);
            this.enterValues.Controls.Add(this.ftpLabel);
            this.enterValues.Location = new System.Drawing.Point(16, 4);
            this.enterValues.Name = "enterValues";
            this.enterValues.Size = new System.Drawing.Size(667, 39);
            this.enterValues.TabIndex = 10;
            this.enterValues.TabStop = false;
            this.enterValues.Text = "FTP & Max HR";
            // 
            // maxHRValue
            // 
            this.maxHRValue.AutoSize = true;
            this.maxHRValue.Location = new System.Drawing.Point(184, 20);
            this.maxHRValue.Name = "maxHRValue";
            this.maxHRValue.Size = new System.Drawing.Size(13, 13);
            this.maxHRValue.TabIndex = 3;
            this.maxHRValue.Text = "0";
            // 
            // maxHRLabel
            // 
            this.maxHRLabel.AutoSize = true;
            this.maxHRLabel.Location = new System.Drawing.Point(132, 20);
            this.maxHRLabel.Name = "maxHRLabel";
            this.maxHRLabel.Size = new System.Drawing.Size(46, 13);
            this.maxHRLabel.TabIndex = 2;
            this.maxHRLabel.Text = "Max HR";
            // 
            // ftpValue
            // 
            this.ftpValue.AutoSize = true;
            this.ftpValue.Location = new System.Drawing.Point(43, 20);
            this.ftpValue.Name = "ftpValue";
            this.ftpValue.Size = new System.Drawing.Size(35, 13);
            this.ftpValue.TabIndex = 1;
            this.ftpValue.Text = "label2";
            // 
            // ftpLabel
            // 
            this.ftpLabel.AutoSize = true;
            this.ftpLabel.Location = new System.Drawing.Point(7, 20);
            this.ftpLabel.Name = "ftpLabel";
            this.ftpLabel.Size = new System.Drawing.Size(30, 13);
            this.ftpLabel.TabIndex = 0;
            this.ftpLabel.Text = "FTP:";
            // 
            // rideDetailsBox
            // 
            this.rideDetailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rideDetailsBox.Controls.Add(this.activeSensorsBox);
            this.rideDetailsBox.Controls.Add(this.dateOfRide);
            this.rideDetailsBox.Controls.Add(this.timeOfRide);
            this.rideDetailsBox.Controls.Add(this.lengthOfRide);
            this.rideDetailsBox.Controls.Add(this.recordingInterval);
            this.rideDetailsBox.Controls.Add(this.recordingIntervalLabel);
            this.rideDetailsBox.Controls.Add(this.lengthOfRideLabel);
            this.rideDetailsBox.Controls.Add(this.timeRideLabel);
            this.rideDetailsBox.Controls.Add(this.dateLabel);
            this.rideDetailsBox.Location = new System.Drawing.Point(7, 49);
            this.rideDetailsBox.Name = "rideDetailsBox";
            this.rideDetailsBox.Size = new System.Drawing.Size(682, 135);
            this.rideDetailsBox.TabIndex = 9;
            this.rideDetailsBox.TabStop = false;
            this.rideDetailsBox.Text = "Ride Information";
            // 
            // activeSensorsBox
            // 
            this.activeSensorsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeSensorsBox.Location = new System.Drawing.Point(9, 75);
            this.activeSensorsBox.Name = "activeSensorsBox";
            this.activeSensorsBox.Size = new System.Drawing.Size(667, 99);
            this.activeSensorsBox.TabIndex = 8;
            this.activeSensorsBox.TabStop = false;
            this.activeSensorsBox.Text = "Active Sensors";
            // 
            // dateOfRide
            // 
            this.dateOfRide.AutoSize = true;
            this.dateOfRide.Location = new System.Drawing.Point(106, 20);
            this.dateOfRide.Name = "dateOfRide";
            this.dateOfRide.Size = new System.Drawing.Size(79, 13);
            this.dateOfRide.TabIndex = 7;
            this.dateOfRide.Text = "Length Of Ride";
            // 
            // timeOfRide
            // 
            this.timeOfRide.AutoSize = true;
            this.timeOfRide.Location = new System.Drawing.Point(106, 33);
            this.timeOfRide.Name = "timeOfRide";
            this.timeOfRide.Size = new System.Drawing.Size(79, 13);
            this.timeOfRide.TabIndex = 6;
            this.timeOfRide.Text = "Length Of Ride";
            // 
            // lengthOfRide
            // 
            this.lengthOfRide.AutoSize = true;
            this.lengthOfRide.Location = new System.Drawing.Point(106, 46);
            this.lengthOfRide.Name = "lengthOfRide";
            this.lengthOfRide.Size = new System.Drawing.Size(79, 13);
            this.lengthOfRide.TabIndex = 5;
            this.lengthOfRide.Text = "Length Of Ride";
            // 
            // recordingInterval
            // 
            this.recordingInterval.AutoSize = true;
            this.recordingInterval.Location = new System.Drawing.Point(106, 59);
            this.recordingInterval.Name = "recordingInterval";
            this.recordingInterval.Size = new System.Drawing.Size(79, 13);
            this.recordingInterval.TabIndex = 4;
            this.recordingInterval.Text = "Length Of Ride";
            // 
            // recordingIntervalLabel
            // 
            this.recordingIntervalLabel.AutoSize = true;
            this.recordingIntervalLabel.Location = new System.Drawing.Point(6, 59);
            this.recordingIntervalLabel.Name = "recordingIntervalLabel";
            this.recordingIntervalLabel.Size = new System.Drawing.Size(94, 13);
            this.recordingIntervalLabel.TabIndex = 3;
            this.recordingIntervalLabel.Text = "Recording Interval";
            // 
            // lengthOfRideLabel
            // 
            this.lengthOfRideLabel.AutoSize = true;
            this.lengthOfRideLabel.Location = new System.Drawing.Point(6, 46);
            this.lengthOfRideLabel.Name = "lengthOfRideLabel";
            this.lengthOfRideLabel.Size = new System.Drawing.Size(79, 13);
            this.lengthOfRideLabel.TabIndex = 2;
            this.lengthOfRideLabel.Text = "Length Of Ride";
            // 
            // timeRideLabel
            // 
            this.timeRideLabel.AutoSize = true;
            this.timeRideLabel.Location = new System.Drawing.Point(6, 33);
            this.timeRideLabel.Name = "timeRideLabel";
            this.timeRideLabel.Size = new System.Drawing.Size(72, 13);
            this.timeRideLabel.TabIndex = 1;
            this.timeRideLabel.Text = "Time Of Ride:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(6, 20);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(72, 13);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date Of Ride:";
            // 
            // hrDataPanel
            // 
            this.hrDataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hrDataPanel.AutoScroll = true;
            this.hrDataPanel.Location = new System.Drawing.Point(7, 400);
            this.hrDataPanel.Name = "hrDataPanel";
            this.hrDataPanel.Size = new System.Drawing.Size(682, 140);
            this.hrDataPanel.TabIndex = 8;
            // 
            // allHrData
            // 
            this.allHrData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allHrData.Location = new System.Drawing.Point(5, 370);
            this.allHrData.Name = "allHrData";
            this.allHrData.Size = new System.Drawing.Size(684, 23);
            this.allHrData.TabIndex = 7;
            this.allHrData.Text = "Show/Hide Full Data";
            this.allHrData.UseVisualStyleBackColor = true;
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.Location = new System.Drawing.Point(4, 575);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(687, 184);
            this.graphPanel.TabIndex = 5;
            // 
            // graphsButton
            // 
            this.graphsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphsButton.Location = new System.Drawing.Point(7, 546);
            this.graphsButton.Name = "graphsButton";
            this.graphsButton.Size = new System.Drawing.Size(684, 23);
            this.graphsButton.TabIndex = 4;
            this.graphsButton.Text = "Show/Hide Graphs";
            this.graphsButton.UseVisualStyleBackColor = true;
            // 
            // summaryPanel
            // 
            this.summaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryPanel.AutoScroll = true;
            this.summaryPanel.Location = new System.Drawing.Point(7, 219);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(684, 145);
            this.summaryPanel.TabIndex = 1;
            // 
            // summaryButton
            // 
            this.summaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryButton.Location = new System.Drawing.Point(5, 190);
            this.summaryButton.Name = "summaryButton";
            this.summaryButton.Size = new System.Drawing.Size(687, 23);
            this.summaryButton.TabIndex = 0;
            this.summaryButton.Text = "Show/Hide Summary";
            this.summaryButton.UseVisualStyleBackColor = true;
            this.summaryButton.Click += new System.EventHandler(this.summaryButton_Click_1);
            // 
            // ftpCheckBox
            // 
            this.ftpCheckBox.AutoSize = true;
            this.ftpCheckBox.Location = new System.Drawing.Point(329, 6);
            this.ftpCheckBox.Name = "ftpCheckBox";
            this.ftpCheckBox.Size = new System.Drawing.Size(144, 17);
            this.ftpCheckBox.TabIndex = 5;
            this.ftpCheckBox.Text = "Show Power In % of FTP";
            this.ftpCheckBox.UseVisualStyleBackColor = true;
            this.ftpCheckBox.CheckedChanged += new System.EventHandler(this.ftpCheckBox_CheckedChanged);
            // 
            // hrCheckBox
            // 
            this.hrCheckBox.AutoSize = true;
            this.hrCheckBox.Location = new System.Drawing.Point(479, 5);
            this.hrCheckBox.Name = "hrCheckBox";
            this.hrCheckBox.Size = new System.Drawing.Size(148, 17);
            this.hrCheckBox.TabIndex = 6;
            this.hrCheckBox.Text = "Show HR in % of Max HR";
            this.hrCheckBox.UseVisualStyleBackColor = true;
            this.hrCheckBox.CheckedChanged += new System.EventHandler(this.hrCheckBox_CheckedChanged);
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.hrCheckBox);
            this.Controls.Add(this.ftpCheckBox);
            this.Controls.Add(this.basePanel);
            this.Controls.Add(this.usSelection);
            this.Controls.Add(this.euroSelection);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DataView";
            this.Size = new System.Drawing.Size(701, 793);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.basePanel.ResumeLayout(false);
            this.enterValues.ResumeLayout(false);
            this.enterValues.PerformLayout();
            this.rideDetailsBox.ResumeLayout(false);
            this.rideDetailsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.RadioButton euroSelection;
        private System.Windows.Forms.RadioButton usSelection;
        private System.Windows.Forms.Panel basePanel;
        private System.Windows.Forms.Button summaryButton;
        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.FlowLayoutPanel graphPanel;
        private System.Windows.Forms.Button graphsButton;
        private System.Windows.Forms.Panel hrDataPanel;
        private System.Windows.Forms.Button allHrData;
        private System.Windows.Forms.GroupBox rideDetailsBox;
        private System.Windows.Forms.Label recordingIntervalLabel;
        private System.Windows.Forms.Label lengthOfRideLabel;
        private System.Windows.Forms.Label timeRideLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.GroupBox activeSensorsBox;
        private System.Windows.Forms.Label dateOfRide;
        private System.Windows.Forms.Label timeOfRide;
        private System.Windows.Forms.Label lengthOfRide;
        private System.Windows.Forms.Label recordingInterval;
        private System.Windows.Forms.GroupBox enterValues;
        private System.Windows.Forms.Label ftpValue;
        private System.Windows.Forms.Label ftpLabel;
        private System.Windows.Forms.Label maxHRValue;
        private System.Windows.Forms.Label maxHRLabel;
        private System.Windows.Forms.CheckBox ftpCheckBox;
        private System.Windows.Forms.CheckBox hrCheckBox;
    }
}
