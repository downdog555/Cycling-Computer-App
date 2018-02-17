namespace CyclingApp
{
    partial class EnterHR
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
            this.ftpSubmitButton = new System.Windows.Forms.Button();
            this.hrBox = new System.Windows.Forms.TextBox();
            this.ftpLabel = new System.Windows.Forms.Label();
            this.box.SuspendLayout();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.box.Controls.Add(this.ftpSubmitButton);
            this.box.Controls.Add(this.hrBox);
            this.box.Controls.Add(this.ftpLabel);
            this.box.Location = new System.Drawing.Point(12, 7);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(512, 90);
            this.box.TabIndex = 1;
            this.box.TabStop = false;
            this.box.Text = "Max HR";
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
            // hrBox
            // 
            this.hrBox.Location = new System.Drawing.Point(84, 41);
            this.hrBox.Name = "hrBox";
            this.hrBox.Size = new System.Drawing.Size(350, 20);
            this.hrBox.TabIndex = 1;
            // 
            // ftpLabel
            // 
            this.ftpLabel.AutoSize = true;
            this.ftpLabel.Location = new System.Drawing.Point(8, 44);
            this.ftpLabel.Name = "ftpLabel";
            this.ftpLabel.Size = new System.Drawing.Size(70, 13);
            this.ftpLabel.TabIndex = 0;
            this.ftpLabel.Text = "Maximum HR";
            // 
            // EnterHR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 104);
            this.Controls.Add(this.box);
            this.Name = "EnterHR";
            this.Text = "EnterHR";
            this.box.ResumeLayout(false);
            this.box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox box;
        private System.Windows.Forms.Button ftpSubmitButton;
        private System.Windows.Forms.TextBox hrBox;
        private System.Windows.Forms.Label ftpLabel;
    }
}