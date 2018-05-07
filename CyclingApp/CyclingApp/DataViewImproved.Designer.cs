namespace CyclingApp
{
    partial class DataViewImproved
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
            this.hrCheckBox = new System.Windows.Forms.CheckBox();
            this.ftpCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.euroSelection = new System.Windows.Forms.RadioButton();
            this.usSelection = new System.Windows.Forms.RadioButton();
            this.rideDetailsBox = new System.Windows.Forms.GroupBox();
            this.dateOfRide = new System.Windows.Forms.Label();
            this.timeOfRide = new System.Windows.Forms.Label();
            this.lengthOfRide = new System.Windows.Forms.Label();
            this.recordingInterval = new System.Windows.Forms.Label();
            this.recordingIntervalLabel = new System.Windows.Forms.Label();
            this.lengthOfRideLabel = new System.Windows.Forms.Label();
            this.timeRideLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.enterValues = new System.Windows.Forms.GroupBox();
            this.maxHRValue = new System.Windows.Forms.Label();
            this.maxHRLabel = new System.Windows.Forms.Label();
            this.ftpValue = new System.Windows.Forms.Label();
            this.ftpLabel = new System.Windows.Forms.Label();
            this.basePanel = new System.Windows.Forms.Panel();
            this.chunkM = new System.Windows.Forms.GroupBox();
            this.chunkmFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.userIntervalsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.revertData = new System.Windows.Forms.Button();
            this.removeSmooth = new System.Windows.Forms.Button();
            this.windowSizeEntry = new System.Windows.Forms.TextBox();
            this.smoothing = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.intervalDetection = new System.Windows.Forms.Button();
            this.powerButton = new System.Windows.Forms.Button();
            this.speedButton = new System.Windows.Forms.Button();
            this.cadenceButton = new System.Windows.Forms.Button();
            this.altitudeButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.hrButton = new System.Windows.Forms.Button();
            this.summaryPanel = new System.Windows.Forms.GroupBox();
            this.normPower = new System.Windows.Forms.Label();
            this.normPowerlbl = new System.Windows.Forms.Label();
            this.ifData = new System.Windows.Forms.Label();
            this.tssData = new System.Windows.Forms.Label();
            this.TSSLabel = new System.Windows.Forms.Label();
            this.ifLab = new System.Windows.Forms.Label();
            this.summaryDataBox = new System.Windows.Forms.RichTextBox();
            this.fullDataPanel = new System.Windows.Forms.GroupBox();
            this.fullDataFlow = new System.Windows.Forms.Panel();
            this.graphPanel = new System.Windows.Forms.GroupBox();
            this.intervalsBox = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hrLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.cadenceLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.rideDetailsBox.SuspendLayout();
            this.enterValues.SuspendLayout();
            this.basePanel.SuspendLayout();
            this.chunkM.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            this.fullDataPanel.SuspendLayout();
            this.intervalsBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hrCheckBox
            // 
            this.hrCheckBox.AutoSize = true;
            this.hrCheckBox.Location = new System.Drawing.Point(458, 3);
            this.hrCheckBox.Name = "hrCheckBox";
            this.hrCheckBox.Size = new System.Drawing.Size(148, 17);
            this.hrCheckBox.TabIndex = 12;
            this.hrCheckBox.Text = "Show HR in % of Max HR";
            this.hrCheckBox.UseVisualStyleBackColor = true;
            this.hrCheckBox.CheckedChanged += new System.EventHandler(this.hrCheckBox_CheckedChanged);
            // 
            // ftpCheckBox
            // 
            this.ftpCheckBox.AutoSize = true;
            this.ftpCheckBox.Location = new System.Drawing.Point(308, 3);
            this.ftpCheckBox.Name = "ftpCheckBox";
            this.ftpCheckBox.Size = new System.Drawing.Size(144, 17);
            this.ftpCheckBox.TabIndex = 11;
            this.ftpCheckBox.Text = "Show Power In % of FTP";
            this.ftpCheckBox.UseVisualStyleBackColor = true;
            this.ftpCheckBox.CheckedChanged += new System.EventHandler(this.ftpCheckBox_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.removeFileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1918, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click_1);
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
            this.euroSelection.Location = new System.Drawing.Point(155, 3);
            this.euroSelection.Name = "euroSelection";
            this.euroSelection.Size = new System.Drawing.Size(74, 17);
            this.euroSelection.TabIndex = 8;
            this.euroSelection.TabStop = true;
            this.euroSelection.Text = "Euro Units";
            this.euroSelection.UseVisualStyleBackColor = true;
            this.euroSelection.Click += new System.EventHandler(this.euroSelection_Click);
            // 
            // usSelection
            // 
            this.usSelection.AutoSize = true;
            this.usSelection.Location = new System.Drawing.Point(235, 3);
            this.usSelection.Name = "usSelection";
            this.usSelection.Size = new System.Drawing.Size(67, 17);
            this.usSelection.TabIndex = 9;
            this.usSelection.TabStop = true;
            this.usSelection.Text = "US Units";
            this.usSelection.UseVisualStyleBackColor = true;
            this.usSelection.Click += new System.EventHandler(this.usSelection_Click);
            // 
            // rideDetailsBox
            // 
            this.rideDetailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rideDetailsBox.Controls.Add(this.dateOfRide);
            this.rideDetailsBox.Controls.Add(this.timeOfRide);
            this.rideDetailsBox.Controls.Add(this.lengthOfRide);
            this.rideDetailsBox.Controls.Add(this.recordingInterval);
            this.rideDetailsBox.Controls.Add(this.recordingIntervalLabel);
            this.rideDetailsBox.Controls.Add(this.lengthOfRideLabel);
            this.rideDetailsBox.Controls.Add(this.timeRideLabel);
            this.rideDetailsBox.Controls.Add(this.dateLabel);
            this.rideDetailsBox.Location = new System.Drawing.Point(1582, 159);
            this.rideDetailsBox.Name = "rideDetailsBox";
            this.rideDetailsBox.Size = new System.Drawing.Size(292, 98);
            this.rideDetailsBox.TabIndex = 9;
            this.rideDetailsBox.TabStop = false;
            this.rideDetailsBox.Text = "Ride Information";
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
            // enterValues
            // 
            this.enterValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterValues.Controls.Add(this.maxHRValue);
            this.enterValues.Controls.Add(this.maxHRLabel);
            this.enterValues.Controls.Add(this.ftpValue);
            this.enterValues.Controls.Add(this.ftpLabel);
            this.enterValues.Location = new System.Drawing.Point(1582, 4);
            this.enterValues.Name = "enterValues";
            this.enterValues.Size = new System.Drawing.Size(284, 39);
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
            this.maxHRLabel.Size = new System.Drawing.Size(49, 13);
            this.maxHRLabel.TabIndex = 2;
            this.maxHRLabel.Text = "Max HR:";
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
            // basePanel
            // 
            this.basePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basePanel.AutoScroll = true;
            this.basePanel.Controls.Add(this.chunkM);
            this.basePanel.Controls.Add(this.groupBox3);
            this.basePanel.Controls.Add(this.groupBox2);
            this.basePanel.Controls.Add(this.summaryPanel);
            this.basePanel.Controls.Add(this.fullDataPanel);
            this.basePanel.Controls.Add(this.graphPanel);
            this.basePanel.Controls.Add(this.intervalsBox);
            this.basePanel.Controls.Add(this.groupBox1);
            this.basePanel.Controls.Add(this.enterValues);
            this.basePanel.Controls.Add(this.rideDetailsBox);
            this.basePanel.Location = new System.Drawing.Point(4, 27);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(1911, 886);
            this.basePanel.TabIndex = 10;
            this.basePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.basePanel_Paint);
            // 
            // chunkM
            // 
            this.chunkM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chunkM.Controls.Add(this.chunkmFlow);
            this.chunkM.Location = new System.Drawing.Point(1582, 749);
            this.chunkM.Name = "chunkM";
            this.chunkM.Size = new System.Drawing.Size(284, 140);
            this.chunkM.TabIndex = 17;
            this.chunkM.TabStop = false;
            this.chunkM.Text = "Chunk Timings";
            // 
            // chunkmFlow
            // 
            this.chunkmFlow.AutoScroll = true;
            this.chunkmFlow.Location = new System.Drawing.Point(7, 20);
            this.chunkmFlow.Name = "chunkmFlow";
            this.chunkmFlow.Size = new System.Drawing.Size(305, 109);
            this.chunkmFlow.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.userIntervalsFlow);
            this.groupBox3.Location = new System.Drawing.Point(1582, 473);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 140);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "User Intervals";
            // 
            // userIntervalsFlow
            // 
            this.userIntervalsFlow.AutoScroll = true;
            this.userIntervalsFlow.Location = new System.Drawing.Point(7, 20);
            this.userIntervalsFlow.Name = "userIntervalsFlow";
            this.userIntervalsFlow.Size = new System.Drawing.Size(305, 109);
            this.userIntervalsFlow.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.revertData);
            this.groupBox2.Controls.Add(this.removeSmooth);
            this.groupBox2.Controls.Add(this.windowSizeEntry);
            this.groupBox2.Controls.Add(this.smoothing);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.intervalDetection);
            this.groupBox2.Controls.Add(this.powerButton);
            this.groupBox2.Controls.Add(this.speedButton);
            this.groupBox2.Controls.Add(this.cadenceButton);
            this.groupBox2.Controls.Add(this.altitudeButton);
            this.groupBox2.Controls.Add(this.allButton);
            this.groupBox2.Controls.Add(this.hrButton);
            this.groupBox2.Location = new System.Drawing.Point(11, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1565, 39);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graph Controls";
            // 
            // revertData
            // 
            this.revertData.Location = new System.Drawing.Point(693, 7);
            this.revertData.Name = "revertData";
            this.revertData.Size = new System.Drawing.Size(75, 23);
            this.revertData.TabIndex = 11;
            this.revertData.Text = "Revert Data";
            this.revertData.UseVisualStyleBackColor = true;
            this.revertData.Click += new System.EventHandler(this.revertData_Click);
            // 
            // removeSmooth
            // 
            this.removeSmooth.Location = new System.Drawing.Point(555, 6);
            this.removeSmooth.Name = "removeSmooth";
            this.removeSmooth.Size = new System.Drawing.Size(118, 23);
            this.removeSmooth.TabIndex = 10;
            this.removeSmooth.Text = "Remove Smoothing";
            this.removeSmooth.UseVisualStyleBackColor = true;
            this.removeSmooth.Click += new System.EventHandler(this.removeSmooth_Click);
            // 
            // windowSizeEntry
            // 
            this.windowSizeEntry.Location = new System.Drawing.Point(504, 9);
            this.windowSizeEntry.Name = "windowSizeEntry";
            this.windowSizeEntry.Size = new System.Drawing.Size(45, 20);
            this.windowSizeEntry.TabIndex = 9;
            // 
            // smoothing
            // 
            this.smoothing.Location = new System.Drawing.Point(376, 6);
            this.smoothing.Name = "smoothing";
            this.smoothing.Size = new System.Drawing.Size(122, 23);
            this.smoothing.TabIndex = 8;
            this.smoothing.Text = "Apply Smoothing";
            this.smoothing.UseVisualStyleBackColor = true;
            this.smoothing.Click += new System.EventHandler(this.smoothing_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Remove Intervals";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // intervalDetection
            // 
            this.intervalDetection.Location = new System.Drawing.Point(109, 10);
            this.intervalDetection.Name = "intervalDetection";
            this.intervalDetection.Size = new System.Drawing.Size(75, 23);
            this.intervalDetection.TabIndex = 6;
            this.intervalDetection.Text = "Detect Intervals";
            this.intervalDetection.UseVisualStyleBackColor = true;
            this.intervalDetection.Click += new System.EventHandler(this.intervalDetection_Click);
            // 
            // powerButton
            // 
            this.powerButton.Location = new System.Drawing.Point(1079, 10);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(75, 23);
            this.powerButton.TabIndex = 5;
            this.powerButton.Text = "Power";
            this.powerButton.UseVisualStyleBackColor = true;
            this.powerButton.Click += new System.EventHandler(this.powerButton_Click);
            // 
            // speedButton
            // 
            this.speedButton.Location = new System.Drawing.Point(1160, 10);
            this.speedButton.Name = "speedButton";
            this.speedButton.Size = new System.Drawing.Size(75, 23);
            this.speedButton.TabIndex = 4;
            this.speedButton.Text = "Speed";
            this.speedButton.UseVisualStyleBackColor = true;
            this.speedButton.Click += new System.EventHandler(this.speedButton_Click);
            // 
            // cadenceButton
            // 
            this.cadenceButton.Location = new System.Drawing.Point(1241, 10);
            this.cadenceButton.Name = "cadenceButton";
            this.cadenceButton.Size = new System.Drawing.Size(75, 23);
            this.cadenceButton.TabIndex = 3;
            this.cadenceButton.Text = "Cadence";
            this.cadenceButton.UseVisualStyleBackColor = true;
            this.cadenceButton.Click += new System.EventHandler(this.cadenceButton_Click);
            // 
            // altitudeButton
            // 
            this.altitudeButton.Location = new System.Drawing.Point(1322, 10);
            this.altitudeButton.Name = "altitudeButton";
            this.altitudeButton.Size = new System.Drawing.Size(75, 23);
            this.altitudeButton.TabIndex = 2;
            this.altitudeButton.Text = "Altitude";
            this.altitudeButton.UseVisualStyleBackColor = true;
            this.altitudeButton.Click += new System.EventHandler(this.altitudeButton_Click);
            // 
            // allButton
            // 
            this.allButton.Location = new System.Drawing.Point(1484, 10);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(75, 23);
            this.allButton.TabIndex = 1;
            this.allButton.Text = "All";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // hrButton
            // 
            this.hrButton.Location = new System.Drawing.Point(1403, 10);
            this.hrButton.Name = "hrButton";
            this.hrButton.Size = new System.Drawing.Size(75, 23);
            this.hrButton.TabIndex = 0;
            this.hrButton.Text = "HR";
            this.hrButton.UseVisualStyleBackColor = true;
            this.hrButton.Click += new System.EventHandler(this.hrButton_Click);
            // 
            // summaryPanel
            // 
            this.summaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryPanel.Controls.Add(this.normPower);
            this.summaryPanel.Controls.Add(this.normPowerlbl);
            this.summaryPanel.Controls.Add(this.ifData);
            this.summaryPanel.Controls.Add(this.tssData);
            this.summaryPanel.Controls.Add(this.TSSLabel);
            this.summaryPanel.Controls.Add(this.ifLab);
            this.summaryPanel.Controls.Add(this.summaryDataBox);
            this.summaryPanel.Location = new System.Drawing.Point(1583, 264);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(283, 208);
            this.summaryPanel.TabIndex = 14;
            this.summaryPanel.TabStop = false;
            this.summaryPanel.Text = "Summary Data";
            // 
            // normPower
            // 
            this.normPower.AutoSize = true;
            this.normPower.Location = new System.Drawing.Point(123, 183);
            this.normPower.Name = "normPower";
            this.normPower.Size = new System.Drawing.Size(35, 13);
            this.normPower.TabIndex = 6;
            this.normPower.Text = "label2";
            // 
            // normPowerlbl
            // 
            this.normPowerlbl.AutoSize = true;
            this.normPowerlbl.Location = new System.Drawing.Point(6, 183);
            this.normPowerlbl.Name = "normPowerlbl";
            this.normPowerlbl.Size = new System.Drawing.Size(95, 13);
            this.normPowerlbl.TabIndex = 5;
            this.normPowerlbl.Text = "Normalized Power:";
            // 
            // ifData
            // 
            this.ifData.AutoSize = true;
            this.ifData.Location = new System.Drawing.Point(123, 150);
            this.ifData.Name = "ifData";
            this.ifData.Size = new System.Drawing.Size(35, 13);
            this.ifData.TabIndex = 4;
            this.ifData.Text = "label2";
            // 
            // tssData
            // 
            this.tssData.AutoSize = true;
            this.tssData.Location = new System.Drawing.Point(123, 170);
            this.tssData.Name = "tssData";
            this.tssData.Size = new System.Drawing.Size(35, 13);
            this.tssData.TabIndex = 3;
            this.tssData.Text = "label2";
            // 
            // TSSLabel
            // 
            this.TSSLabel.AutoSize = true;
            this.TSSLabel.Location = new System.Drawing.Point(6, 170);
            this.TSSLabel.Name = "TSSLabel";
            this.TSSLabel.Size = new System.Drawing.Size(111, 13);
            this.TSSLabel.TabIndex = 2;
            this.TSSLabel.Text = "Training Stress Score:";
            // 
            // ifLab
            // 
            this.ifLab.AutoSize = true;
            this.ifLab.Location = new System.Drawing.Point(6, 151);
            this.ifLab.Name = "ifLab";
            this.ifLab.Size = new System.Drawing.Size(82, 13);
            this.ifLab.TabIndex = 1;
            this.ifLab.Text = "Intensity Factor:";
            // 
            // summaryDataBox
            // 
            this.summaryDataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryDataBox.Location = new System.Drawing.Point(9, 20);
            this.summaryDataBox.Name = "summaryDataBox";
            this.summaryDataBox.ReadOnly = true;
            this.summaryDataBox.Size = new System.Drawing.Size(268, 124);
            this.summaryDataBox.TabIndex = 0;
            this.summaryDataBox.Text = "";
            this.summaryDataBox.TextChanged += new System.EventHandler(this.summaryDataBox_TextChanged);
            // 
            // fullDataPanel
            // 
            this.fullDataPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fullDataPanel.Controls.Add(this.fullDataFlow);
            this.fullDataPanel.Location = new System.Drawing.Point(4, 434);
            this.fullDataPanel.Name = "fullDataPanel";
            this.fullDataPanel.Size = new System.Drawing.Size(1572, 446);
            this.fullDataPanel.TabIndex = 13;
            this.fullDataPanel.TabStop = false;
            this.fullDataPanel.Text = "Full Data";
            // 
            // fullDataFlow
            // 
            this.fullDataFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fullDataFlow.Location = new System.Drawing.Point(7, 20);
            this.fullDataFlow.Name = "fullDataFlow";
            this.fullDataFlow.Size = new System.Drawing.Size(1559, 420);
            this.fullDataFlow.TabIndex = 0;
            // 
            // graphPanel
            // 
            this.graphPanel.Location = new System.Drawing.Point(3, 49);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(1573, 378);
            this.graphPanel.TabIndex = 12;
            this.graphPanel.TabStop = false;
            this.graphPanel.Text = "Graph";
            this.graphPanel.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // intervalsBox
            // 
            this.intervalsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalsBox.Controls.Add(this.groupBox4);
            this.intervalsBox.Location = new System.Drawing.Point(1583, 619);
            this.intervalsBox.Name = "intervalsBox";
            this.intervalsBox.Size = new System.Drawing.Size(284, 122);
            this.intervalsBox.TabIndex = 11;
            this.intervalsBox.TabStop = false;
            this.intervalsBox.Text = "Intevals";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.flowLayoutPanel1);
            this.groupBox4.Location = new System.Drawing.Point(1, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 89);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "User Intervals";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 152);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.altitudeLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hrLabel);
            this.groupBox1.Controls.Add(this.powerLabel);
            this.groupBox1.Controls.Add(this.speedLabel);
            this.groupBox1.Controls.Add(this.cadenceLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(1582, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 98);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensors";
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.Location = new System.Drawing.Point(106, 72);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(79, 13);
            this.altitudeLabel.TabIndex = 9;
            this.altitudeLabel.Text = "Length Of Ride";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Altitude:";
            // 
            // hrLabel
            // 
            this.hrLabel.AutoSize = true;
            this.hrLabel.Location = new System.Drawing.Point(106, 20);
            this.hrLabel.Name = "hrLabel";
            this.hrLabel.Size = new System.Drawing.Size(37, 13);
            this.hrLabel.TabIndex = 7;
            this.hrLabel.Text = "Active";
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(106, 33);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(79, 13);
            this.powerLabel.TabIndex = 6;
            this.powerLabel.Text = "Length Of Ride";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(106, 46);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(79, 13);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "Length Of Ride";
            // 
            // cadenceLabel
            // 
            this.cadenceLabel.AutoSize = true;
            this.cadenceLabel.Location = new System.Drawing.Point(106, 59);
            this.cadenceLabel.Name = "cadenceLabel";
            this.cadenceLabel.Size = new System.Drawing.Size(79, 13);
            this.cadenceLabel.TabIndex = 4;
            this.cadenceLabel.Text = "Length Of Ride";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cadence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Speed:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Power:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Heart Rate";
            // 
            // DataViewImproved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hrCheckBox);
            this.Controls.Add(this.ftpCheckBox);
            this.Controls.Add(this.euroSelection);
            this.Controls.Add(this.basePanel);
            this.Controls.Add(this.usSelection);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DataViewImproved";
            this.Size = new System.Drawing.Size(1918, 916);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rideDetailsBox.ResumeLayout(false);
            this.rideDetailsBox.PerformLayout();
            this.enterValues.ResumeLayout(false);
            this.enterValues.PerformLayout();
            this.basePanel.ResumeLayout(false);
            this.chunkM.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            this.fullDataPanel.ResumeLayout(false);
            this.intervalsBox.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox hrCheckBox;
        private System.Windows.Forms.CheckBox ftpCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.RadioButton euroSelection;
        private System.Windows.Forms.RadioButton usSelection;
        private System.Windows.Forms.GroupBox rideDetailsBox;
        private System.Windows.Forms.Label dateOfRide;
        private System.Windows.Forms.Label timeOfRide;
        private System.Windows.Forms.Label lengthOfRide;
        private System.Windows.Forms.Label recordingInterval;
        private System.Windows.Forms.Label recordingIntervalLabel;
        private System.Windows.Forms.Label lengthOfRideLabel;
        private System.Windows.Forms.Label timeRideLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.GroupBox enterValues;
        private System.Windows.Forms.Label maxHRValue;
        private System.Windows.Forms.Label maxHRLabel;
        private System.Windows.Forms.Label ftpValue;
        private System.Windows.Forms.Label ftpLabel;
        private System.Windows.Forms.Panel basePanel;
        private System.Windows.Forms.GroupBox graphPanel;
        private System.Windows.Forms.GroupBox intervalsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label hrLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label cadenceLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox summaryPanel;
        private System.Windows.Forms.GroupBox fullDataPanel;
        private System.Windows.Forms.Panel fullDataFlow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.Button hrButton;
        private System.Windows.Forms.Button powerButton;
        private System.Windows.Forms.Button speedButton;
        private System.Windows.Forms.Button cadenceButton;
        private System.Windows.Forms.Button altitudeButton;
        private System.Windows.Forms.RichTextBox summaryDataBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.Button intervalDetection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel userIntervalsFlow;
        private System.Windows.Forms.TextBox windowSizeEntry;
        private System.Windows.Forms.Button smoothing;
        private System.Windows.Forms.Button removeSmooth;
        private System.Windows.Forms.Label ifData;
        private System.Windows.Forms.Label tssData;
        private System.Windows.Forms.Label TSSLabel;
        private System.Windows.Forms.Label ifLab;
        private System.Windows.Forms.Button revertData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox chunkM;
        private System.Windows.Forms.FlowLayoutPanel chunkmFlow;
        private System.Windows.Forms.Label normPower;
        private System.Windows.Forms.Label normPowerlbl;
    }
}
