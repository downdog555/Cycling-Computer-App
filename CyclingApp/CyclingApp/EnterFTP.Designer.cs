namespace CyclingApp
{
    partial class EnterFTP
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
            this.box = new System.Windows.Forms.GroupBox();
            this.ftpLabel = new System.Windows.Forms.Label();
            this.ftpBox = new System.Windows.Forms.TextBox();
            this.ftpSubmitButton = new System.Windows.Forms.Button();
            this.box.SuspendLayout();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.box.Controls.Add(this.ftpSubmitButton);
            this.box.Controls.Add(this.ftpBox);
            this.box.Controls.Add(this.ftpLabel);
            this.box.Location = new System.Drawing.Point(13, 4);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(512, 90);
            this.box.TabIndex = 0;
            this.box.TabStop = false;
            this.box.Text = "Functional FTP";
            // 
            // ftpLabel
            // 
            this.ftpLabel.AutoSize = true;
            this.ftpLabel.Location = new System.Drawing.Point(8, 44);
            this.ftpLabel.Name = "ftpLabel";
            this.ftpLabel.Size = new System.Drawing.Size(142, 13);
            this.ftpLabel.TabIndex = 0;
            this.ftpLabel.Text = "Functional Threshold Power:";
            // 
            // ftpBox
            // 
            this.ftpBox.Location = new System.Drawing.Point(156, 41);
            this.ftpBox.Name = "ftpBox";
            this.ftpBox.Size = new System.Drawing.Size(350, 20);
            this.ftpBox.TabIndex = 1;
            // 
            // ftpSubmitButton
            // 
            this.ftpSubmitButton.Location = new System.Drawing.Point(156, 61);
            this.ftpSubmitButton.Name = "ftpSubmitButton";
            this.ftpSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.ftpSubmitButton.TabIndex = 2;
            this.ftpSubmitButton.Text = "Submit";
            this.ftpSubmitButton.UseVisualStyleBackColor = true;
            this.ftpSubmitButton.Click += new System.EventHandler(this.ftpSubmitButton_Click);
            // 
            // EnterFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 104);
            this.Controls.Add(this.box);
            this.Name = "EnterFTP";
            this.Text = "EnterFTP";
            this.box.ResumeLayout(false);
            this.box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox box;
        private System.Windows.Forms.TextBox ftpBox;
        private System.Windows.Forms.Label ftpLabel;
        private System.Windows.Forms.Button ftpSubmitButton;
    }
}