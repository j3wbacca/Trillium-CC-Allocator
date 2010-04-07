using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trillium_CC_Allocation
{
    public partial class UpdatePrompt : Form
    {
        public UpdatePrompt()
        {
            InitializeComponent();
            icon.Image = SystemIcons.Warning.ToBitmap();
            lblLink.Text = Properties.Settings.Default.updateWebsite;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblLink.Text);
        }
    }
}
