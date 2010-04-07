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
    public partial class MultiSplitForm : Form
    {
        DataGridViewSelectedRowCollection parentViewSelectedRows;
        DataSet allocations;
        DataTable tempSplitTable;
        int counter = 0;

        public MultiSplitForm(DataGridViewSelectedRowCollection parentViewSelectedRows, DataSet allocations)
        {
            this.parentViewSelectedRows = parentViewSelectedRows;       // grab data sent from parent form
            this.allocations = allocations;
            InitializeComponent();
        }

        private void MultiSplitForm_Load(object sender, EventArgs e)
        {
            // get data from parent form and clone it into multisplit form
            tempSplitTable = allocations.Tables["Split"].Clone();
            dataGridView1.DataSource = tempSplitTable;
            // add two split rows to start
            tempSplitTable.Rows.Add();
            tempSplitTable.Rows.Add();
            tempSplitTable.Rows[0]["Amount"] = 1;
            tempSplitTable.Rows[1]["Amount"] = 1;
            // counter to keep track of the number of rows
            counter += 2;

            // write-protect and modify display of all columns
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {

                switch (col.Name)
                {
                    case "ChargeID":
                        col.Visible = false;
                        break;
                    case "Amount":
                        col.HeaderText = "Weight";
                        col.FillWeight = 75f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 3;
                        break;
                    case "Company":
                        col.FillWeight = 200f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 2;
                        break;
                    case "Account":
                        col.FillWeight = 200f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 1;
                        break;
                }
            }
        }

        // add split row button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tempSplitTable.Rows.Add();
            tempSplitTable.Rows[counter]["Amount"] = 1;
            counter += 1;
        }

        // remove split row button
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                tempSplitTable.Rows.Remove(((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row);
                counter -= 1;
            }
        }

        private double calculateRequestedSplitDollarAmount(double totalAmount, double splitWeightValue, int splitWeightSum)
        {
            // total amount in the parent form * weighted fractional split
            return totalAmount * (splitWeightValue / Convert.ToDouble(splitWeightSum));      
        }

        // perform split button
        private void btnCommit_Click(object sender, EventArgs e)
        {
            // for each transaction row,
            foreach (DataGridViewRow parentViewSelectedRow in parentViewSelectedRows)
            {
                double requestedSplitDollarAmountSum = 0;
                int weightSum = 0;      
                
                foreach (DataRow tempSplitTableRow in tempSplitTable.Rows)
                {
                    weightSum += Convert.ToInt16(tempSplitTableRow["Amount"]);
                }

                foreach (DataRow tempSplitTableRow in tempSplitTable.Rows)
                {
                    // sum of total calculated splits
                    requestedSplitDollarAmountSum += calculateRequestedSplitDollarAmount(
                           Convert.ToDouble(parentViewSelectedRow.Cells["Amount"].Value),
                           Convert.ToDouble(tempSplitTableRow["Amount"]), weightSum);   
                }

                // check that the split rows add up to the correct amount
                if (requestedSplitDollarAmountSum != Convert.ToDouble(parentViewSelectedRow.Cells["Amount"].Value))
                {

                    MessageBox.Show("$" + requestedSplitDollarAmountSum + " is not equal to $" + Convert.ToDouble(parentViewSelectedRow.Cells["Amount"].Value));
                }

                else
                {
                    // split it
                    parentViewSelectedRow.Cells["Company"].Value = "Split";
                    parentViewSelectedRow.Cells["Account"].Value = "Split";

                    // and add the requested splits to the row's split table
                    foreach (DataRow tempSplitTableRow in tempSplitTable.Rows)
                    {
                        // first, calculate what the split dollar value will be based on the requested percentage
                        double requestedSplitDollarAmount = calculateRequestedSplitDollarAmount(
                            Convert.ToDouble(parentViewSelectedRow.Cells["Amount"].Value),
                           Convert.ToDouble(tempSplitTableRow["Amount"]), weightSum);                        //TODO: fix rounding errors for 33.333% and "who gets the penny"

                        DataRow splitRow = allocations.Tables["Split"].NewRow();
                        splitRow["ChargeID"] = parentViewSelectedRow.Cells["ChargeID"].Value.ToString();
                        splitRow["Company"] = tempSplitTableRow["Company"];
                        splitRow["Account"] = tempSplitTableRow["Account"];
                        splitRow["Amount"] = requestedSplitDollarAmount;
                        allocations.Tables["Split"].Rows.Add(splitRow);
                    }

                    // close the multisplit form
                    Close();
                }
            }
        }
    }
}
