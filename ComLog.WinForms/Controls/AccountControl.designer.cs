using ADGV;

namespace ComLog.WinForms.Controls
{
    partial class AccountControl
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
            this.pnlMsDaily01 = new System.Windows.Forms.Panel();
            this.cbMsDaily01 = new System.Windows.Forms.CheckBox();
            this.pnlClosed = new System.Windows.Forms.Panel();
            this.cbClosed = new System.Windows.Forms.CheckBox();
            this.pnplBeneficiaryAddress = new System.Windows.Forms.Panel();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.pnlCurrency = new System.Windows.Forms.Panel();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.pnlAccountName = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.pnlBank = new System.Windows.Forms.Panel();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbShowClosed = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbOnlyTodayActivity = new System.Windows.Forms.CheckBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlShowCheck = new System.Windows.Forms.Panel();
            this.cbShowCheck = new System.Windows.Forms.CheckBox();
            this.pnlDetails.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.pnlMsDaily01.SuspendLayout();
            this.pnlClosed.SuspendLayout();
            this.pnplBeneficiaryAddress.SuspendLayout();
            this.pnlCurrency.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            this.pnlAccountName.SuspendLayout();
            this.pnlBank.SuspendLayout();
            this.pnlId.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnlShowCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.pnlFields);
            this.pnlDetails.Controls.Add(this.pnlButtons);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(657, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(396, 550);
            this.pnlDetails.TabIndex = 4;
            // 
            // pnlFields
            // 
            this.pnlFields.Controls.Add(this.pnlMsDaily01);
            this.pnlFields.Controls.Add(this.pnlClosed);
            this.pnlFields.Controls.Add(this.pnplBeneficiaryAddress);
            this.pnlFields.Controls.Add(this.pnlCurrency);
            this.pnlFields.Controls.Add(this.pnlBalance);
            this.pnlFields.Controls.Add(this.pnlAccountName);
            this.pnlFields.Controls.Add(this.pnlBank);
            this.pnlFields.Controls.Add(this.pnlId);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Location = new System.Drawing.Point(0, 41);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(396, 509);
            this.pnlFields.TabIndex = 1;
            // 
            // pnlMsDaily01
            // 
            this.pnlMsDaily01.Controls.Add(this.cbMsDaily01);
            this.pnlMsDaily01.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMsDaily01.Location = new System.Drawing.Point(0, 237);
            this.pnlMsDaily01.Name = "pnlMsDaily01";
            this.pnlMsDaily01.Size = new System.Drawing.Size(396, 34);
            this.pnlMsDaily01.TabIndex = 10;
            // 
            // cbMsDaily01
            // 
            this.cbMsDaily01.AutoSize = true;
            this.cbMsDaily01.Location = new System.Drawing.Point(97, 8);
            this.cbMsDaily01.Name = "cbMsDaily01";
            this.cbMsDaily01.Size = new System.Drawing.Size(75, 17);
            this.cbMsDaily01.TabIndex = 1;
            this.cbMsDaily01.Text = "MsDaily01";
            this.cbMsDaily01.UseVisualStyleBackColor = true;
            // 
            // pnlClosed
            // 
            this.pnlClosed.Controls.Add(this.cbClosed);
            this.pnlClosed.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClosed.Location = new System.Drawing.Point(0, 203);
            this.pnlClosed.Name = "pnlClosed";
            this.pnlClosed.Size = new System.Drawing.Size(396, 34);
            this.pnlClosed.TabIndex = 8;
            // 
            // cbClosed
            // 
            this.cbClosed.AutoSize = true;
            this.cbClosed.Location = new System.Drawing.Point(97, 8);
            this.cbClosed.Name = "cbClosed";
            this.cbClosed.Size = new System.Drawing.Size(58, 17);
            this.cbClosed.TabIndex = 1;
            this.cbClosed.Text = "Closed";
            this.cbClosed.UseVisualStyleBackColor = true;
            // 
            // pnplBeneficiaryAddress
            // 
            this.pnplBeneficiaryAddress.Controls.Add(this.cmbAccountType);
            this.pnplBeneficiaryAddress.Controls.Add(this.lblAccountType);
            this.pnplBeneficiaryAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnplBeneficiaryAddress.Location = new System.Drawing.Point(0, 169);
            this.pnplBeneficiaryAddress.Name = "pnplBeneficiaryAddress";
            this.pnplBeneficiaryAddress.Size = new System.Drawing.Size(396, 34);
            this.pnplBeneficiaryAddress.TabIndex = 7;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.Enabled = false;
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(97, 5);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(283, 21);
            this.cmbAccountType.TabIndex = 2;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(7, 8);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(70, 13);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Account type";
            // 
            // pnlCurrency
            // 
            this.pnlCurrency.Controls.Add(this.cmbCurrency);
            this.pnlCurrency.Controls.Add(this.lblCurrency);
            this.pnlCurrency.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCurrency.Location = new System.Drawing.Point(0, 135);
            this.pnlCurrency.Name = "pnlCurrency";
            this.pnlCurrency.Size = new System.Drawing.Size(396, 34);
            this.pnlCurrency.TabIndex = 6;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Enabled = false;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(97, 6);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(283, 21);
            this.cmbCurrency.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(7, 9);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(49, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Currency";
            // 
            // pnlBalance
            // 
            this.pnlBalance.Controls.Add(this.tbBalance);
            this.pnlBalance.Controls.Add(this.lblBalance);
            this.pnlBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBalance.Location = new System.Drawing.Point(0, 101);
            this.pnlBalance.Name = "pnlBalance";
            this.pnlBalance.Size = new System.Drawing.Size(396, 34);
            this.pnlBalance.TabIndex = 9;
            // 
            // tbBalance
            // 
            this.tbBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBalance.Enabled = false;
            this.tbBalance.Location = new System.Drawing.Point(97, 5);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.Size = new System.Drawing.Size(283, 20);
            this.tbBalance.TabIndex = 1;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(7, 8);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(46, 13);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Balance";
            // 
            // pnlAccountName
            // 
            this.pnlAccountName.Controls.Add(this.tbName);
            this.pnlAccountName.Controls.Add(this.lblAccountName);
            this.pnlAccountName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccountName.Location = new System.Drawing.Point(0, 67);
            this.pnlAccountName.Name = "pnlAccountName";
            this.pnlAccountName.Size = new System.Drawing.Size(396, 34);
            this.pnlAccountName.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(97, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(283, 20);
            this.tbName.TabIndex = 1;
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(7, 8);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(78, 13);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "Account Name";
            // 
            // pnlBank
            // 
            this.pnlBank.Controls.Add(this.cmbBank);
            this.pnlBank.Controls.Add(this.lblBank);
            this.pnlBank.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBank.Location = new System.Drawing.Point(0, 33);
            this.pnlBank.Name = "pnlBank";
            this.pnlBank.Size = new System.Drawing.Size(396, 34);
            this.pnlBank.TabIndex = 5;
            // 
            // cmbBank
            // 
            this.cmbBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.Enabled = false;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(97, 4);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(283, 21);
            this.cmbBank.TabIndex = 1;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(7, 7);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(32, 13);
            this.lblBank.TabIndex = 0;
            this.lblBank.Text = "Bank";
            // 
            // pnlId
            // 
            this.pnlId.Controls.Add(this.lblId);
            this.pnlId.Controls.Add(this.tbId);
            this.pnlId.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlId.Location = new System.Drawing.Point(0, 0);
            this.pnlId.Name = "pnlId";
            this.pnlId.Size = new System.Drawing.Size(396, 33);
            this.pnlId.TabIndex = 3;
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
            this.tbId.Size = new System.Drawing.Size(283, 20);
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
            this.pnlButtons.Size = new System.Drawing.Size(396, 41);
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
            this.splitter1.Location = new System.Drawing.Point(654, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 550);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvItems);
            this.pnlGrid.Controls.Add(this.panel1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(654, 550);
            this.pnlGrid.TabIndex = 7;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.AutoGenerateContextFilters = true;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvItems.DateWithTime = false;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 41);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(654, 509);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.TimeFilter = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlShowCheck);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 41);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbShowClosed);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(550, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 41);
            this.panel2.TabIndex = 7;
            // 
            // cbShowClosed
            // 
            this.cbShowClosed.AutoSize = true;
            this.cbShowClosed.Location = new System.Drawing.Point(13, 16);
            this.cbShowClosed.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowClosed.Name = "cbShowClosed";
            this.cbShowClosed.Size = new System.Drawing.Size(87, 17);
            this.cbShowClosed.TabIndex = 0;
            this.cbShowClosed.Text = "Show closed";
            this.cbShowClosed.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbOnlyTodayActivity);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(208, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 41);
            this.panel3.TabIndex = 8;
            // 
            // cbOnlyTodayActivity
            // 
            this.cbOnlyTodayActivity.AutoSize = true;
            this.cbOnlyTodayActivity.Location = new System.Drawing.Point(13, 16);
            this.cbOnlyTodayActivity.Margin = new System.Windows.Forms.Padding(2);
            this.cbOnlyTodayActivity.Name = "cbOnlyTodayActivity";
            this.cbOnlyTodayActivity.Size = new System.Drawing.Size(134, 17);
            this.cbOnlyTodayActivity.TabIndex = 0;
            this.cbOnlyTodayActivity.Text = "Only with today activity";
            this.cbOnlyTodayActivity.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btnExcelExport);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(104, 0);
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
            // pnlShowCheck
            // 
            this.pnlShowCheck.Controls.Add(this.cbShowCheck);
            this.pnlShowCheck.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlShowCheck.Location = new System.Drawing.Point(446, 0);
            this.pnlShowCheck.Name = "pnlShowCheck";
            this.pnlShowCheck.Size = new System.Drawing.Size(104, 41);
            this.pnlShowCheck.TabIndex = 9;
            this.pnlShowCheck.Visible = false;
            // 
            // cbShowCheck
            // 
            this.cbShowCheck.AutoSize = true;
            this.cbShowCheck.Location = new System.Drawing.Point(13, 16);
            this.cbShowCheck.Margin = new System.Windows.Forms.Padding(2);
            this.cbShowCheck.Name = "cbShowCheck";
            this.cbShowCheck.Size = new System.Drawing.Size(86, 17);
            this.cbShowCheck.TabIndex = 0;
            this.cbShowCheck.Text = "Show check";
            this.cbShowCheck.UseVisualStyleBackColor = true;
            // 
            // AccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlDetails);
            this.Name = "AccountControl";
            this.Size = new System.Drawing.Size(1053, 550);
            this.pnlDetails.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.pnlMsDaily01.ResumeLayout(false);
            this.pnlMsDaily01.PerformLayout();
            this.pnlClosed.ResumeLayout(false);
            this.pnlClosed.PerformLayout();
            this.pnplBeneficiaryAddress.ResumeLayout(false);
            this.pnplBeneficiaryAddress.PerformLayout();
            this.pnlCurrency.ResumeLayout(false);
            this.pnlCurrency.PerformLayout();
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            this.pnlAccountName.ResumeLayout(false);
            this.pnlAccountName.PerformLayout();
            this.pnlBank.ResumeLayout(false);
            this.pnlBank.PerformLayout();
            this.pnlId.ResumeLayout(false);
            this.pnlId.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.pnlShowCheck.ResumeLayout(false);
            this.pnlShowCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Panel pnlAccountName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblAccountName;
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
        private System.Windows.Forms.Panel pnlBank;
        private System.Windows.Forms.Panel pnlCurrency;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Panel pnplBeneficiaryAddress;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.Panel pnlClosed;
        private System.Windows.Forms.CheckBox cbClosed;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Panel pnlBalance;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbShowClosed;
        private AdvancedDataGridView dgvItems;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbOnlyTodayActivity;
        private System.Windows.Forms.Panel pnlMsDaily01;
        private System.Windows.Forms.CheckBox cbMsDaily01;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlShowCheck;
        private System.Windows.Forms.CheckBox cbShowCheck;
    }
}
