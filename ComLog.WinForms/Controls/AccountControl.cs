﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using ComLog.Dto;
using ComLog.Dto.Ext;
using ComLog.WinForms.Administration;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Interfaces.Filter;
using ComLog.WinForms.Presenters;
using ComLog.WinForms.Presenters.Common;
using ComLog.WinForms.Utils;

namespace ComLog.WinForms.Controls
{
    public partial class AccountControl : UserControl, IAccountView
    {
        private readonly IAccountViewFilter _accountViewFilter;
        private readonly IPresenter _presenter;
        private DateTime? _closed;
        private bool _isEventHandlerSets;
        private bool _hideAllMode;

        public AccountControl(IAccountDataManager accountDataManager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _accountViewFilter = accountDataManager.AccountViewFilter;
            _presenter = new AccountPresenter(this, accountDataManager, dataMаnager);
            cbShowClosed.Checked = _accountViewFilter.ShowClosed;
            cbOnlyTodayActivity.Checked = _accountViewFilter.OnlyTodayActivity;
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

        public string AccountName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public decimal? DbBalance { get; set; }

        public decimal? Balance
        {
            get
            {
                decimal decimalResult;
                return decimal.TryParse(tbBalance.Text, NumberStyles.Number, CultureInfo.InvariantCulture,
                    out decimalResult)
                    ? decimalResult
                    : (decimal?)null;
            }
            set { tbBalance.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? ""; }
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

        public int AccountTypeId
        {
            get { return (int)cmbAccountType.SelectedValue; }
            set { cmbAccountType.SelectedValue = value; }
        }

        public int? DailyId { get; set; }

        public DateTime? Closed
        {
            get { return _closed; }
            set
            {
                _closed = value;
                if (cbClosed.Checked != _closed.HasValue) cbClosed.Checked = _closed.HasValue;
            }
        }

        public bool? MsDaily01
        {
            get { return cbMsDaily01.Checked; }
            set { cbMsDaily01.Checked = value ?? false; }
        }

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

        public List<KeyValuePair<int, string>> AccountTypeList
        {
            set
            {
                cmbAccountType.DataSource = value;
                cmbAccountType.ValueMember = "Key";
                cmbAccountType.DisplayMember = "Value";
            }
        }

        #endregion //DetailsLists

        #region Methods

        public void HideAll()
        {
            pnlDetails.Visible = false;
            splitter1.Visible = false;
            panel1.Visible = false;
            _hideAllMode = true;
        }

        #endregion //Methods

        #endregion //IAccountView implementation

        #region IRefreshedView

        private void AfterGridDataChange()
        {
            GridColors.SetRowColors(dgvItems);
            ColumnSettings();
        }

        private void ColumnSettings()
        {
            pnlShowCheck.Visible = CurrentUser.MaySeeBalance;
            pnlBalance.Visible = cbShowCheck.Checked;

            var column = dgvItems.Columns[nameof(AccountDto.Id)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountDto.BankId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountDto.AccountTypeId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountExtDto.DisplayMember)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountExtDto.DailyId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountExtDto.ChangeAt)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountExtDto.ChangeBy)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(AccountExtDto.Closed)];
            if (column != null) column.Visible = cbShowClosed.Checked;
            column = dgvItems.Columns[nameof(AccountExtDto.Balance)];
            if (column != null) column.Visible = cbShowCheck.Checked;
            column = dgvItems.Columns[nameof(AccountExtDto.DeltaBalance)];
            if (column != null) column.Visible = cbShowCheck.Checked;


            if (_hideAllMode)
            {
                column = dgvItems.Columns[nameof(AccountExtDto.AccountTypeName)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.CurrencyId)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.Balance)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.DeltaBalance)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.Closed)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.MsDaily01)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.ChangeAt)];
                if (column != null) column.Visible = false;
                column = dgvItems.Columns[nameof(AccountExtDto.ChangeBy)];
                if (column != null) column.Visible = false;
            }

            column = dgvItems.Columns[nameof(AccountDto.Name)];
            if (column != null) column.HeaderText = @"Account Name";

            column = dgvItems.Columns[nameof(AccountExtDto.BankName)];
            if (column != null) column.DisplayIndex = 0;
            column = dgvItems.Columns[nameof(AccountExtDto.Name)];
            if (column != null) column.DisplayIndex = 1;
            column = dgvItems.Columns[nameof(AccountExtDto.AccountTypeName)];
            if (column != null) column.DisplayIndex = 2;
            column = dgvItems.Columns[nameof(AccountExtDto.CurrencyId)];
            if (column != null) column.DisplayIndex = 3;
            column = dgvItems.Columns[nameof(AccountExtDto.DbBalance)];
            if (column != null) column.DisplayIndex = 4;
            column = dgvItems.Columns[nameof(AccountExtDto.Balance)];
            if (column != null) column.DisplayIndex = dgvItems.Columns.Count - 2;
            column = dgvItems.Columns[nameof(AccountExtDto.DeltaBalance)];
            if (column != null) column.DisplayIndex = dgvItems.Columns.Count - 1;


            column = dgvItems.Columns[nameof(AccountDto.Name)];
            if (column != null) column.Width = 200;

            column = dgvItems.Columns[nameof(AccountExtDto.Balance)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(AccountExtDto.DbBalance)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(AccountExtDto.DeltaBalance)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        public void RefreshItems()
        {
            dgvItems.DataSource = _presenter.BindingSource;
            AfterGridDataChange();
        }

        public void SetEventHandlers()
        {
            if (_isEventHandlerSets) return;
            _isEventHandlerSets = true;

            btnRefresh.Click += btnRefresh_Click;
            btnExcelExport.Click += btnExcelExport_Click;
            dgvItems.FilterStringChanged += dgvItems_FilterStringChanged;
            dgvItems.SortStringChanged += dgvItems_SortStringChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnDelete.Click += btnDelete_Click;

            cbClosed.CheckedChanged += cbClosed_CheckedChanged;
            cbShowClosed.CheckedChanged += cbShowClosed_CheckedChanged;
            cbShowCheck.CheckedChanged += cbShowCheck_CheckedChanged;
            cbOnlyTodayActivity.CheckedChanged += cbOnlyTodayActivity_CheckedChanged;

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

            AfterGridDataChange();
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
            tbBalance.Clear();
            cmbBank.SelectedIndex = -1;
            cmbCurrency.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            cbClosed.Checked = false;
            cbMsDaily01.Checked = false;
        }

        public void EnableInput()
        {
            tbName.Enabled = true;
            tbBalance.Enabled = true;
            cbClosed.Enabled = true;
            if (_presenter.PresenterMode == PresenterMode.Edit)
            {
                if (DbBalance == 0) cbMsDaily01.Enabled = true;
            }
            else
            {
                cbMsDaily01.Enabled = true;
            }
            if (_presenter.PresenterMode != PresenterMode.AddNew) return;
            cmbBank.Enabled = true;
            cmbCurrency.Enabled = true;
            cmbAccountType.Enabled = true;
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            tbName.Enabled = false;
            tbBalance.Enabled = false;
            cmbBank.Enabled = false;
            cmbCurrency.Enabled = false;
            cmbAccountType.Enabled = false;
            cbClosed.Enabled = false;
            cbMsDaily01.Enabled = false;
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
            AfterGridDataChange();
        }

        private void dgvItems_SortStringChanged(object sender, EventArgs e)
        {
            _presenter.BindingSource.Sort = dgvItems.SortString;
            _presenter.BindingSource.ResetBindings(false);
            AfterGridDataChange();
        }

        private void cbClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClosed.Checked && !Closed.HasValue) Closed = DateTime.Now;
            if (!cbClosed.Checked && Closed.HasValue) Closed = null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _presenter.Reopen();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { FileName = $"ComLogAccounts_{DateTime.Now:yyyyMMdd_HHmm}.xlsx" };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var sourceDataTable = (DataTable)_presenter.BindingSource.DataSource;
            var view = new DataView(sourceDataTable, dgvItems.FilterString, dgvItems.SortString, DataViewRowState.CurrentRows);
            //var dataTable = sourceDataTable.Copy();
            var dataTable = view.ToTable();
            dataTable.SetColumnsOrder(nameof(AccountExtDto.BankName)
                , nameof(AccountExtDto.Name)
                , nameof(AccountExtDto.AccountTypeName)
                , nameof(AccountExtDto.CurrencyId)
                , nameof(AccountExtDto.Balance)
                , nameof(AccountExtDto.DbBalance)
                , nameof(AccountExtDto.DeltaBalance)
                , nameof(AccountExtDto.Closed)
                , nameof(AccountExtDto.ChangeBy)
                , nameof(AccountExtDto.ChangeAt)
            );
            CreateExcelFile.CreateExcelDocument(dataTable, saveFileDialog.FileName);
            if (File.Exists(saveFileDialog.FileName)) Process.Start(saveFileDialog.FileName);
        }

        private void cbShowClosed_CheckedChanged(object sender, EventArgs e)
        {
            _accountViewFilter.ShowClosed = cbShowClosed.Checked;
            _presenter.Reopen();
        }

        private void cbShowCheck_CheckedChanged(object sender, EventArgs e)
        {
            ColumnSettings();
        }

        private void cbOnlyTodayActivity_CheckedChanged(object sender, EventArgs e)
        {
            _accountViewFilter.OnlyTodayActivity = cbOnlyTodayActivity.Checked;
            _presenter.Reopen();
        }

        #endregion //Event handlers
    }
}