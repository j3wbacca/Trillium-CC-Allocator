using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trillium_CC_Allocation
{
    public partial class Form1 : Form
    {
        #region Attributes
        bool isAdminVersion;
        Controller con;
        DataSet chartOfAccounts;
        DataSet allocations;
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            
            con = new Controller(this);

            // this enables or disables admin functions
            if (Properties.Settings.Default.adminVersion == "true")
            {
                isAdminVersion = true;
            }
            else
            {
                isAdminVersion = false;
            }

            if (isAdminVersion)
            {
                adminToolStrip.Visible = true;
            }
            else
            {
                adminToolStrip.Visible = false;
            }
            
        }
        #endregion

        #region Interface Behaviors

        public void highlightRow(string chargeID)
        {
            DataGridViewCell tempCell = null;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if( row.Cells["ChargeID"].Value.ToString() == chargeID)
                {
                    tempCell = row.Cells["Company"];
                }
            }

            dataGridView1.CurrentCell = tempCell;
        }

        public void setDataSource(DataSet ds)
        {
            allocations = ds;

            dataGridView1.DataSource = allocations.Tables["Allocation"];

            // display the Amount column as a currency
            //form.dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "C";
        }

        void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable tempDS = (DataTable)dataGridView1.DataSource;

                if (tempDS.DataSet.HasChanges())
                {
                    DialogResult result = MessageBox.Show("Save your changes before closing?", "Save", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        // save
                        saveFileDialog1.DefaultExt = ".xml";
                        saveFileDialog1.Filter = "XML File|*.xml";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            con.saveXML(saveFileDialog1.FileName);
                        }
                        else
                        {
                            // cancel close
                            e.Cancel = true;
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        // continue
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        // cancel close
                        e.Cancel = true;
                    }

                }
            }

        }


        void dataGridView1_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            updateFloatingCombo();
        }

        /* Don't think this works
        void dataGridView1_Click(object sender, System.EventArgs e)
        {
            // only process if the grid is currently disabled
            if (!dataGridView1.Enabled)
            {
                floatingCombo_LostFocus(sender, e);
            }
        }
        

        void dataGridView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {    /* TODO: Get this working
            MessageBox.Show(dataGridView1.GetChildAtPoint(e.Location).Name);
            
            if (e.Button == MouseButtons.Left
                && dataGridView1.CurrentCell.Equals())
            {
                updateFloatingCombo();
           }
        }
        */
        
        void dataGridView1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            if (Char.IsLetterOrDigit(e.KeyChar) 
                || Char.IsSymbol(e.KeyChar) 
                || Char.IsPunctuation(e.KeyChar))
            {
                if (dg.CurrentCell.OwningColumn.Name == "Company"
                    | dg.CurrentCell.OwningColumn.Name == "Account")
                {
                    updateFloatingCombo(e.KeyChar);
                }
            }
           
        }


        void dataGridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;

            /*
             * || e.KeyCode == Keys.Enter
                || e.KeyCode == Keys.Return*/

            if (e.KeyCode == Keys.F2
               || e.KeyCode == Keys.Space)
            {
                if (dg.CurrentCell.OwningColumn.Name == "Company"
                    | dg.CurrentCell.OwningColumn.Name == "Account")
                {
                    updateFloatingCombo();
                    e.Handled = true;
                }
            }

        }



        void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            if (dataGridView1.DataSource != null && dataGridView1.CurrentCell != null)
            {
                // resize the floatingCombo
                Rectangle tempR = dataGridView1.GetCellDisplayRectangle(
                  dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);
                tempR.Offset(dataGridView1.Location);
                floatingCombo.Bounds = tempR;
                closeButton.Location = new Point(tempR.Right, tempR.Top);
            }
        }


        void updateFloatingCombo()
        {
            updateFloatingCombo(new Char());
        }

        void updateFloatingCombo(Char keyChar)
        {

            if (dataGridView1.DataSource != null && dataGridView1.CurrentCell != null)
            {
                if (dataGridView1.CurrentCell.Value.ToString() != "Split")
                {
                    // modify behavior based on the grid's column
                    if (dataGridView1.CurrentCell.OwningColumn.Name == "Company")
                    {
                        dataGridView1.Enabled = false;

                        // popup an edit box with companies
                        floatingCombo.Items.Clear();

                        Rectangle tempR = dataGridView1.GetCellDisplayRectangle(
                            dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);
                        tempR.Offset(dataGridView1.Location);
                        floatingCombo.Bounds = tempR;
                        floatingCombo.Text = dataGridView1.CurrentCell.Value.ToString();
                        floatingCombo.Show();

                        closeButton.Location = new Point(tempR.Right, tempR.Top);
                        closeButton.Show();

                        floatingCombo.Items.AddRange(con.getCompanyList());
                        floatingCombo.Focus();
                        if (keyChar != new Char())
                        {
                            floatingCombo.Text = keyChar.ToString();
                        }
                        floatingCombo.Select(floatingCombo.Text.Length, 0);
                        
                        

                    }
                    else if (dataGridView1.CurrentCell.OwningColumn.Name == "Account")
                    {
                        dataGridView1.Enabled = false;

                        // popup an edit box with accounts  
                        floatingCombo.Items.Clear();

                        Rectangle tempR = dataGridView1.GetCellDisplayRectangle(
                            dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, true);
                        tempR.Offset(dataGridView1.Location);
                        floatingCombo.Bounds = tempR;
                        floatingCombo.Text = dataGridView1.CurrentCell.Value.ToString();
                        floatingCombo.Show();

                        closeButton.Location = new Point(tempR.Right, tempR.Top);
                        closeButton.Show();
                        
                        floatingCombo.Items.AddRange(
                            con.getAccountList(
                            // get the accounts that correspond to this row's Company.
                            dataGridView1.CurrentRow.Cells["Company"].Value.ToString()
                            ));
                        floatingCombo.Focus();
                        
                        if (keyChar != new Char())
                        {
                            floatingCombo.Text = keyChar.ToString();
                        }
                        floatingCombo.Select(floatingCombo.Text.Length, 0);
                    }
                    else
                    {
                        dataGridView1.Enabled = true;
                        // hide the edit box
                        floatingCombo.Items.Clear();
                        floatingCombo.Hide();
                        // hide button
                        closeButton.Hide();
                    }
                }

                
            }
            
        }

        void floatingCombo_LostFocus(object sender, System.EventArgs e)
        {
            if (floatingCombo.Visible)
            {
                if (floatingCombo.Items.Contains(floatingCombo.Text))
                {
                    // Put the item's text into the current cell
                    dataGridView1.CurrentCell.Value = floatingCombo.Text;
                }

                dataGridView1.Enabled = true;
                // Hide the box and reset the selection.
                floatingCombo.Hide();
                closeButton.Hide();
                floatingCombo.Text = "";
                dataGridView1.Focus();


            }
            else
            {

            }
            
        }

        /// <summary>
        /// Intercepts keystrokes on the floating combo box (during allocation of company/accounts) to properly handle disappearance of the box. (LostFocus triggers the hiding routines)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void floatingCombo_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter 
                || e.KeyCode == Keys.Return 
                || e.KeyCode == Keys.Escape
                || e.KeyCode == Keys.Tab)
            {
                
                floatingCombo_LostFocus(null,null);
            }
        }


        public void closeButton_Click(object sender, EventArgs e)
        {
            floatingCombo_LostFocus(null, null);
        }
        
        void dataGridView1_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // for Amount values
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Amount"
                && dataGridView1.DataSource == allocations.Tables["Split"])
            {
                checkSplitAmounts();
            }
        }

        void checkSplitAmounts() //object sender, System.Windows.Forms.DataGridViewCellEventArgs e
        {
            /*
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCell thisCell = row.Cells["Amount"];

                    if (thisCell.Value.ToString() != "")
                    {

                        // make sure the total of the displayed amounts is equal to the total
                        // this huge IF finds the matching charge to the current split via ChargeID
                        // and compares it to the current total amount
                        string totalAmountStr = allocations.Tables["Allocation"].Rows.Find(
                            row.Cells["ChargeID"].Value.ToString())
                            ["Amount"].ToString();
                        decimal totalAmount = decimal.Parse(totalAmountStr, System.Globalization.NumberStyles.Currency);
                        decimal thisAmount = decimal.Parse(
                            thisCell.Value.ToString(), System.Globalization.NumberStyles.Currency);

                        if (totalAmount > thisAmount)
                        {
                            thisCell.Style.ForeColor = Color.Yellow;
                        }
                        else if (totalAmount < thisAmount)
                        {
                            thisCell.Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            thisCell.Style.ForeColor = Color.Green;
                        }
                    }
                }
             */
        }

        void dataGridView1_DataMemberChanged(object sender, System.EventArgs e)
        {
            dataGridView1_DataSourceChanged(sender, e);
        }


      

        void dataGridView1_DataSourceChanged(object sender, System.EventArgs e)
        {
           
            // sync the chart of accounts
            chartOfAccounts = con.chartOfAccounts;

            // write-protect and modify display of all columns
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = true;
                
                switch (col.Name)
                {
                    case "ChargeID":
                        col.Visible = false;
                        /*col.DisplayIndex = dataGridView1.Columns.Count - dataGridView1.Columns.Count;
                         *  if (isAdminVersion)
                        {col.Visible = true;
                        }
                        else
                        {}*/
                        break;
                    case "Cardholder Name":
                        col.FillWeight = 120f;
                        col.DisplayIndex = 0;
                        break;
                    case "Process Date":
                        col.FillWeight = 75f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 6;
                        break;
                    case "Merchant Name/Location":
                        col.FillWeight = 200f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 5;
                        break;
                    case "Amount":
                        if (dataGridView1.DataSource == allocations.Tables["Split"])
                        {
                            col.ReadOnly = false;
                        }
                        else
                        {
                            col.ReadOnly = true;
                        }
                        col.DefaultCellStyle.Format = "c";
                        col.FillWeight = 75f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 4;
                        break;
                    case "Company":
                        col.FillWeight = 200f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 3;
                        break;
                    case "Account":
                        col.FillWeight = 200f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 2;
                        break;
                    case "Description":
                        col.ReadOnly = false;
                        col.FillWeight = 230f;
                        col.DisplayIndex = dataGridView1.Columns.Count - 1;
                        break;
                    default:
                        break;
                }
                
            }

            /*compCol.DataSource = chartOfAccounts.Tables["Companies"];
            compCol.DisplayMember = "Company";
            compCol.AutoComplete = true;
            compCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            compCol.DropDownWidth = 230;
            compCol.MaxDropDownItems = 20;
            compCol.FillWeight = 230f;
            compCol.FlatStyle = FlatStyle.Popup;
            DataGridViewComboBoxColumn actCol =
                (DataGridViewComboBoxColumn)dataGridView1.Columns["Account"];
            actCol.AutoComplete = true;
            actCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            actCol.DropDownWidth = 190;
            actCol.MaxDropDownItems = 20;
            actCol.FillWeight = 190f;
            actCol.FlatStyle = FlatStyle.Popup;
            */
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Comma Separated Values File (CSV)|*.csv|All files|*.*";

            // Show dialog box
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                // Ask controller to open the file
                con.importCSV(System.IO.Path.GetDirectoryName(openFileDialog1.FileName),
                    System.IO.Path.GetFileName(openFileDialog1.FileName));
            }
            dataGridView1.Focus();
        }

        void dataGridView1_CellEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dataGridView1.DataSource.Equals(allocations.Tables["Allocation"]))
            {
                // show/hide the split buttons
                if (dataGridView1.Rows[e.RowIndex].Cells["Company"].Value.ToString() == "Split"
                    || dataGridView1.Rows[e.RowIndex].Cells["Account"].Value.ToString() == "Split")
                {
                    // this is a split
                    buttonSwap(GridMode.Allocations, true);
                }
                else
                {
                   buttonSwap(GridMode.Allocations, false);
                }
            }
            else
            {
                buttonSwap(GridMode.Splits, false);
            }
        }
       
        private void btnSplit_Click(object sender, EventArgs e)
        {
            /*DialogResult dr = MessageBox.Show("Split based on Cardholder Name, and sort by Process Date?", "Split Spreadsheet", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {*/
                con.splitFile("Cardholder Name", "Process Date", "Merchant Name/Location");
            /*}
            else
            {
                // do nothing.
            }*/
            dataGridView1.Focus();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            // Show dialog box
            openFileDialog1.Filter = "XML File|*.xml|All files|*.*";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                // Ask controller to open the file
                con.openXML(openFileDialog1.FileName);
            }
            dataGridView1.Focus();
            
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.Filter = "XML File|*.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                con.saveXML(saveFileDialog1.FileName);
            }
            dataGridView1.Focus();
        }


        private void btnCombineXML_Click(object sender, EventArgs e)
        {
            // Show dialog box
            openFileDialog1.Filter = "XML File|*.xml|All files|*.*";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                // Ask controller to open the files
                con.combineXML(openFileDialog1.FileNames);
            }
            dataGridView1.Focus();
        }

        

        private void btnPrint1_Click(object sender, EventArgs e)
        {
                con.printDataGrid();
                dataGridView1.Focus();   
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
                con.printReport2();
                dataGridView1.Focus();   
        }


        private void btnPrint3_Click(object sender, System.EventArgs e)
        {
            con.printReport3();
            dataGridView1.Focus();   
        }


        void dataGridView1_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            /*for (int i = 0; i < e.RowCount; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex + i];

                if (row.Cells["ChargeID"].Value.ToString().Contains("-"))
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = System.Drawing.Color.AliceBlue;
                    row.DefaultCellStyle = style;
                }
            }*/
        }



        private void btnSplitTrans_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && dataGridView1.CurrentRow != null)
            {
                // force lose focus
               // floatingCombo_LostFocus(sender, e);

                string uniqueID = dataGridView1.CurrentRow.Cells["ChargeID"].Value.ToString();

                // if we're on the main allocations screen...
                if (dataGridView1.DataSource == allocations.Tables["Allocation"])
                {
                    // and it's not already a split...
                    if (dataGridView1.CurrentRow.Cells["Company"].Value.ToString() != "Split")
                    {
                        // see if we're dealing with one row or multiple rows to split.
                        if (dataGridView1.SelectedRows.Count > 1)
                        {
                            // for multiple rows,
                            // pass the rows to the multi-split window.
                            MultiSplitForm multiSplitWindow = new MultiSplitForm(dataGridView1.SelectedRows, allocations);
                            multiSplitWindow.ShowDialog();
                        }
                        else
                        {
                            // for a single row,
                           
                            // split the transaction by...
                            // changing the transaction's Company/Account to "split"...
                            dataGridView1.CurrentRow.Cells["Company"].Value = "Split";
                            dataGridView1.CurrentRow.Cells["Account"].Value = "Split";
                            // and adding this transaction to the table of splits...
                            allocations.Tables["Split"].Rows.Add(new string[] { uniqueID });
                            allocations.Tables["Split"].Rows.Add(new string[] { uniqueID });
                        }

                        // and finally, swap to the Splits screen.
                        btnViewSwap_Click(sender, e);
                    }
                    // otherwise, it is already a split...
                    else
                    {
                        // so just swap back to the split screen.
                        btnViewSwap_Click(sender, e);
                    }
                }
                // otherwise, if we're on the split screen...
                else if (dataGridView1.DataSource == allocations.Tables["Split"])
                {
                    // just add another split to the list of splits.
                    allocations.Tables["Split"].Rows.Add(new string[] { uniqueID });
                }
            }
        }


        void btnRemSplit_Click(object sender, System.EventArgs e)
        {
            //remove the currently selected split line
            if (dataGridView1.DataSource != null && dataGridView1.CurrentRow != null)
            {
                string uniqueID = dataGridView1.CurrentRow.Cells["ChargeID"].Value.ToString();

                // If we're on the split form
                if (dataGridView1.DataSource == allocations.Tables["Split"])
                {
                    // Don't manually remove the last line, perform an unsplit instead
                    if (dataGridView1.Rows.Count <= 1)
                    {
                        btnUnSplit_Click(sender, e);
                    }
                    else
                    {
                        if (MessageBox.Show(this, "Delete the currently selected line?", "Remove Split", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                        {
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        }
                    }
                }
            }
        }

        private void btnViewSwap_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.DataSource != null && dataGridView1.CurrentRow != null)
            {
                string uniqueID = dataGridView1.CurrentRow.Cells["ChargeID"].Value.ToString();

                
                if (dataGridView1.DataSource == allocations.Tables["Allocation"])
                {
                    if (dataGridView1.CurrentRow.Cells["Company"].Value.ToString() != "Split"
                       && dataGridView1.CurrentRow.Cells["Account"].Value.ToString() != "Split")
                    {
                        MessageBox.Show(this, "This transaction doesn't have any splits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Switch from Allocation to Splits
                        gridModeSwap(GridMode.Splits, uniqueID);
                    }
                   
                }
               
                else if (dataGridView1.DataSource == allocations.Tables["Split"])
                {
                    decimal amtTotal = 0;
                    decimal tranTotal = 0;

                    foreach(DataGridViewRow row in dataGridView2.Rows)
                    {
                        string temp = row.Cells["Amount"].Value.ToString();
                        if (temp.Length > 0)
                            tranTotal = decimal.Parse(temp);
                    }

                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        string temp = row.Cells["Amount"].Value.ToString();
                        if (temp.Length > 0)
                            amtTotal += decimal.Parse(temp);
                        
                    }

                    if (amtTotal == tranTotal // the total of the rows equals the total allocation
                       || amtTotal == 0) // amtTotal == 0 or there are no splits (total is 0)
                    {
                        // Switch from Splits to Allocation
                        gridModeSwap(GridMode.Allocations, null);
                    }
                    else
                    {
                         MessageBox.Show(this, "The splits don't add up to the total transaction amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void previewPanelSwap(bool show, DataGridViewRow row)
        {
            
            if (show)
            {
                DataRow dr = allocations.Tables["Allocation"].Rows.Find(row.Cells["ChargeID"].Value);
                DataTable tempDT = dr.Table.Clone();
                tempDT.Rows.Add(dr.ItemArray);

                previewPanel.Visible = true;

                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = tempDT;

                dataGridView2.Columns["Amount"].DefaultCellStyle.Format = "c";
                dataGridView2.Columns["Company"].Visible = false;
                dataGridView2.Columns["Account"].Visible = false;
                dataGridView2.Columns["ChargeID"].Visible = false;
            }
            else
            {
                previewPanel.Visible = false;
                dataGridView2.DataSource = null;
            }

        }

        private void buttonSwap(GridMode mode, bool isSplitRow)
        {
            if (mode == GridMode.Allocations)
            {
                if (isSplitRow)
                {
                    btnRemSplit.Visible = false;
                    btnUnSplit.Visible = true;
                    btnViewSwap.Visible = true;
                    btnSplitTrans.Visible = false;
                }
                else
                {
                    btnRemSplit.Visible = false;
                    btnUnSplit.Visible = false;
                    btnViewSwap.Visible = false;
                    btnSplitTrans.Visible = true;
                }
            }
            else
            {
                btnRemSplit.Visible = true;
                btnUnSplit.Visible = true;
                btnViewSwap.Visible = true;
                btnSplitTrans.Visible = true;
            }
            
        }

        private void gridModeSwap(GridMode newMode, string splitFilter)
        {
            if (newMode == GridMode.Allocations)
            {
                floatingCombo_LostFocus(null, null);
                previewPanelSwap(false, null);
                dataGridView1.DataSource = allocations.Tables["Allocation"];
                btnViewSwap.Text = "View Split";
                btnSplitTrans.Text = "Split";
                btnPrint.Visible = true;
                btnSave.Visible = true;
                btnOpen.Visible = true;
                if (isAdminVersion)
                {
                    adminToolStrip.Visible = true;
                }
            }
            else if(newMode == GridMode.Splits)
            {
                floatingCombo_LostFocus(null, null);
                previewPanelSwap(true, dataGridView1.CurrentRow);
                dataGridView1.DataSource = allocations.Tables["Split"];

                allocations.Tables["Split"].DefaultView.RowFilter = "ChargeID = '" + splitFilter + "'";

                if (allocations.Tables["Split"].Rows.Count > 0)
                {
                    checkSplitAmounts();
                }

                btnViewSwap.Text = "View Transactions";
                btnSplitTrans.Text = "Add Split";
                btnPrint.Visible = false;
                btnSave.Visible = false;
                btnOpen.Visible = false;
                adminToolStrip.Visible = false;
            }
            else
            {
                // do nothing
            }
        }

        void btnDeleteRow_Click(object sender, System.EventArgs e)
        {
            //remove the currently selected transaction
            if (dataGridView1.DataSource != null && dataGridView1.CurrentRow != null)
            {
                string uniqueID = dataGridView1.CurrentRow.Cells["ChargeID"].Value.ToString();

                if (MessageBox.Show(this, "Delete the currently selected line?", "Remove Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                
            }
        }

        void btnAddRow_Click(object sender, System.EventArgs e)
        {
            // add new row
            con.addRow();
        }

        private void btnUnSplit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null && dataGridView1.CurrentRow != null)
            {
                string uniqueID = dataGridView1.CurrentRow.Cells["ChargeID"].Value.ToString();

                // If we're on the main form, and this transaction has splits
                if (dataGridView1.DataSource == allocations.Tables["Allocation"]
                    && (dataGridView1.CurrentRow.Cells["Company"].Value.ToString() == "Split"
                    || dataGridView1.CurrentRow.Cells["Account"].Value.ToString() == "Split"))
                {
                    // This section disables the following message box if the function was called recursively by signalling thru Sender.
                    bool proceed = false;
                    if(sender.Equals(true)){
                        proceed = true;
                    }
                    else if(MessageBox.Show(this, "Delete all splits for this transaction?", "Un-Split", 
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        proceed = true;
                    }
                
                    if (proceed == true)
                    {
                        // delete all rows from Splits with the current chargeID 
                        List<DataRow> tempColl = new List<DataRow>();

                        foreach (DataRow row in allocations.Tables["Split"].Rows)
                        {
                            if (row["ChargeID"].ToString() == uniqueID)
                            {
                                tempColl.Add(row);
                            }
                        }

                        foreach (DataRow row in tempColl)
                        {
                            allocations.Tables["Split"].Rows.Remove(row);
                        }

                        // clear this row's company and account.
                        dataGridView1.CurrentRow.Cells["Company"].Value = "";
                        dataGridView1.CurrentRow.Cells["Account"].Value = "";

                        btnRemSplit.Visible = false;
                        btnUnSplit.Visible = false;
                        btnViewSwap.Visible = false;
                        btnSplitTrans.Visible = true;
                    }
                }
                // If we're on the split form
                else if (dataGridView1.DataSource == allocations.Tables["Split"])
                {
                    if (MessageBox.Show(this, "Delete all splits for this transaction?", "Un-Split", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {

                        // clear all amounts for this transaction so that swapping doesn't generate an error
                        foreach (DataRow row in allocations.Tables["Split"].Rows)
                        {
                            if(row["ChargeID"].ToString() == uniqueID)
                            {
                                row["Amount"] = System.DBNull.Value;
                            }
                        }

                        // swap to the main form and clear as normal.
                        btnViewSwap_Click(sender, e);
                        btnUnSplit_Click(true, e);
                        
                    }
                }
            }
        }
        #endregion


    }
}
