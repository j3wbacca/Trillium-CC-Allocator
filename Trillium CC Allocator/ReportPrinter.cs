using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using System.Reflection;

namespace Trillium_CC_Allocation
{
    public partial class ReportPrinter : Form
    {
        // attributes
        private DataSetCollection dsArray;
        private Controller con;
        private Stream xslAssemblyStream;
        private Stream xslAssemblyStream2;
        private DataTable chartOfAccounts;
        private PrintSettings printSettings;
        private Timer printTimer;
        private int reportNumber;
      
        public ReportPrinter(Controller myCon, DataSetCollection dsArray, string xslAssemblyPath, DataTable chartOfAccounts, int reportNumber)
        {
            InitializeComponent();

            this.reportNumber = reportNumber;
            this.dsArray = dsArray;
            this.con = myCon;
            this.chartOfAccounts = chartOfAccounts;

            // this: creates an XmlReader; from this assembly's manifest; using the supplied stylesheet.
            // (should be done here to minimize IO during loop)
            this.xslAssemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(xslAssemblyPath);
            this.xslAssemblyStream2 = null; // not used in this constructor
            
        }
        public ReportPrinter(Controller myCon, DataSetCollection dsArray, string xslAssemblyPath, string xslAssemblyPath2, DataTable chartOfAccounts, int reportNumber)
        {
            InitializeComponent();

            this.reportNumber = reportNumber;
            this.dsArray = dsArray;
            this.con = myCon;
            this.chartOfAccounts = chartOfAccounts;

            // this: creates an XmlReader; from this assembly's manifest; using the supplied stylesheet.
            // (should be done here to minimize IO during loop)
            this.xslAssemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(xslAssemblyPath);
            this.xslAssemblyStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(xslAssemblyPath2);

        }

        private void ReportPrinter_Load(object sender, EventArgs e)
        {
            this.printTimer = new Timer();
            this.printTimer.Tick += new EventHandler(printTimer_Tick);

            // load each sheet into a separate item in the dropdown list
            foreach (DataSet ds in dsArray)
            {
                string username = "";

                try
                {
                    username = ds.ExtendedProperties["user"].ToString();
                }
                catch 
                {
                    ds.ExtendedProperties["user"] = "Error: DataSet User is Blank";
                    username = ds.ExtendedProperties["user"].ToString();
                }
                
                tableSelector.Items.Add(username);
             
            }
            tableSelector.SelectedIndex = 0;


            // Hide print all if there's only one item to print.
            if (dsArray.Count <= 1)
            {
                btnPrintAll.Visible = false;
            }

            // Hide Statement Date selector if this isn't an invoice
            if (reportNumber != 2)
            {
                statementDate.Visible = false;
                invoiceDate.Visible = false;
                txtPayeeName.Visible = false;
            }
            

            // set up the IE page settings
            printSettings = new PrintSettings();
            pageSetup(false, ref printSettings);
        }

       


        void ReportPrinter_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // reset the IE page settings
            pageSetup(true, ref printSettings);
        }

        private void statementDate_ValueChanged(object sender, EventArgs e)
        {
            tableSelector_SelectedIndexChanged(sender, e);
        }

        private void invoiceDate_ValueChanged(object sender, EventArgs e)
        {
            tableSelector_SelectedIndexChanged(sender, e);
        }

        void txtPayeeName_MouseHover(object sender, System.EventArgs e)
        {
            txtPayeeNameTip.Show("Payee Name", txtPayeeName);
        }


        void txtPayeeName_Leave(object sender, System.EventArgs e)
        {
            tableSelector_SelectedIndexChanged(sender, e);
        }


        void tableSelector_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string setName = tableSelector.SelectedItem.ToString();
            DataSet tempDS = dsArray[setName];

            
            // Add StatementDate to the DS
            DataTable statementInfo = tempDS.Tables["StatementInfo"];

            // remove any existing StatementInfo data
            if (statementInfo != null) { tempDS.Tables.Remove("StatementInfo"); }

            DataTable newTable = new DataTable("StatementInfo");
            newTable.Columns.Add("StatementDate", Type.GetType("System.String"));
            newTable.Columns.Add("InvoiceDate", Type.GetType("System.String"));
            newTable.Columns.Add("PayeeName", Type.GetType("System.String"));
           
            DataRow newRow = newTable.NewRow();
            newRow["StatementDate"] = statementDate.Value.ToShortDateString();
            newRow["InvoiceDate"] = invoiceDate.Value.ToShortDateString();
            newRow["PayeeName"] = txtPayeeName.Text.Trim();
            
            newTable.Rows.Add(newRow);
            tempDS.Tables.Add(newTable);
        
            

            if (setName == "Company")
            {
                webBrowser1.DocumentStream = TransformXML(tempDS, xslAssemblyStream);
            }
            else if (setName == "Cardholder Name" && xslAssemblyStream2 != null)
            {
                webBrowser1.DocumentStream = TransformXML(tempDS, xslAssemblyStream2);
            }
            else  // do this normally
            {
                // only add the accounts to the data if it's specified.
                if (chartOfAccounts != null)
                {
                    DataTable tempDT = chartOfAccounts.Clone();
                    DataRow[] tempDR = chartOfAccounts.Select
                        ("Company = '" + setName + "'");
                    if (tempDR.Length > 0)
                    {
                        tempDT.ImportRow(tempDR[0]);

                        if (tempDS.Tables.Contains(tempDT.TableName))
                        {
                            tempDS.Tables.Remove(tempDT.TableName);
                        }

                        tempDS.Tables.Add(tempDT);
                    }
                    else
                    {
                        MessageBox.Show(this, "The company name '" + setName + "' was not found. Check that all company fields are filled out and correct.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                webBrowser1.DocumentStream = TransformXML(tempDS, xslAssemblyStream);
            }
            
            
            
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            tableSelector_SelectedIndexChanged(sender, e);

            try { webBrowser1.ShowPrintDialog(); }
            catch
            {
                if (MessageBox.Show(this, "Print to your default printer, with the default settings?",
                      "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    webBrowser1.Print();
                }
            }
           
        }



        #region Functions
        private void setRegValue(Microsoft.Win32.RegistryKey key, string keyName, string value)
        {
            if (value == null)
            {
                key.DeleteValue(keyName);
            }
            else
            {
                key.SetValue(keyName, value);
            }
        }
        private string getRegValue(Microsoft.Win32.RegistryKey key, string keyName)
        {
            try
            {
                return key.GetValue(keyName).ToString();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Not Set: Reads page setup registry keys and clears their values. Stores old values in arguments.
        /// Set: Sets the values back to the arguments.
        /// </summary>
        private void pageSetup(bool set, ref PrintSettings printSettings)
        {
            Microsoft.Win32.RegistryKey pageKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
            Microsoft.Win32.RegistryKey mainKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\Main", true);

            if (pageKey != null && mainKey != null)
            {
                // set back to original settings (as defined)
                if (set)
                {
                    setRegValue(pageKey, "header", printSettings.Header);
                    setRegValue(pageKey, "footer", printSettings.Footer);
                    setRegValue(mainKey, "Print_Background", printSettings.PrintBG);
                    setRegValue(pageKey, "margin_bottom", printSettings.BottomMargin);
                    setRegValue(pageKey, "margin_top", printSettings.TopMargin);
                    setRegValue(pageKey, "margin_left", printSettings.LeftMargin);
                    setRegValue(pageKey, "margin_right", printSettings.RightMargin);

                }
                else  // grab current settings from reg, store in args, set to desired.
                {
                    printSettings.Header = getRegValue(pageKey, "header");
                    printSettings.Footer = getRegValue(pageKey, "footer");
                    printSettings.BottomMargin = getRegValue(pageKey, "margin_bottom");
                    printSettings.TopMargin = getRegValue(pageKey, "margin_top");
                    printSettings.LeftMargin = getRegValue(pageKey, "margin_left");
                    printSettings.RightMargin = getRegValue(pageKey, "margin_right");
                    printSettings.PrintBG = getRegValue(mainKey, "Print_Background");
                    
                    setRegValue(pageKey, "header", " ");
                    setRegValue(pageKey, "footer",  " ");
                    setRegValue(pageKey, "margin_bottom", "0.250000");
                    setRegValue(pageKey, "margin_top", "0.250000");
                    setRegValue(pageKey, "margin_left", "0.250000");
                    setRegValue(pageKey, "margin_right", "0.250000");
                    setRegValue(mainKey, "Print_Background", "yes");
                }

                pageKey.Close();
                mainKey.Close();
            }
            
            System.Threading.Thread.Sleep(50);
        }
        
        /// <summary>
        /// Transforms a DataSet into HTML using the supplied XML StyleSheet.
        /// Returns a Stream representing the HTML document's text.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="xslStream">Manifest stream of the XSL file (i.e. "MyNameSpace.myfile.xsl")</param>
        private Stream TransformXML(DataSet dataSet, Stream xslStream)
        {
            /**** XML Loading ****/
            XmlDocument xld = new XmlDocument();
            // create an input "file" in memory
            System.IO.MemoryStream inputStream = new MemoryStream();
            // write the datasource to the "file"
            dataSet.WriteXml(inputStream,XmlWriteMode.WriteSchema);
         //   dataSet.WriteXml("output.xml", XmlWriteMode.WriteSchema);
            // reset the stream to beginning
            inputStream.Position = 0;
            // load the file into an xmldocument
            xld.Load(XmlReader.Create(inputStream));
            
            /**** XSL Loading ****/
            xslStream.Position = 0;
            XmlReader xmlr = XmlReader.Create(xslStream);
            
            /**** Transformer Creation ****/
            // this creates the transformer
            XslTransform transform = new XslTransform();
            // this loads the stylesheet into the transformer
            transform.Load(xmlr);
            // create an output "file" in memory
            System.IO.MemoryStream outputStream = new MemoryStream();
            XmlWriter output = XmlWriter.Create(outputStream);
            
            /**** Transformation ****/
            // transform the XML Document using the stylesheet
            transform.Transform(xld, null, output);
            // reset the virtual "file" to the beginning
            outputStream.Position = 0;
            // and load it into the web browser.
            return outputStream;
        }
        #endregion

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            tableSelector_SelectedIndexChanged(sender, e);

            if (MessageBox.Show(this, "Print all invoices to your default printer, with the default settings?",
                       "Print All", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tableSelector.SelectedIndex = 0;
                printTimer.Interval = 1000;
                printTimer.Start();
                printTimer.Tag = "print";

            }
            else
            {
                // do nothing.
            }
        }
        void printTimer_Tick(object sender, EventArgs e)
        {
            if (printTimer.Tag.ToString() == "select")
            {
                if (tableSelector.SelectedIndex < tableSelector.Items.Count - 1)
                {
                    tableSelector.SelectedIndex += 1;
                    printTimer.Tag = "print";
                    
                }
                else
                {
                    printTimer.Stop();
                }
            }
            else if (printTimer.Tag.ToString() == "print")
            {
                webBrowser1.Print();
                printTimer.Tag = "select";
               
            }
            else
            {
                //TODO: error
            }
        }


        

       

    }
}
