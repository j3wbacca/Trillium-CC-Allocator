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
    public partial class RowEditor : Form
    {
        // attributes
        Controller con;

        public RowEditor(Controller con)
        {
            this.con = con;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool allValid = true;
            string badFields = "";
            decimal voids;
            DateTime voider;
            
            // validate
            
            if (txtName.Text.Length < 4)
            {
                allValid = false;
                badFields += "Cardholder Name, ";
            }
            if (!DateTime.TryParse(txtDate.Text, out voider) || txtDate.Text.Length < 1)
            {
                allValid = false;
                badFields += "Process Date, ";
            }
            if (txtMerchant.Text.Length < 4)
            {
                allValid = false;
                badFields += "Merchant Name/Location, ";
            }
            if (!decimal.TryParse(txtAmount.Text, out voids) || txtAmount.Text.Length < 1)
            {
                allValid = false;
                badFields += "Amount, ";
            }

            // add to ds
            if (allValid)
            {
                con.addRow(txtName.Text, txtMerchant.Text, txtAmount.Text, txtDate.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid values found. Please fix the following items:\r\n" + badFields);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
