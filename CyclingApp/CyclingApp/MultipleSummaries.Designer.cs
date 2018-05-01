namespace CyclingApp
{
    partial class MultipleSummaries
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
            this.chunkBox = new System.Windows.Forms.GroupBox();
            this.chunkNum = new System.Windows.Forms.TextBox();
            this.chunkButton = new System.Windows.Forms.Button();
            this.chunkBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chunkBox
            // 
            this.chunkBox.Controls.Add(this.chunkNum);
            this.chunkBox.Controls.Add(this.chunkButton);
            this.chunkBox.Location = new System.Drawing.Point(13, 13);
            this.chunkBox.Name = "chunkBox";
            this.chunkBox.Size = new System.Drawing.Size(185, 57);
            this.chunkBox.TabIndex = 1;
            this.chunkBox.TabStop = false;
            this.chunkBox.Text = "Number of Chunks";
            // 
            // chunkNum
            // 
            this.chunkNum.Location = new System.Drawing.Point(87, 22);
            this.chunkNum.Name = "chunkNum";
            this.chunkNum.Size = new System.Drawing.Size(84, 20);
            this.chunkNum.TabIndex = 1;
            // 
            // chunkButton
            // 
            this.chunkButton.Location = new System.Drawing.Point(6, 19);
            this.chunkButton.Name = "chunkButton";
            this.chunkButton.Size = new System.Drawing.Size(75, 23);
            this.chunkButton.TabIndex = 0;
            this.chunkButton.Text = "Chunk Data";
            this.chunkButton.UseVisualStyleBackColor = true;
            this.chunkButton.Click += new System.EventHandler(this.chunkButton_Click);
            // 
            // MultipleSummaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 93);
            this.Controls.Add(this.chunkBox);
            this.Name = "MultipleSummaries";
            this.Text = "MultipleSummaries";
            this.Load += new System.EventHandler(this.MultipleSummaries_Load);
            this.chunkBox.ResumeLayout(false);
            this.chunkBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox chunkBox;
        private System.Windows.Forms.TextBox chunkNum;
        private System.Windows.Forms.Button chunkButton;
    }
}