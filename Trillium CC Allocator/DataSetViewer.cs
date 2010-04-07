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
    public partial class DataSetViewer : Form
    {
        // attributes
        private DataSetCollection dsArray;
        private Controller con;

        public DataSetViewer(Controller myCon, DataSetCollection ds)
        {
            InitializeComponent();
            
            this.dsArray = ds;
            this.con = myCon;
        }

        private void DataSetViewer_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dsArray[0];
            
            foreach (DataSet ds in dsArray)
            {
                tableSelector.Items.Add(ds.ExtendedProperties["user"]);
            }

        }

        private void tableSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string member = tableSelector.Items[tableSelector.SelectedIndex].ToString();
            
            dataGridView1.DataSource = dsArray[member].Tables["Allocation"];
            dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "C";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                con.saveSplitFile(folderBrowserDialog1.SelectedPath, dsArray);
                MessageBox.Show(this, "XML files saved to " + folderBrowserDialog1.SelectedPath, "CSV Splitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }


    }
}
