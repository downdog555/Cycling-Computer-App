namespace CyclingApp
{
    partial class UserMarkerControl
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.Label();
            this.endTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.remove = new System.Windows.Forms.LinkLabel();
            this.loadSectionLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(117, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(102, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View Summary Data";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Time:";
            // 
            // startTime
            // 
            this.startTime.AutoSize = true;
            this.startTime.Location = new System.Drawing.Point(67, 4);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(35, 13);
            this.startTime.TabIndex = 3;
            this.startTime.Text = "label3";
            // 
            // endTime
            // 
            this.endTime.AutoSize = true;
            this.endTime.Location = new System.Drawing.Point(184, 4);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(35, 13);
            this.endTime.TabIndex = 5;
            this.endTime.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "End Time:";
            // 
            // remove
            // 
            this.remove.AutoSize = true;
            this.remove.Location = new System.Drawing.Point(3, 17);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(83, 13);
            this.remove.TabIndex = 6;
            this.remove.TabStop = true;
            this.remove.Text = "Remove Marker";
            this.remove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.remove_LinkClicked);
            // 
            // loadSectionLink
            // 
            this.loadSectionLink.AutoSize = true;
            this.loadSectionLink.Location = new System.Drawing.Point(4, 34);
            this.loadSectionLink.Name = "loadSectionLink";
            this.loadSectionLink.Size = new System.Drawing.Size(70, 13);
            this.loadSectionLink.TabIndex = 7;
            this.loadSectionLink.TabStop = true;
            this.loadSectionLink.Text = "Load Section";
            this.loadSectionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loadSectionLink_LinkClicked);
            // 
            // UserMarkerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadSectionLink);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Name = "UserMarkerControl";
            this.Size = new System.Drawing.Size(229, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label startTime;
        private System.Windows.Forms.Label endTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel remove;
        private System.Windows.Forms.LinkLabel loadSectionLink;
    }
}
