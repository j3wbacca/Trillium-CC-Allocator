using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trillium_CC_Allocation
{
    class UserForm:Form1
    {
        public UserForm()
            : base()
        {
            
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.SuspendLayout();
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(744, 514);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.ResumeLayout(false);

        }
    }
}
