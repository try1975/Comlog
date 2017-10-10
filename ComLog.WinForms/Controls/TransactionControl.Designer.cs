namespace ComLog.WinForms.Controls
{
    partial class TransactionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFromTo = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCharges = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDebits = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCredits = new System.Windows.Forms.TextBox();
            this.pnlTransactionType = new System.Windows.Forms.Panel();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlNotClosedAccounts = new System.Windows.Forms.Panel();
            this.cmbNotClosedAccounts = new System.Windows.Forms.ComboBox();
            this.labelNotClosedAccount = new System.Windows.Forms.Label();
            this.pnlAllAccount = new System.Windows.Forms.Panel();
            this.cmbAllAccount = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.pnlTransactionDate = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.pnlId = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvItems = new ADGV.AdvancedDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSumDebits = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSumCredits = new System.Windows.Forms.Label();
            this.lblRecCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnLoadCashUpdateXls = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDateFromSubtract = new System.Windows.Forms.Button();
            this.btnDateFromAdd = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlDetails.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlTransactionType.SuspendLayout();
            this.pnlNotClosedAccounts.SuspendLayout();
            this.pnlAllAccount.SuspendLayout();
            this.pnlTransactionDate.SuspendLayout();
            this.pnlId.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.pnlFields);
            this.pnlDetails.Controls.Add(this.pnlButtons);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(751, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(398, 514);
            this.pnlDetails.TabIndex = 6;
            // 
            // pnlFields
            // 
            this.pnlFields.Controls.Add(this.panel8);
            this.pnlFields.Controls.Add(this.panel7);
            this.pnlFields.Controls.Add(this.panel6);
            this.pnlFields.Controls.Add(this.panel5);
            this.pnlFields.Controls.Add(this.panel4);
            this.pnlFields.Controls.Add(this.panel3);
            this.pnlFields.Controls.Add(this.pnlTransactionType);
            this.pnlFields.Controls.Add(this.pnlNotClosedAccounts);
            this.pnlFields.Controls.Add(this.pnlAllAccount);
            this.pnlFields.Controls.Add(this.pnlTransactionDate);
            this.pnlFields.Controls.Add(this.pnlId);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Location = new System.Drawing.Point(0, 41);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(398, 473);
            this.pnlFields.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.tbReport);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 333);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(398, 33);
            this.panel8.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Report";
            // 
            // tbReport
            // 
            this.tbReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReport.Enabled = false;
            this.tbReport.Location = new System.Drawing.Point(97, 6);
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(285, 20);
            this.tbReport.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.tbDescription);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 300);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(398, 33);
            this.panel7.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Enabled = false;
            this.tbDescription.Location = new System.Drawing.Point(97, 6);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(285, 20);
            this.tbDescription.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.tbFromTo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 267);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(398, 33);
            this.panel6.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "FromTo";
            // 
            // tbFromTo
            // 
            this.tbFromTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFromTo.Enabled = false;
            this.tbFromTo.Location = new System.Drawing.Point(97, 6);
            this.tbFromTo.Name = "tbFromTo";
            this.tbFromTo.Size = new System.Drawing.Size(285, 20);
            this.tbFromTo.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.tbCharges);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 234);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(398, 33);
            this.panel5.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Charges";
            // 
            // tbCharges
            // 
            this.tbCharges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCharges.Enabled = false;
            this.tbCharges.Location = new System.Drawing.Point(97, 6);
            this.tbCharges.Name = "tbCharges";
            this.tbCharges.Size = new System.Drawing.Size(285, 20);
            this.tbCharges.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.tbDebits);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 201);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(398, 33);
            this.panel4.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Debits";
            // 
            // tbDebits
            // 
            this.tbDebits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDebits.Enabled = false;
            this.tbDebits.Location = new System.Drawing.Point(97, 6);
            this.tbDebits.Name = "tbDebits";
            this.tbDebits.Size = new System.Drawing.Size(285, 20);
            this.tbDebits.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tbCredits);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(398, 33);
            this.panel3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Credits";
            // 
            // tbCredits
            // 
            this.tbCredits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCredits.Enabled = false;
            this.tbCredits.Location = new System.Drawing.Point(97, 6);
            this.tbCredits.Name = "tbCredits";
            this.tbCredits.Size = new System.Drawing.Size(285, 20);
            this.tbCredits.TabIndex = 2;
            // 
            // pnlTransactionType
            // 
            this.pnlTransactionType.Controls.Add(this.cmbTransactionType);
            this.pnlTransactionType.Controls.Add(this.label5);
            this.pnlTransactionType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransactionType.Location = new System.Drawing.Point(0, 135);
            this.pnlTransactionType.Name = "pnlTransactionType";
            this.pnlTransactionType.Size = new System.Drawing.Size(398, 33);
            this.pnlTransactionType.TabIndex = 4;
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTransactionType.Enabled = false;
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(97, 6);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(285, 21);
            this.cmbTransactionType.Sorted = true;
            this.cmbTransactionType.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Type";
            // 
            // pnlNotClosedAccounts
            // 
            this.pnlNotClosedAccounts.Controls.Add(this.cmbNotClosedAccounts);
            this.pnlNotClosedAccounts.Controls.Add(this.labelNotClosedAccount);
            this.pnlNotClosedAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNotClosedAccounts.Location = new System.Drawing.Point(0, 101);
            this.pnlNotClosedAccounts.Name = "pnlNotClosedAccounts";
            this.pnlNotClosedAccounts.Size = new System.Drawing.Size(398, 34);
            this.pnlNotClosedAccounts.TabIndex = 3;
            this.pnlNotClosedAccounts.Visible = false;
            // 
            // cmbNotClosedAccounts
            // 
            this.cmbNotClosedAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNotClosedAccounts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbNotClosedAccounts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNotClosedAccounts.Enabled = false;
            this.cmbNotClosedAccounts.FormattingEnabled = true;
            this.cmbNotClosedAccounts.Location = new System.Drawing.Point(97, 7);
            this.cmbNotClosedAccounts.Name = "cmbNotClosedAccounts";
            this.cmbNotClosedAccounts.Size = new System.Drawing.Size(285, 21);
            this.cmbNotClosedAccounts.Sorted = true;
            this.cmbNotClosedAccounts.TabIndex = 1;
            // 
            // labelNotClosedAccount
            // 
            this.labelNotClosedAccount.AutoSize = true;
            this.labelNotClosedAccount.Location = new System.Drawing.Point(7, 8);
            this.labelNotClosedAccount.Name = "labelNotClosedAccount";
            this.labelNotClosedAccount.Size = new System.Drawing.Size(51, 13);
            this.labelNotClosedAccount.TabIndex = 0;
            this.labelNotClosedAccount.Text = "Account*";
            // 
            // pnlAllAccount
            // 
            this.pnlAllAccount.Controls.Add(this.cmbAllAccount);
            this.pnlAllAccount.Controls.Add(this.lblAccount);
            this.pnlAllAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAllAccount.Location = new System.Drawing.Point(0, 67);
            this.pnlAllAccount.Name = "pnlAllAccount";
            this.pnlAllAccount.Size = new System.Drawing.Size(398, 34);
            this.pnlAllAccount.TabIndex = 2;
            // 
            // cmbAllAccount
            // 
            this.cmbAllAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAllAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAllAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAllAccount.Enabled = false;
            this.cmbAllAccount.FormattingEnabled = true;
            this.cmbAllAccount.Location = new System.Drawing.Point(97, 7);
            this.cmbAllAccount.Name = "cmbAllAccount";
            this.cmbAllAccount.Size = new System.Drawing.Size(285, 21);
            this.cmbAllAccount.Sorted = true;
            this.cmbAllAccount.TabIndex = 1;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(7, 8);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(47, 13);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "Account";
            // 
            // pnlTransactionDate
            // 
            this.pnlTransactionDate.Controls.Add(this.lblDate);
            this.pnlTransactionDate.Controls.Add(this.dtpTransactionDate);
            this.pnlTransactionDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransactionDate.Location = new System.Drawing.Point(0, 33);
            this.pnlTransactionDate.Name = "pnlTransactionDate";
            this.pnlTransactionDate.Size = new System.Drawing.Size(398, 34);
            this.pnlTransactionDate.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Location = new System.Drawing.Point(97, 7);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpTransactionDate.TabIndex = 0;
            // 
            // pnlId
            // 
            this.pnlId.Controls.Add(this.lblId);
            this.pnlId.Controls.Add(this.tbId);
            this.pnlId.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlId.Location = new System.Drawing.Point(0, 0);
            this.pnlId.Name = "pnlId";
            this.pnlId.Size = new System.Drawing.Size(398, 33);
            this.pnlId.TabIndex = 0;
            this.pnlId.Visible = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(7, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "Id";
            // 
            // tbId
            // 
            this.tbId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(97, 6);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(285, 20);
            this.tbId.TabIndex = 2;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAddNew);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(398, 41);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(294, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(81, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(61, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(10, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(61, 23);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(748, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 514);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvItems);
            this.pnlGrid.Controls.Add(this.panel2);
            this.pnlGrid.Controls.Add(this.panel1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(748, 514);
            this.pnlGrid.TabIndex = 9;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.AutoGenerateContextFilters = true;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.DateWithTime = false;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 41);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(748, 445);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.TimeFilter = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblSumDebits);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblSumCredits);
            this.panel2.Controls.Add(this.lblRecCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 486);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 28);
            this.panel2.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(321, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Sum(Debits):";
            // 
            // lblSumDebits
            // 
            this.lblSumDebits.AutoSize = true;
            this.lblSumDebits.Location = new System.Drawing.Point(411, 7);
            this.lblSumDebits.Name = "lblSumDebits";
            this.lblSumDebits.Size = new System.Drawing.Size(68, 13);
            this.lblSumDebits.TabIndex = 4;
            this.lblSumDebits.Text = "lblSumDebits";
            this.lblSumDebits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(155, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Sum(Credits):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Record count:";
            // 
            // lblSumCredits
            // 
            this.lblSumCredits.AutoSize = true;
            this.lblSumCredits.Location = new System.Drawing.Point(245, 7);
            this.lblSumCredits.Name = "lblSumCredits";
            this.lblSumCredits.Size = new System.Drawing.Size(70, 13);
            this.lblSumCredits.TabIndex = 1;
            this.lblSumCredits.Text = "lblSumCredits";
            this.lblSumCredits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRecCount
            // 
            this.lblRecCount.AutoSize = true;
            this.lblRecCount.Location = new System.Drawing.Point(89, 7);
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(65, 13);
            this.lblRecCount.TabIndex = 0;
            this.lblRecCount.Text = "lblRecCount";
            this.lblRecCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 41);
            this.panel1.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnLoadCashUpdateXls);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(573, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(132, 41);
            this.panel12.TabIndex = 7;
            // 
            // btnLoadCashUpdateXls
            // 
            this.btnLoadCashUpdateXls.Location = new System.Drawing.Point(14, 10);
            this.btnLoadCashUpdateXls.Name = "btnLoadCashUpdateXls";
            this.btnLoadCashUpdateXls.Size = new System.Drawing.Size(115, 23);
            this.btnLoadCashUpdateXls.TabIndex = 0;
            this.btnLoadCashUpdateXls.Text = "load Cash Update xls";
            this.btnLoadCashUpdateXls.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnExcelExport);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(469, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(104, 41);
            this.panel11.TabIndex = 6;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(14, 10);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(75, 23);
            this.btnExcelExport.TabIndex = 0;
            this.btnExcelExport.Text = "to Excel";
            this.btnExcelExport.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnDateFromSubtract);
            this.panel9.Controls.Add(this.btnDateFromAdd);
            this.panel9.Controls.Add(this.btnToday);
            this.panel9.Controls.Add(this.dtpDateFrom);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.dtpDateTo);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(104, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(365, 41);
            this.panel9.TabIndex = 4;
            // 
            // btnDateFromSubtract
            // 
            this.btnDateFromSubtract.Location = new System.Drawing.Point(184, 21);
            this.btnDateFromSubtract.Margin = new System.Windows.Forms.Padding(2);
            this.btnDateFromSubtract.Name = "btnDateFromSubtract";
            this.btnDateFromSubtract.Size = new System.Drawing.Size(19, 18);
            this.btnDateFromSubtract.TabIndex = 6;
            this.btnDateFromSubtract.Text = "-";
            this.btnDateFromSubtract.UseVisualStyleBackColor = true;
            // 
            // btnDateFromAdd
            // 
            this.btnDateFromAdd.Location = new System.Drawing.Point(184, 3);
            this.btnDateFromAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnDateFromAdd.Name = "btnDateFromAdd";
            this.btnDateFromAdd.Size = new System.Drawing.Size(19, 18);
            this.btnDateFromAdd.TabIndex = 5;
            this.btnDateFromAdd.Text = "+";
            this.btnDateFromAdd.UseVisualStyleBackColor = true;
            // 
            // btnToday
            // 
            this.btnToday.BackgroundImage = global::ComLog.WinForms.Properties.Resources.Today;
            this.btnToday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToday.Location = new System.Drawing.Point(5, 13);
            this.btnToday.Margin = new System.Windows.Forms.Padding(2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(15, 16);
            this.btnToday.TabIndex = 4;
            this.btnToday.UseVisualStyleBackColor = true;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(61, 11);
            this.dtpDateFrom.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpDateFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(224, 11);
            this.dtpDateTo.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(120, 20);
            this.dtpDateTo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnRefresh);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(104, 41);
            this.panel10.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(14, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // TransactionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlDetails);
            this.Name = "TransactionControl";
            this.Size = new System.Drawing.Size(1149, 514);
            this.pnlDetails.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlTransactionType.ResumeLayout(false);
            this.pnlTransactionType.PerformLayout();
            this.pnlNotClosedAccounts.ResumeLayout(false);
            this.pnlNotClosedAccounts.PerformLayout();
            this.pnlAllAccount.ResumeLayout(false);
            this.pnlAllAccount.PerformLayout();
            this.pnlTransactionDate.ResumeLayout(false);
            this.pnlTransactionDate.PerformLayout();
            this.pnlId.ResumeLayout(false);
            this.pnlId.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Panel pnlAllAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Panel pnlId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlGrid;
        private ADGV.AdvancedDataGridView dgvItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRecCount;
        private System.Windows.Forms.Label lblSumCredits;
        private System.Windows.Forms.ComboBox cmbAllAccount;
        private System.Windows.Forms.Panel pnlTransactionDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Panel pnlTransactionType;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCredits;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDebits;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCharges;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFromTo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSumDebits;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnLoadCashUpdateXls;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Panel pnlNotClosedAccounts;
        private System.Windows.Forms.ComboBox cmbNotClosedAccounts;
        private System.Windows.Forms.Label labelNotClosedAccount;
        private System.Windows.Forms.Button btnDateFromSubtract;
        private System.Windows.Forms.Button btnDateFromAdd;
    }
}
