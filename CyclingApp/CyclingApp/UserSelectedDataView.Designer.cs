namespace CyclingApp
{
    partial class UserSelectedDataView
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
            this.mainBox = new System.Windows.Forms.GroupBox();
            this.graphBox = new System.Windows.Forms.GroupBox();
            this.summaryBox = new System.Windows.Forms.GroupBox();
            this.splitDataBox = new System.Windows.Forms.GroupBox();
            this.graphControlBox = new System.Windows.Forms.GroupBox();
            this.mainBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainBox
            // 
            this.mainBox.Controls.Add(this.graphControlBox);
            this.mainBox.Controls.Add(this.splitDataBox);
            this.mainBox.Controls.Add(this.summaryBox);
            this.mainBox.Controls.Add(this.graphBox);
            this.mainBox.Location = new System.Drawing.Point(5, 3);
            this.mainBox.Name = "mainBox";
            this.mainBox.Size = new System.Drawing.Size(1233, 614);
            this.mainBox.TabIndex = 0;
            this.mainBox.TabStop = false;
            this.mainBox.Text = "User Selection Start:   End:";
            // 
            // graphBox
            // 
            this.graphBox.Location = new System.Drawing.Point(8, 109);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(1216, 259);
            this.graphBox.TabIndex = 0;
            this.graphBox.TabStop = false;
            this.graphBox.Text = "Graph";
            // 
            // summaryBox
            // 
            this.summaryBox.Location = new System.Drawing.Point(8, 375);
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.Size = new System.Drawing.Size(1216, 231);
            this.summaryBox.TabIndex = 1;
            this.summaryBox.TabStop = false;
            this.summaryBox.Text = "Summaries";
            // 
            // splitDataBox
            // 
            this.splitDataBox.Location = new System.Drawing.Point(7, 20);
            this.splitDataBox.Name = "splitDataBox";
            this.splitDataBox.Size = new System.Drawing.Size(1211, 44);
            this.splitDataBox.TabIndex = 2;
            this.splitDataBox.TabStop = false;
            this.splitDataBox.Text = "Split Buttons";
            // 
            // graphControlBox
            // 
            this.graphControlBox.Location = new System.Drawing.Point(8, 70);
            this.graphControlBox.Name = "graphControlBox";
            this.graphControlBox.Size = new System.Drawing.Size(1211, 33);
            this.graphControlBox.TabIndex = 3;
            this.graphControlBox.TabStop = false;
            this.graphControlBox.Text = "Graph Control Buttons";
            // 
            // UserSelectedDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 621);
            this.Controls.Add(this.mainBox);
            this.Name = "UserSelectedDataView";
            this.Text = "UserSelectedDataView";
            this.mainBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox mainBox;
        private System.Windows.Forms.GroupBox graphControlBox;
        private System.Windows.Forms.GroupBox splitDataBox;
        private System.Windows.Forms.GroupBox summaryBox;
        private System.Windows.Forms.GroupBox graphBox;
    }
}