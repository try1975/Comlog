using ComLog.Dto;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters;
using System;
using System.Windows.Forms;

namespace ComLog.WinForms.Controls
{
    public partial class TransactionTypeControl : UserControl, ITransactionTypeView
    {
        private readonly IPresenter _presenter;
        private bool _isEventHandlerSets;

        public TransactionTypeControl(ITransactionTypeDataManager transactionTypeDataManager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _presenter = new TransactionTypePresenter(this, transactionTypeDataManager, dataMаnager);
        }

        #region ITransactionTypeView implementation

        #region Details

        public int Id
        {
            get
            {
                if (string.IsNullOrEmpty(tbId.Text)) return 0;
                int id;
                return int.TryParse(tbId.Text, out id) ? id : 0;
            }
            set { tbId.Text = value.ToString(); }
        }

        public string TransactionTypeName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public bool? IsActive
        {
            get
            {
                switch (cbIsActive.CheckState)
                {
                    case CheckState.Checked:
                        return true;
                    case CheckState.Unchecked:
                        return false;
                    case CheckState.Indeterminate:
                        return null;
                }
                return null;
            }
            set
            {
                switch (value)
                {
                    case true:
                        cbIsActive.CheckState = CheckState.Checked;
                        return;
                    case false:
                        cbIsActive.CheckState = CheckState.Unchecked;
                        return;
                            
                }
                cbIsActive.CheckState = CheckState.Indeterminate;
            }
        }

        #endregion //Details

        #region DetailsLists

        #endregion //DetailsLists

        #endregion //ITransactionTypeView implementation

        #region IRefreshedView

        public void RefreshItems()
        {
            dgvItems.DataSource = _presenter.BindingSource;

            var column = dgvItems.Columns[nameof(TransactionTypeDto.Id)];
            if (column != null) column.Visible = false;

            column = dgvItems.Columns[nameof(TransactionTypeDto.Name)];
            if (column != null) column.HeaderText = @"TransactionTypeName";
        }

        public void SetEventHandlers()
        {
            if (_isEventHandlerSets) return;
            _isEventHandlerSets = true;

            dgvItems.FilterStringChanged += dgvItems_FilterStringChanged;
            dgvItems.SortStringChanged += dgvItems_SortStringChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnDelete.Click += btnDelete_Click;
        }

        #endregion //IRefreshedView

        #region IEnterMode

        public void EnterEditMode()
        {
            EnableInput();

            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnAddNew.Enabled = false;
        }

        public void EnterDetailsMode()
        {
            DisableInput();

            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnAddNew.Enabled = true;
        }

        public void EnterReadMode()
        {
            ClearInputFields();
            DisableInput();
            //ClearSelectedAccounts();
            //ClearFilter();

            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnAddNew.Enabled = true;
        }

        public void EnterAddNewMode()
        {
            ClearInputFields();
            EnableInput();

            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnAddNew.Enabled = false;
        }

        public void EnterMultiSelectMode()
        {
            ClearInputFields();
            DisableInput();

            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnAddNew.Enabled = true;
        }

        public void ClearInputFields()
        {
            tbId.Clear();
            tbName.Clear();
            cbIsActive.CheckState = CheckState.Indeterminate;
        }

        public void EnableInput()
        {
            //tbId.Enabled = true;
            tbName.Enabled = true;
            cbIsActive.Enabled = true;
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            tbName.Enabled = false;
            cbIsActive.Enabled = false;
        }

        #endregion //IEnterMode

        #region Event handlers

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _presenter.AddNew();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _presenter.Edit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _presenter.Cancel();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _presenter.Delete();
        }

        private void dgvItems_FilterStringChanged(object sender, EventArgs e)
        {
            _presenter.BindingSource.Filter = dgvItems.FilterString;
            _presenter.BindingSource.ResetBindings(false);
        }

        private void dgvItems_SortStringChanged(object sender, EventArgs e)
        {
            _presenter.BindingSource.Sort = dgvItems.SortString;
            _presenter.BindingSource.ResetBindings(false);
        }

        #endregion //Event handlers
    }
}