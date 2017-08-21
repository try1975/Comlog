using ADGV;

namespace ComLog.WinForms.Controls
{
    partial class BankControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.pnlBic = new System.Windows.Forms.Panel();
            this.tbBic = new System.Windows.Forms.TextBox();
            this.lblBic = new System.Windows.Forms.Label();
            this.pnlBankAddress = new System.Windows.Forms.Panel();
            this.tbBankAddress = new System.Windows.Forms.TextBox();
            this.lblBankAddress = new System.Windows.Forms.Label();
            this.pnlBankName = new System.Windows.Forms.Panel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.pnlId = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvItems = new AdvancedDataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlDetails.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.pnlBic.SuspendLayout();
            this.pnlBankAddress.SuspendLayout();
            this.pnlBankName.SuspendLayout();
            this.pnlId.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.pnlFields);
            this.pnlDetails.Controls.Add(this.pnlButtons);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Location = new System.Drawing.Point(274, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(396, 550);
            this.pnlDetails.TabIndex = 3;
            // 
            // pnlFields
            // 
            this.pnlFields.Controls.Add(this.pnlBic);
            this.pnlFields.Controls.Add(this.pnlBankAddress);
            this.pnlFields.Controls.Add(this.pnlBankName);
            this.pnlFields.Controls.Add(this.pnlId);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Location = new System.Drawing.Point(0, 41);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(396, 509);
            this.pnlFields.TabIndex = 1;
            // 
            // pnlBic
            // 
            this.pnlBic.Controls.Add(this.tbBic);
            this.pnlBic.Controls.Add(this.lblBic);
            this.pnlBic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBic.Location = new System.Drawing.Point(0, 101);
            this.pnlBic.Name = "pnlBic";
            this.pnlBic.Size = new System.Drawing.Size(396, 34);
            this.pnlBic.TabIndex = 6;
            // 
            // tbBic
            // 
            this.tbBic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBic.Enabled = false;
            this.tbBic.Location = new System.Drawing.Point(97, 5);
            this.tbBic.Name = "tbBic";
            this.tbBic.Size = new System.Drawing.Size(283, 20);
            this.tbBic.TabIndex = 1;
            // 
            // lblBic
            // 
            this.lblBic.AutoSize = true;
            this.lblBic.Location = new System.Drawing.Point(6, 8);
            this.lblBic.Name = "lblBic";
            this.lblBic.Size = new System.Drawing.Size(22, 13);
            this.lblBic.TabIndex = 0;
            this.lblBic.Text = "Bic";
            // 
            // pnlBankAddress
            // 
            this.pnlBankAddress.Controls.Add(this.tbBankAddress);
            this.pnlBankAddress.Controls.Add(this.lblBankAddress);
            this.pnlBankAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBankAddress.Location = new System.Drawing.Point(0, 67);
            this.pnlBankAddress.Name = "pnlBankAddress";
            this.pnlBankAddress.Size = new System.Drawing.Size(396, 34);
            this.pnlBankAddress.TabIndex = 5;
            // 
            // tbBankAddress
            // 
            this.tbBankAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBankAddress.Enabled = false;
            this.tbBankAddress.Location = new System.Drawing.Point(97, 5);
            this.tbBankAddress.Name = "tbBankAddress";
            this.tbBankAddress.Size = new System.Drawing.Size(283, 20);
            this.tbBankAddress.TabIndex = 1;
            // 
            // lblBankAddress
            // 
            this.lblBankAddress.AutoSize = true;
            this.lblBankAddress.Location = new System.Drawing.Point(6, 8);
            this.lblBankAddress.Name = "lblBankAddress";
            this.lblBankAddress.Size = new System.Drawing.Size(72, 13);
            this.lblBankAddress.TabIndex = 0;
            this.lblBankAddress.Text = "Bank address";
            // 
            // pnlBankName
            // 
            this.pnlBankName.Controls.Add(this.tbName);
            this.pnlBankName.Controls.Add(this.lblBankName);
            this.pnlBankName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBankName.Location = new System.Drawing.Point(0, 33);
            this.pnlBankName.Name = "pnlBankName";
            this.pnlBankName.Size = new System.Drawing.Size(396, 34);
            this.pnlBankName.TabIndex = 4;
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
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(6, 8);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(63, 13);
            this.lblBankName.TabIndex = 0;
            this.lblBankName.Text = "Bank Name";
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
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(6, 9);
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
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(213, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(148, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(78, 12);
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
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvItems);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(271, 550);
            this.pnlGrid.TabIndex = 4;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.dgvItems.FilterAndSortEnabled = true;
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(271, 550);
            this.dgvItems.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(271, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 550);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // BankControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlDetails);
            this.Name = "BankControl";
            this.Size = new System.Drawing.Size(670, 550);
            this.pnlDetails.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.pnlBic.ResumeLayout(false);
            this.pnlBic.PerformLayout();
            this.pnlBankAddress.ResumeLayout(false);
            this.pnlBankAddress.PerformLayout();
            this.pnlBankName.ResumeLayout(false);
            this.pnlBankName.PerformLayout();
            this.pnlId.ResumeLayout(false);
            this.pnlId.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Panel pnlBankName;
        private System.Windows.Forms.Panel pnlId;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblId;
        private AdvancedDataGridView dgvItems;
        private System.Windows.Forms.Panel pnlBic;
        private System.Windows.Forms.TextBox tbBic;
        private System.Windows.Forms.Label lblBic;
        private System.Windows.Forms.Panel pnlBankAddress;
        private System.Windows.Forms.TextBox tbBankAddress;
        private System.Windows.Forms.Label lblBankAddress;
    }
}
