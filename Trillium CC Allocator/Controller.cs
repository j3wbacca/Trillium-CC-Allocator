using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Trillium_CC_Allocation
{
    public class Controller
    {
        private Form1 form;
        private DataSet currentDataSet;
        public DataSet chartOfAccounts;

        public Controller(Form1 form)
        {
            // grab form
            this.form = form;

            string coaPath = Properties.Settings.Default.chartOfAccountsPath;

            // load chartOfAccount dataset from embedded serialized object (path is stored in Settings)
            Stream xlsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(coaPath);

            if (xlsStream != null)
            {
                IFormatter formatter = new BinaryFormatter();
                chartOfAccounts = (DataSet)formatter.Deserialize(xlsStream);

                xlsStream.Close();
            }
            else
            {
                throw new Exception("Could not load chart of accounts from resource.");
            }

            // if the version isn't up to date, prompt.
            if (!checkUpdatedVersion())
            {
                UpdatePrompt up = new UpdatePrompt();
                up.ShowDialog();
            }
        
            /*
            // load csv and save as XML (TODO: use xml only)
            chartOfAccounts.Tables.Add(CSVReader.Read("chartofaccounts.xls", "Companies", "Companies", "Companies").Tables["Companies"].Copy());
            //chartOfAccounts.Tables["Companies"].WriteXml("companies.xml", XmlWriteMode.WriteSchema);

            chartOfAccounts.Tables.Add(CSVReader.Read("chartofaccounts.xls", "Corporate", "Corporate", "Corporate").Tables["Corporate"].Copy());
            //chartOfAccounts.Tables["Corporate"].WriteXml("corporateCOA.xml", XmlWriteMode.WriteSchema);

            chartOfAccounts.Tables.Add(CSVReader.Read("chartofaccounts.xls", "Hard Costs", "Hard Costs", "Hard Costs").Tables["Hard Costs"].Copy());
            //chartOfAccounts.Tables["Hard Costs"].WriteXml("hard costsCOA.xml", XmlWriteMode.WriteSchema);

            chartOfAccounts.Tables.Add(CSVReader.Read("chartofaccounts.xls", "Soft Costs", "Soft Costs", "Soft Costs").Tables["Soft Costs"].Copy());
            //chartOfAccounts.Tables["Soft Costs"].WriteXml("soft costsCOA.xml", XmlWriteMode.WriteSchema);

            chartOfAccounts.Tables.Add(CSVReader.Read("chartofaccounts.xls", "Property", "Property", "Property").Tables["Property"].Copy());
            //chartOfAccounts.Tables["Property"].WriteXml("propertyCOA.xml", XmlWriteMode.WriteSchema);
             * */
        }

        bool checkUpdatedVersion()
        {
            try
            {
                string updateURL = Properties.Settings.Default.updateURL;
                string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                System.Net.HttpWebRequest wr =
                    (System.Net.HttpWebRequest)System.Net.WebRequest.Create(updateURL);

                string html = (new StreamReader(wr.GetResponse().GetResponseStream())).ReadToEnd();


                // return true if the currentVersion is equal to the one online.
                if (html.Contains(currentVersion))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        void initDataSet(DataSet currentDataSet)
        {

            // only do this if Split doesn't already exist.
            if (!currentDataSet.Tables.Contains("Split") 
                && currentDataSet.Tables.Contains("Allocation"))
            {
                currentDataSet.Tables.Add("Split");
                currentDataSet.Tables["Split"].Columns.Add("ChargeID", Type.GetType("System.String"));
                currentDataSet.Tables["Split"].Columns.Add("Company", Type.GetType("System.String"));
                currentDataSet.Tables["Split"].Columns.Add("Account", Type.GetType("System.String"));
                currentDataSet.Tables["Split"].Columns.Add("Amount", Type.GetType("System.Double"));

                currentDataSet.Tables["Allocation"].PrimaryKey = new DataColumn[]
                {currentDataSet.Tables["Allocation"].Columns["ChargeID"]};

                currentDataSet.Relations.Add(new DataRelation("allocation-Split",
                    currentDataSet.Tables["Allocation"].Columns["ChargeID"],
                    currentDataSet.Tables["Split"].Columns["ChargeID"]));

            }
        }

        private long getUniqueIndex()
        {
            System.TimeSpan epoch =
                    new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime timestamp = DateTime.Now.Subtract(epoch);
            return timestamp.Ticks;
        }

        public void importCSV(string filePath, string fileName)
        {
           /* try
            {*/
                currentDataSet = CSVReader.Read(filePath, fileName, "Allocations", "Allocation");

                // temporary variable for simplifying below code
                DataTable allocationTable = currentDataSet.Tables["Allocation"];

                // remove identified unnecessary columns
                removeColumnIfExists(allocationTable, "Merchant Category");
                removeColumnIfExists(allocationTable, "Subcategory");
                removeColumnIfExists(allocationTable, "Product");
                removeColumnIfExists(allocationTable, "Middle Name");
                removeColumnIfExists(allocationTable, "Prefix Name");
                removeColumnIfExists(allocationTable, "Suffix Name");
                removeColumnIfExists(allocationTable, "Card Account No.");
                removeColumnIfExists(allocationTable, "Card Account No#");
                removeColumnIfExists(allocationTable, "Guaranteed Status");
                removeColumnIfExists(allocationTable, "Employee ID");
                removeColumnIfExists(allocationTable, "Basic Control Account Name");
                removeColumnIfExists(allocationTable, "Basic Control Account No.");
                removeColumnIfExists(allocationTable, "Basic Control Account No#");
                removeColumnIfExists(allocationTable, "Cost Center");
                removeColumnIfExists(allocationTable, "Universal ID");
                removeColumnIfExists(allocationTable, "NoName");  // blank column title
                removeColumnIfExists(allocationTable, "Merchant / Supplier Name");
                removeColumnIfExists(allocationTable, "Transaction Reference No.");
                removeColumnIfExists(allocationTable, "Transaction Reference No#");
                removeColumnIfExists(allocationTable, "Current Period Opening Balance USD");
                removeColumnIfExists(allocationTable, "Current Period Closing Balance USD");
                removeColumnIfExists(allocationTable, "Current Period No. of Charges");
                removeColumnIfExists(allocationTable, "Current Period No# of Charges");
                removeColumnIfExists(allocationTable, "Cardmember Jan Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Feb Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Mar Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Apr Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember May Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Jun Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Jul Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Aug Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Sep Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Oct Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Nov Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember Dec Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember YTD Billed Amount USD");
                removeColumnIfExists(allocationTable, "Cardmember YTD No. of Charges");
                removeColumnIfExists(allocationTable, "Cardmember YTD No# of Charges");
                removeColumnIfExists(allocationTable, "Report Date");

                mergeColumnsIfExist(allocationTable, "concatenate", "First Name", "Last Name", "Cardholder Name");
                mergeColumnsIfExist(allocationTable, "add", "Current Period Charge Amount USD", "Current Period Credit Amount USD", "Amount");

                renameColumnIfExists(allocationTable, "Transaction Description", "Merchant Name/Location");


                // add allocator columns
                allocationTable.Columns.Add("Company");
                allocationTable.Columns.Add("Account");
                allocationTable.Columns.Add("ChargeID");
                allocationTable.Columns.Add("Description");
                allocationTable.Columns["ChargeID"].SetOrdinal(0);

                allocationTable.Columns["Company"].DataType = Type.GetType("System.String");

                long uniqueIndex = getUniqueIndex();

                foreach (DataRow row in currentDataSet.Tables["Allocation"].Rows)
                {
                    row["ChargeID"] = uniqueIndex.ToString();
                    uniqueIndex++;
                }

                initDataSet(currentDataSet);

                // Add version # to the dataset.
                currentDataSet.ExtendedProperties.Add("AppVersion",
                    Assembly.GetExecutingAssembly().GetName().Version.ToString());

                currentDataSet.AcceptChanges();

                // load the data into the grid
                form.setDataSource(currentDataSet);
           /* }
            catch(Exception e)
            { 
                MessageBox.Show("Error importing CSV. Check that it's a valid export from AMEX with correct headers, no symbols in the filename, and not open in another program.\r\n\r\nError Details: [ " + e.Message + " ]");
            }*/
        }


        private void removeColumnIfExists(DataTable table, string columnName)
        {
            if (table.Columns.Contains(columnName)) table.Columns.Remove(columnName);
        }



        private void renameColumnIfExists(DataTable table, string columnName, string newColumnName)
        {
            if(table.Columns.Contains(columnName))
            {
                table.Columns[columnName].ColumnName = newColumnName;
            }
        }

        /// <summary>
        /// Merges columnA and columnB into a new column, deleting the two original columns, according to a predefined mergeMethod.
        /// </summary>
        /// <param name="table">DataTable containing the columns to be merged</param>
        /// <param name="mergeMethod">A string representing a given string or mathmatical method to merge data fields</param>
        /// <param name="columnA">Name of first column to merge</param>
        /// <param name="columnB">Name of second column to merge</param>
        /// <param name="newColumnName">Name of single resulting column</param>
        private void mergeColumnsIfExist(DataTable table, string mergeMethod, string columnA, string columnB, string newColumnName)
        {
            if (table.Columns.Contains(columnA) && table.Columns.Contains(columnB))
            {

                // select method of merging
                if (mergeMethod == "concatenate")
                {
                    // add new column to table
                    table.Columns.Add(newColumnName, Type.GetType("System.String"));

                    // for each row in the table
                    foreach (DataRow row in table.Rows)
                    {
                        row[newColumnName] = row[columnA].ToString() + " " + row[columnB].ToString();
                    }
                }
                else if (mergeMethod == "add")
                {
                        table.Columns.Add(newColumnName, Type.GetType("System.Double"));

                        // for each row in the table
                        foreach (DataRow row in table.Rows)
                        {
                            if (row[columnA].GetType() != typeof(System.DBNull) && row[columnB].GetType() != typeof(System.DBNull))
                            {
                                row[newColumnName] = Convert.ToDouble(row[columnA]) + Convert.ToDouble(row[columnB]);
                            }
                        }
                }
                else
                {
                    throw new Exception("Error in mergeColumns: mergeMethod is not a valid method identified in code.");
                }

                // when finished, delete both columns
                table.Columns.Remove(columnA);
                table.Columns.Remove(columnB);

            }
        }

        public void splitFile(string sortColumn1, string sortColumn2, string sortColumn3)
        {
            if (currentDataSet != null)
            {

                DataRow[] rowsCopy = new DataRow[currentDataSet.Tables["Allocation"].Rows.Count];
                currentDataSet.Tables["Allocation"].Rows.CopyTo(rowsCopy, 0);

                DataSetCollection tempDataSet;

                tempDataSet = categorizeRows(sortColumn1, sortColumn2, sortColumn3, currentDataSet);
                
                // create a viewer window, populate the data, and display it.
                DataSetViewer dsv = new DataSetViewer(this, tempDataSet);
                dsv.ShowDialog(form);
            }
            else
            {
                MessageBox.Show(form, "Open a CSV file before trying to split.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public string[] getCompanyList()
        {
            // create a list of all Company names
            string[] companies = new string[chartOfAccounts.Tables["Companies"].Rows.Count];
           
            // and gather from table
            for (int i = 0; i < chartOfAccounts.Tables["Companies"].Rows.Count; i++ )
            {
                companies[i] = chartOfAccounts.Tables["Companies"].Rows[i]["Company"].ToString();
            }

            // return all Company names
            return companies;
        }

        public string[] getAccountList(string CompanyName)
        {
            if (CompanyName == "")
            {
                return new string[0];
            }
            else
            {
                // note: COA means Chart of Accounts
                // get the Company's associated COA from the list of companies
                DataRow[] rowArr = chartOfAccounts.Tables["Companies"].Select("Company = '" + CompanyName + "'");
                DataRow tempDR;

                if (rowArr.Length > 0) 
                { 
                    tempDR = rowArr[0];

                    string coa = tempDR["COA"].ToString();

                    // create a list of all accounts in the COA
                    string[] accounts = new string[chartOfAccounts.Tables[coa].Rows.Count];

                    // and gather from table
                    for (int i = 0; i < chartOfAccounts.Tables[coa].Rows.Count; i++)
                    {
                        string accountCode = chartOfAccounts.Tables[coa].Rows[i]["Code"].ToString();
                        string accountName = chartOfAccounts.Tables[coa].Rows[i]["Name"].ToString();

                        accounts[i] = accountCode + " " + accountName;
                    }

                    // return all account names/codes
                    return accounts;
                }
                else 
                { 
                    return new string[0]; 
                }

            }
        }

        private DataSetCollection categorizeRows(string sortColumn1, string sortColumn2, string sortColumn3, DataSet dataSet)
        {
            
            // Create the query.
            var transaction =
                from DataRow row in dataSet.Tables["Allocation"].Rows
                orderby row[sortColumn1] ascending, row[sortColumn2] ascending, row[sortColumn3] ascending
                group row by row[sortColumn1] into newGroup
                orderby newGroup.Key
                select newGroup;


            // create a temporary dataset
            DataSetCollection dataSetArray = new DataSetCollection();

            foreach (var rowGroup in transaction)
            {
                DataSet tempDS = dataSet.Clone();
                tempDS.ExtendedProperties["user"] = rowGroup.Key.ToString();
                
                foreach (var row in rowGroup)
                {
                    tempDS.Tables["Allocation"].ImportRow(row);
                    
                    foreach(DataRow sRow in dataSet.Tables["Split"].Rows)
                    {
                        //TODO: Does this actually do anything?
                        if(sRow["ChargeID"] == ((DataRow)row)["ChargeID"])
                        {
                            tempDS.Tables["Split"].ImportRow(sRow);
                        }
                    }
                        
                }

                dataSetArray.Add(tempDS);
            }

            return dataSetArray;
            
        }


        private DataSet resolveSplits(DataSet thisDS)
        {

            DataTable allocation = thisDS.Tables["Allocation"];
            DataTable split = thisDS.Tables["Split"];

            DataSet newAllocation = thisDS.Clone();
            newAllocation.Relations.Clear();
            newAllocation.EnforceConstraints = false;
            //newAllocation.Tables["Allocation"].PrimaryKey = null;
            //newAllocation.Tables["Split"].PrimaryKey = null;
            //newAllocation.Tables["Allocation"].Constraints.Clear();
            //newAllocation.Tables["Split"].Constraints.Clear();
            
            var query1 = from DataRow o in allocation.Rows
                        where o["Company"].ToString() != "Split"
                        select new
                        {
                            ChargeID = o["ChargeID"],
                            Cardholder_Name = o["Cardholder Name"],
                            Process_Date = o["Process Date"],
                            Merchant_Name_Location = o["Merchant Name/Location"],
                            Amount = o["Amount"],
                            Company = o["Company"],
                            Account = o["Account"],
                            Description = o["Description"]
                        };
            //TODO: Clean this up? Use OO?
            foreach (var row in query1)
            {
                DataRow dr = newAllocation.Tables["Allocation"].NewRow();
                dr["ChargeID"] = row.ChargeID;
                dr["Cardholder Name"] = row.Cardholder_Name;
                dr["Process Date"] = row.Process_Date;
                dr["Merchant Name/Location"] = row.Merchant_Name_Location;
                dr["Amount"] = row.Amount;  
                dr["Company"] = row.Company;
                dr["Account"] = row.Account;
                dr["Description"] = row.Description;
                newAllocation.Tables["Allocation"].Rows.Add(dr);
            }

            var query = from DataRow o in allocation.Rows
                        where o["Company"].ToString() == "Split"
                        join DataRow ol in split.Rows on o["ChargeID"] equals ol["ChargeID"]
                        //where ol["Company"].ToString() == company
                        select new    
                        {
                            ChargeID = o["ChargeID"],
                            Cardholder_Name = o["Cardholder Name"],
                            Process_Date = o["Process Date"],
                            Merchant_Name_Location = o["Merchant Name/Location"],
                            Company = ol["Company"],
                            Account = ol["Account"],
                            Amount = ol["Amount"],
                            Description = o["Description"]
                        };

            foreach (var row in query)
            {
                DataRow dr = newAllocation.Tables["Allocation"].NewRow();
                dr["ChargeID"] = row.ChargeID;
                dr["Cardholder Name"] = row.Cardholder_Name;
                dr["Process Date"] = row.Process_Date;
                dr["Merchant Name/Location"] = row.Merchant_Name_Location;
                dr["Amount"] = row.Amount;
                dr["Company"] = row.Company;
                dr["Account"] = row.Account;
                dr["Description"] = row.Description;
                newAllocation.Tables["Allocation"].Rows.Add(dr);
            }
            
            return newAllocation;
        }


        public void saveSplitFile(string savePath, DataSetCollection dsToSave)
        {
            // make sure the last character of the path is a slash
            if(!savePath.EndsWith("\\"))
            {
                savePath += "\\";
            }

            // for each table
            foreach (DataSet ds in dsToSave)
            {
                // export the data to an XML file, with schema included for datatyping
                ds.WriteXml(savePath + ds.ExtendedProperties["user"] + ".xml",XmlWriteMode.WriteSchema);
            }

        }

        public void openXML(string fileName)
        {
            
            currentDataSet = new DataSet("Allocations");
            currentDataSet.ReadXml(fileName);
          //  currentDataSet.Tables[0].TableName = "Allocation";

            initDataSet(currentDataSet);

            form.setDataSource(currentDataSet);

            currentDataSet.AcceptChanges();

        }

        public void saveXML(string fileName)
        {
            currentDataSet.AcceptChanges();
            currentDataSet.WriteXml(fileName, XmlWriteMode.WriteSchema);
        }

        public void combineXML(string[] filenames)
        {
            // create a temporary dataset
            DataSetCollection multiSetXml = new DataSetCollection();
            
            // load the xml files into the dataset

            for (int i = 0; i < filenames.Length;i++ )
            {
                DataSet tempDS = new DataSet();
                tempDS.ReadXml(filenames[i]);
                multiSetXml.Add(tempDS);
            }

            // combine the tables into one big table
            currentDataSet = combineDataSets(multiSetXml);

            // display that table in the main window for review
            form.setDataSource(currentDataSet);
            
        }

        private DataSet combineDataSets(DataSetCollection multiSetColl)
        {
            // for each dataset
            for(int i=1;i<multiSetColl.Count;i++)
            {
                multiSetColl[0].Tables["Allocation"].Merge(
                    multiSetColl[i].Tables["Allocation"]);
                multiSetColl[0].Tables["Split"].Merge(
                    multiSetColl[i].Tables["Split"]);
            }

            return multiSetColl[0];
        }

        public void splitRow(DataRow row, DataSet ds, Form form)
        {

               

/*            // create the Split
            //DataGridViewRow[] rowColl = new DataGridViewRow[numSplit];
            string uniqueID = row["ChargeID"].ToString();
           
            

            
            for (int i = 0; i < numSplit; i++)
            {
                // create new rows in the table
                DataRow newRow = dataTable.NewRow();
                // copy their contents from the master row
                newRow.ItemArray = row.Row.ItemArray;
                // change its uniqueID to xxxx-i where i is the incrementer
                newRow["ChargeID"] = uniqueID + "-" + i.ToString();
                // insert the row at (the location of the main row) plus one, plus the increment
                // (this way 3 rows are added in order from Main, 1, 2, 3.)
                dataTable.Rows.InsertAt(newRow,dataTable.Rows.IndexOf(row.Row)+1+i);
            }

            */
        }

        public void addRow()
        {
            // add new row
            RowEditor re = new RowEditor(this);
            re.ShowDialog(form);
        }
        public void addRow(string name, string merchant, string amount, string date)
        {
            // add row to dataset
            DataRow newRow = currentDataSet.Tables["Allocation"].NewRow();
            newRow["Cardholder Name"] = name;
            newRow["Merchant Name/Location"] = merchant;
            newRow["Amount"] = amount;
            newRow["Process Date"] = date;
            newRow["ChargeID"] = getUniqueIndex().ToString();
            currentDataSet.Tables["Allocation"].Rows.Add(newRow);
        
        }


        public void printDataGrid()
        {
            if (currentDataSet != null)
            {
                currentDataSet.AcceptChanges();

                string containsNull = validateRows(currentDataSet);

                if (containsNull != null)
                {
                    // Warn about empty rows
                    MessageBox.Show(form, "Not all Company and Account fields are accurate.\r\n\r\nCheck that the Company and Account fields in the \r\nhighlighted row are accurate before submitting." 
                        , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form.highlightRow(containsNull);
                }
                
                DataSetCollection dsColl = new DataSetCollection();
                dsColl.Add(currentDataSet);

                // create a viewer window, populate the data, and display it.
                ReportPrinter rp = new ReportPrinter(this, dsColl, "Trillium_CC_Allocation.report1.xsl", null, 1);
                rp.ShowDialog(form);
                
            }
            else
            {
                MessageBox.Show(form, "Open a file before trying to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string validateRows(DataSet ds)
        {
            string containsNull = null;
            
            // check all transactions
            foreach (DataRow row in ds.Tables["Allocation"].Rows)
            {
                containsNull = validateDataRow(containsNull, row);
            }

            // check all splits
            foreach (DataRow row in ds.Tables["Split"].Rows)
            {
                containsNull = validateDataRow(containsNull, row);
            }

            return containsNull;            

        }

        private string validateDataRow(string containsNull, DataRow row)
        {
            string companyName = row["Company"].ToString();

            DataRow[] numMatches = chartOfAccounts.Tables["Companies"].Select
                ("Company = '" + companyName + "'");

            // if the company isn't Split and couldn't be found, or the account field is blank
            if ((companyName != "Split" && numMatches.Length < 1)
                || row["Account"].ToString().Length < 1)
            {
                containsNull = row["ChargeID"].ToString();
            }
            return containsNull;
        }

        public void printReport2()
        {
            if (currentDataSet != null)
            {
                currentDataSet.AcceptChanges();

                string containsNull = validateRows(currentDataSet);

                if (containsNull != null)
                {
                    // don't categorizeRows without filling in info.
                    MessageBox.Show(form, "Check that the Company and Account fields in the highlighted row are accurate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    form.highlightRow(containsNull);
                }
                else
                {
                    //TODO: What is this for?
                    currentDataSet.Tables[0].Columns["Company"].DataType = Type.GetType("System.String");
                    //DataRow[] rowsCopy = new DataRow[currentDataSet.Tables[0].Rows.Count];
                    //currentDataSet.Tables[0].Rows.CopyTo(rowsCopy, 0);

                    // resolve Split transactions into their splits
                    DataSet tempDS = resolveSplits(currentDataSet);

                    //tempdataset =
                    DataSetCollection dsColl = categorizeRows("Company", "Account", "Process Date", tempDS);  //currentDataSet

                    //initDataSet(tempDataSet);

                    // create a viewer window, populate the data, and display it.
                    ReportPrinter rp = new ReportPrinter(this, dsColl, "Trillium_CC_Allocation.report2.xsl", chartOfAccounts.Tables["Companies"], 2);
                    rp.ShowDialog(form);
                }
            }
            else
            {
                MessageBox.Show(form, "Combine XML files before trying to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private DataSet createAudit(string sortColumn, DataSet dataSet)
        {

            // Create the query.
            var transaction =
                from DataRow row in dataSet.Tables["Allocation"].Rows
                orderby row[sortColumn] ascending
                select row;


            DataSet tempDS = dataSet.Clone();
            tempDS.ExtendedProperties["user"] = sortColumn;

            foreach (var row in transaction)
            {
                tempDS.Tables["Allocation"].ImportRow(row);

                foreach (DataRow sRow in dataSet.Tables["Split"].Rows)
                {
                    //TODO: Does this actually do anything?
                    if (sRow["ChargeID"] == ((DataRow)row)["ChargeID"])
                    {
                        tempDS.Tables["Split"].ImportRow(sRow);
                    }
                }
                // try it but it needs to organize splits by company too (no split total)
            }

            return tempDS;
        
        }

        public void printReport3()
        {
            if (currentDataSet != null)
            {
                currentDataSet.AcceptChanges();

                string containsNull = validateRows(currentDataSet);

                if (containsNull != null)
                {
                    // don't categorizeRows without filling in info.
                    MessageBox.Show(form, "Check that the Company and Account fields in the highlighted row are accurate." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    form.highlightRow(containsNull);
                }
                else
                {
                    //TODO: What is this for?
                    //currentDataSet.Tables[0].Columns["Company"].DataType = Type.GetType("System.String");
                    //DataRow[] rowsCopy = new DataRow[currentDataSet.Tables[0].Rows.Count];
                    //currentDataSet.Tables[0].Rows.CopyTo(rowsCopy, 0);

                    // resolve Split transactions into their splits
                    DataSet tempDS = resolveSplits(currentDataSet);

                    //tempdataset =
                    //// create a temporary dataset
//                    DataSetCollection dataSetArray = new DataSetCollection();

                    DataSetCollection dsColl = new DataSetCollection();
                    dsColl.Add(createAudit("Company", tempDS));
                    dsColl.Add(createAudit("Cardholder Name", tempDS));

                    //initDataSet(tempDataSet);

                    // create a viewer window, populate the data, and display it.
                    ReportPrinter rp = new ReportPrinter(this, dsColl, "Trillium_CC_Allocation.report3.xsl",
                        "Trillium_CC_Allocation.report3a.xsl", chartOfAccounts.Tables["Companies"], 3);
                    rp.ShowDialog(form);
                }
            }
            else
            {
                MessageBox.Show(form, "Combine XML files before trying to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




    }
}
