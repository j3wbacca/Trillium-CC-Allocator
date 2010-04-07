namespace Trillium_CC_Allocation
{
    partial class UpdatePrompt
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
            this.icon = new System.Windows.Forms.PictureBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.lblText2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // icon
            // 
            this.icon.Location = new System.Drawing.Point(12, 12);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(54, 50);
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // lblText1
            // 
            this.lblText1.Location = new System.Drawing.Point(72, 12);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(283, 50);
            this.lblText1.TabIndex = 7;
            this.lblText1.Text = "Please download the new version of this program by going to the website below, or" +
                " by contacting Support.";
            // 
            // lblLink
            // 
            this.lblLink.Location = new System.Drawing.Point(72, 50);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(270, 23);
            this.lblLink.TabIndex = 8;
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // lblText2
            // 
            this.lblText2.Location = new System.Drawing.Point(72, 79);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(270, 30);
            this.lblText2.TabIndex = 9;
            this.lblText2.Text = "Thanks, Your IT Department";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(140, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UpdatePrompt
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 145);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblText1);
            this.Controls.Add(this.icon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatePrompt";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Version!";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.LinkLabel lblLink;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Button btnOK;
    }
}