using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters;

namespace ComLog.WinForms.Controls
{
    public partial class AccountControl : UserControl, IAccountView
    {
        private readonly IPresenter _presenter;
        private bool _isEventHandlerSets;

        public AccountControl(IAccountDataManager accountDataManager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _presenter = new AccountPresenter(this, accountDataManager, dataMаnager);
        }

        #region IAccountView implementation

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

        public string BankAccountName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public int BankId
        {
            get { return (int)cmbBank.SelectedValue; }
            set { cmbBank.SelectedValue = value; }
        }

        public string CurrencyId
        {
            get { return (string)cmbCurrency.SelectedValue; }
            set { cmbCurrency.SelectedValue = value; }
        }

        public int AccountTypeId { get; set; }
        public DateTime? Closed { get; set; }

        //public decimal CurrentBalance
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(tbBalance.Text)) return 0;
        //        decimal balance;
        //        return decimal.TryParse(tbBalance.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out balance)
        //            ? balance
        //            : 0;
        //    }
        //    set { tbBalance.Text = value.ToString(CultureInfo.InvariantCulture); }
        //}

        #endregion //Details

        #region DetailsLists

        public List<KeyValuePair<int, string>> BankList
        {
            set
            {
                cmbBank.DataSource = value;
                cmbBank.ValueMember = "Key";
                cmbBank.DisplayMember = "Value";
            }
        }

        public List<KeyValuePair<string, string>> CurrencyList
        {
            set
            {
                cmbCurrency.DataSource = value;
                cmbCurrency.ValueMember = "Key";
                cmbCurrency.DisplayMember = "Value";
            }
        }

        public List<KeyValuePair<int, string>> AccountTypeList { get; set; }

        #endregion //DetailsLists

        #endregion //IAccountView implementation

        #region IRefreshedView

        public void RefreshItems()
        {
            dgvItems.DataSource = _presenter.BindingSource;

            var column = dgvItems.Columns[nameof(AccountDto.Id)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountDto.BankId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountDto.AccountTypeId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountExtDto.DisplayMember)];
            if (column != null) column.Visible = false;

            column = dgvItems.Columns[nameof(AccountDto.Name)];
            if (column != null) column.HeaderText = @"Account Name";

            column = dgvItems.Columns[nameof(AccountExtDto.BankName)];
            if (column != null) column.DisplayIndex = 0;
            column = dgvItems.Columns[nameof(AccountExtDto.Name)];
            if (column != null) column.DisplayIndex = 1;
            column = dgvItems.Columns[nameof(AccountExtDto.CurrencyId)];
            if (column != null) column.DisplayIndex = 2;
            column = dgvItems.Columns[nameof(AccountExtDto.AccountTypeName)];
            if (column != null) column.DisplayIndex = 3;
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
            cmbBank.SelectedIndex = -1;
            cmbCurrency.SelectedIndex = -1;
            tbBeneficiaryAddress.Clear();
        }

        public void EnableInput()
        {
            //tbId.Enabled = true;
            tbName.Enabled = true;
            cmbBank.Enabled = true;
            cmbCurrency.Enabled = true;
            tbBeneficiaryAddress.Enabled = true;
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            tbName.Enabled = false;
            cmbBank.Enabled = false;
            cmbCurrency.Enabled = false;
            tbBeneficiaryAddress.Enabled = false;
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
        }

        private void dgvItems_SortStringChanged(object sender, EventArgs e)
        {
            _presenter.BindingSource.Sort = dgvItems.SortString;
        }

        #endregion //Event handlers
    }
}