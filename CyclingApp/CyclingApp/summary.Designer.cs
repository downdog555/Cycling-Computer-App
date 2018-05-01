namespace CyclingApp
{
    partial class summary
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
            this.summaryPanel = new System.Windows.Forms.GroupBox();
            this.ifData = new System.Windows.Forms.Label();
            this.tssData = new System.Windows.Forms.Label();
            this.TSSLabel = new System.Windows.Forms.Label();
            this.ifLab = new System.Windows.Forms.Label();
            this.summaryDataBox = new System.Windows.Forms.RichTextBox();
            this.summaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // summaryPanel
            // 
            this.summaryPanel.Controls.Add(this.ifData);
            this.summaryPanel.Controls.Add(this.tssData);
            this.summaryPanel.Controls.Add(this.TSSLabel);
            this.summaryPanel.Controls.Add(this.ifLab);
            this.summaryPanel.Controls.Add(this.summaryDataBox);
            this.summaryPanel.Location = new System.Drawing.Point(3, 3);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(264, 208);
            this.summaryPanel.TabIndex = 15;
            this.summaryPanel.TabStop = false;
            this.summaryPanel.Text = "Summary Data";
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
            this.summaryDataBox.Size = new System.Drawing.Size(249, 124);
            this.summaryDataBox.TabIndex = 0;
            this.summaryDataBox.Text = "";
            // 
            // summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.summaryPanel);
            this.Name = "summary";
            this.Size = new System.Drawing.Size(278, 283);
            this.Load += new System.EventHandler(this.summary_Load);
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox summaryPanel;
        private System.Windows.Forms.Label ifData;
        private System.Windows.Forms.Label tssData;
        private System.Windows.Forms.Label TSSLabel;
        private System.Windows.Forms.Label ifLab;
        private System.Windows.Forms.RichTextBox summaryDataBox;
    }
}
