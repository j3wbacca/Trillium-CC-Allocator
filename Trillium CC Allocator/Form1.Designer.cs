namespace Trillium_CC_Allocation
{
    partial class Form1
    {

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.floatingCombo = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.adminToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.btnSplit = new System.Windows.Forms.ToolStripButton();
            this.btnCombineXML = new System.Windows.Forms.ToolStripButton();
            this.btnPrint2 = new System.Windows.Forms.ToolStripButton();
            this.btnPrint3 = new System.Windows.Forms.ToolStripButton();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteRow = new System.Windows.Forms.ToolStripButton();
            this.userToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSplitTrans = new System.Windows.Forms.ToolStripButton();
            this.btnUnSplit = new System.Windows.Forms.ToolStripButton();
            this.btnViewSwap = new System.Windows.Forms.ToolStripButton();
            this.btnRemSplit = new System.Windows.Forms.ToolStripButton();
            this.formMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.adminToolStrip.SuspendLayout();
            this.userToolStrip.SuspendLayout();
            this.formMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(744, 492);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DataMemberChanged += new System.EventHandler(this.dataGridView1_DataMemberChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            // 
            // floatingCombo
            // 
            this.floatingCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.floatingCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.floatingCombo.FormattingEnabled = true;
            this.floatingCombo.Location = new System.Drawing.Point(3, 3);
            this.floatingCombo.MaxDropDownItems = 25;
            this.floatingCombo.Name = "floatingCombo";
            this.floatingCombo.Size = new System.Drawing.Size(178, 21);
            this.floatingCombo.TabIndex = 1;
            this.floatingCombo.Visible = false;
            this.floatingCombo.LostFocus += new System.EventHandler(this.floatingCombo_LostFocus);
            this.floatingCombo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.floatingCombo_PreviewKeyDown);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(3, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(21, 21);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = ">";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Comma Separated Values File (CSV)|*.csv|All files|*.*";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.closeButton);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.floatingCombo);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.previewPanel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(744, 492);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(744, 514);
            this.toolStripContainer1.TabIndex = 10;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.adminToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.userToolStrip);
            this.toolStripContainer1.TopToolStripPanel.MaximumSize = new System.Drawing.Size(0, 22);
            // 
            // previewPanel
            // 
            this.previewPanel.Controls.Add(this.dataGridView2);
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.previewPanel.Location = new System.Drawing.Point(0, 438);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(744, 54);
            this.previewPanel.TabIndex = 2;
            this.previewPanel.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.Size = new System.Drawing.Size(744, 54);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.TabStop = false;
            // 
            // adminToolStrip
            // 
            this.adminToolStrip.BackColor = System.Drawing.Color.Khaki;
            this.adminToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.adminToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.adminToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.btnSplit,
            this.btnCombineXML,
            this.btnPrint2,
            this.btnPrint3,
            this.btnAddRow,
            this.btnDeleteRow});
            this.adminToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.adminToolStrip.Location = new System.Drawing.Point(176, 0);
            this.adminToolStrip.Name = "adminToolStrip";
            this.adminToolStrip.Size = new System.Drawing.Size(550, 22);
            this.adminToolStrip.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(80, 19);
            this.btnImport.Text = "Import CSV...";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnSplit.Image")));
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(67, 19);
            this.btnSplit.Text = "Split CSV...";
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnCombineXML
            // 
            this.btnCombineXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCombineXML.Image = ((System.Drawing.Image)(resources.GetObject("btnCombineXML.Image")));
            this.btnCombineXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCombineXML.Name = "btnCombineXML";
            this.btnCombineXML.Size = new System.Drawing.Size(96, 19);
            this.btnCombineXML.Text = "Combine XML...";
            this.btnCombineXML.Click += new System.EventHandler(this.btnCombineXML_Click);
            // 
            // btnPrint2
            // 
            this.btnPrint2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint2.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint2.Image")));
            this.btnPrint2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(91, 19);
            this.btnPrint2.Text = "Print Invoices...";
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // btnPrint3
            // 
            this.btnPrint3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint3.Name = "btnPrint3";
            this.btnPrint3.Size = new System.Drawing.Size(77, 19);
            this.btnPrint3.Text = "Print Audit...";
            this.btnPrint3.Click += new System.EventHandler(this.btnPrint3_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(68, 19);
            this.btnAddRow.Text = "Add Row...";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRow.Image")));
            this.btnDeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(70, 19);
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // userToolStrip
            // 
            this.userToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.userToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.userToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnPrint,
            this.btnSplitTrans,
            this.btnUnSplit,
            this.btnViewSwap,
            this.btnRemSplit});
            this.userToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.userToolStrip.Location = new System.Drawing.Point(3, 0);
            this.userToolStrip.Name = "userToolStrip";
            this.userToolStrip.Size = new System.Drawing.Size(173, 22);
            this.userToolStrip.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(49, 19);
            this.btnOpen.Text = "Open...";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 19);
            this.btnSave.Text = "Save...";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(45, 19);
            this.btnPrint.Text = "Print...";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // btnSplitTrans
            // 
            this.btnSplitTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSplitTrans.Image = ((System.Drawing.Image)(resources.GetObject("btnSplitTrans.Image")));
            this.btnSplitTrans.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplitTrans.Name = "btnSplitTrans";
            this.btnSplitTrans.Size = new System.Drawing.Size(34, 19);
            this.btnSplitTrans.Text = "Split";
            this.btnSplitTrans.Click += new System.EventHandler(this.btnSplitTrans_Click);
            // 
            // btnUnSplit
            // 
            this.btnUnSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUnSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnUnSplit.Image")));
            this.btnUnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnSplit.Name = "btnUnSplit";
            this.btnUnSplit.Size = new System.Drawing.Size(54, 19);
            this.btnUnSplit.Text = "Un-Split";
            this.btnUnSplit.Visible = false;
            this.btnUnSplit.Click += new System.EventHandler(this.btnUnSplit_Click);
            // 
            // btnViewSwap
            // 
            this.btnViewSwap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewSwap.Image = ((System.Drawing.Image)(resources.GetObject("btnViewSwap.Image")));
            this.btnViewSwap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewSwap.Name = "btnViewSwap";
            this.btnViewSwap.Size = new System.Drawing.Size(67, 19);
            this.btnViewSwap.Text = "View Splits";
            this.btnViewSwap.Visible = false;
            this.btnViewSwap.Click += new System.EventHandler(this.btnViewSwap_Click);
            // 
            // btnRemSplit
            // 
            this.btnRemSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnRemSplit.Image")));
            this.btnRemSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemSplit.Name = "btnRemSplit";
            this.btnRemSplit.Size = new System.Drawing.Size(80, 19);
            this.btnRemSplit.Text = "Remove Split";
            this.btnRemSplit.Visible = false;
            this.btnRemSplit.Click += new System.EventHandler(this.btnRemSplit_Click);
            // 
            // formMenu
            // 
            this.formMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.formMenu.Name = "formMenu";
            this.formMenu.Size = new System.Drawing.Size(97, 26);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 514);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Credit Card Allocator";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.previewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.adminToolStrip.ResumeLayout(false);
            this.adminToolStrip.PerformLayout();
            this.userToolStrip.ResumeLayout(false);
            this.userToolStrip.PerformLayout();
            this.formMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox floatingCombo;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip userToolStrip;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnPrint;
        public System.Windows.Forms.ToolStrip adminToolStrip;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripButton btnSplit;
        private System.Windows.Forms.ToolStripButton btnCombineXML;
        private System.Windows.Forms.ToolStripButton btnPrint2;
        private System.Windows.Forms.ToolStripButton btnSplitTrans;
        private System.Windows.Forms.ToolStripButton btnViewSwap;
        private System.Windows.Forms.ToolStripButton btnUnSplit;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripButton btnRemSplit;
        private System.Windows.Forms.ToolStripButton btnDeleteRow;
        private System.Windows.Forms.ToolStripButton btnPrint3;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ContextMenuStrip formMenu;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.ComponentModel.IContainer components;

    }
}

