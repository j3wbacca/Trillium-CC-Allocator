namespace Trillium_CC_Allocation
{
    partial class ReportPrinter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPrinter));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnPrintAll = new System.Windows.Forms.ToolStripButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tableSelector = new System.Windows.Forms.ComboBox();
            this.statementDate = new System.Windows.Forms.DateTimePicker();
            this.invoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtPayeeName = new System.Windows.Forms.TextBox();
            this.txtPayeeNameTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.btnPrintAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(45, 22);
            this.btnPrint.Text = "Print...";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrintAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrintAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAll.Image")));
            this.btnPrintAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(59, 22);
            this.btnPrintAll.Text = "Print All...";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(792, 441);
            this.webBrowser1.TabIndex = 2;
            // 
            // tableSelector
            // 
            this.tableSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableSelector.DropDownWidth = 160;
            this.tableSelector.FormattingEnabled = true;
            this.tableSelector.Location = new System.Drawing.Point(630, 1);
            this.tableSelector.Name = "tableSelector";
            this.tableSelector.Size = new System.Drawing.Size(160, 21);
            this.tableSelector.TabIndex = 3;
            this.tableSelector.SelectedIndexChanged += new System.EventHandler(this.tableSelector_SelectedIndexChanged);
            // 
            // statementDate
            // 
            this.statementDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statementDate.CustomFormat = "\'Statement Date: \'M\'/\'d\'/\'yyyy";
            this.statementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.statementDate.Location = new System.Drawing.Point(455, 1);
            this.statementDate.Name = "statementDate";
            this.statementDate.Size = new System.Drawing.Size(169, 20);
            this.statementDate.TabIndex = 4;
            this.statementDate.ValueChanged += new System.EventHandler(this.statementDate_ValueChanged);
            // 
            // invoiceDate
            // 
            this.invoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceDate.CustomFormat = "\'Invoice Date: \'M\'/\'d\'/\'yyyy";
            this.invoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.invoiceDate.Location = new System.Drawing.Point(293, 1);
            this.invoiceDate.Name = "invoiceDate";
            this.invoiceDate.Size = new System.Drawing.Size(156, 20);
            this.invoiceDate.TabIndex = 5;
            this.invoiceDate.ValueChanged += new System.EventHandler(this.invoiceDate_ValueChanged);
            // 
            // txtPayeeName
            // 
            this.txtPayeeName.Location = new System.Drawing.Point(151, 1);
            this.txtPayeeName.Name = "txtPayeeName";
            this.txtPayeeName.Size = new System.Drawing.Size(136, 20);
            this.txtPayeeName.TabIndex = 6;
            this.txtPayeeName.Text = "Avenue Communities, LLC";
            this.txtPayeeName.Leave += new System.EventHandler(this.txtPayeeName_Leave);
            this.txtPayeeName.MouseHover += new System.EventHandler(this.txtPayeeName_MouseHover);
            // 
            // txtPayeeNameTip
            // 
            this.txtPayeeNameTip.AutoPopDelay = 5000;
            this.txtPayeeNameTip.InitialDelay = 250;
            this.txtPayeeNameTip.ReshowDelay = 300;
            // 
            // ReportPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 466);
            this.Controls.Add(this.txtPayeeName);
            this.Controls.Add(this.invoiceDate);
            this.Controls.Add(this.statementDate);
            this.Controls.Add(this.tableSelector);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportPrinter";
            this.Text = "Report Printer";
            this.Load += new System.EventHandler(this.ReportPrinter_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportPrinter_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox tableSelector;
        private System.Windows.Forms.ToolStripButton btnPrintAll;
        private System.Windows.Forms.DateTimePicker statementDate;
        private System.Windows.Forms.DateTimePicker invoiceDate;
        private System.Windows.Forms.TextBox txtPayeeName;
        private System.Windows.Forms.ToolTip txtPayeeNameTip;
    }
}