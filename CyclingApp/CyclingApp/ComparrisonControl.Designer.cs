namespace CyclingApp
{
    partial class ComparrisonControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.summaryGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.summaryGroupBox);
            this.groupBox1.Controls.Add(this.dataGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 661);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File 1";
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Location = new System.Drawing.Point(3, 187);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Size = new System.Drawing.Size(723, 473);
            this.dataGroupBox.TabIndex = 0;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "data";
            // 
            // summaryGroupBox
            // 
            this.summaryGroupBox.Location = new System.Drawing.Point(7, 20);
            this.summaryGroupBox.Name = "summaryGroupBox";
            this.summaryGroupBox.Size = new System.Drawing.Size(714, 161);
            this.summaryGroupBox.TabIndex = 1;
            this.summaryGroupBox.TabStop = false;
            this.summaryGroupBox.Text = "summary";
            // 
            // ComparrisonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ComparrisonControl";
            this.Size = new System.Drawing.Size(734, 668);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox summaryGroupBox;
        private System.Windows.Forms.GroupBox dataGroupBox;
    }
}
