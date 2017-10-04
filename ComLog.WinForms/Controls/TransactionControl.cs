using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComLog.Dto.Ext;
using ComLog.WinForms.Forms;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Interfaces.Filter;
using ComLog.WinForms.Presenters;
using ComLog.WinForms.Utils;

namespace ComLog.WinForms.Controls
{
    public partial class TransactionControl : UserControl, ITransactionView
    {
        private readonly IPresenter _presenter;
        private bool _isEventHandlerSets;
        private readonly ITransactionViewFilter _transactionViewFilter;

        public TransactionControl(ITransactionDataManager transactionDataManager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _transactionViewFilter = transactionDataManager.TransactionViewFilter;
            _presenter = new TransactionPresenter(this, transactionDataManager, dataMаnager);
            dtpDateFrom.Value = _transactionViewFilter.DateFrom;
            dtpDateTo.Value = _transactionViewFilter.DateTo;
        }

        #region ITransactionView implementation

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
        public int BankId { get; set; }
        public int AccountId
        {
            get
            {
                var accountExtDto = cmbAccount.SelectedValue as AccountExtDto;
                return accountExtDto?.Id ?? 0;
            }
            set
            {
                var list = cmbAccount.DataSource as List<AccountExtDto>;
                if (list == null) return;
                var accountExtDto = list.FirstOrDefault(z => z.Id == value);
                cmbAccount.SelectedItem = accountExtDto;
            }
        }
        public int? TransactionTypeId
        {
            get { return (int?)cmbTransactionType.SelectedValue; }
            set { cmbTransactionType.SelectedValue = value; }
        }

        public string CurrencyId { get; set; }

        public decimal? Credits
        {
            get
            {
                decimal decimalResult;
                return decimal.TryParse(tbCredits.Text, NumberStyles.Number, CultureInfo.InvariantCulture,
                    out decimalResult)
                    ? decimalResult
                    : (decimal?)null;
            }
            set
            {
                tbCredits.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? "";
            }
        }
        public decimal? Debits
        {
            get
            {
                decimal decimalResult;
                return decimal.TryParse(tbDebits.Text, NumberStyles.Number, CultureInfo.InvariantCulture,
                    out decimalResult)
                    ? decimalResult
                    : (decimal?)null;
            }
            set
            {
                tbDebits.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? "";
            }
        }
        public decimal? Charges
        {
            get
            {
                decimal decimalResult;
                return decimal.TryParse(tbCharges.Text, NumberStyles.Number, CultureInfo.InvariantCulture,
                    out decimalResult)
                    ? decimalResult
                    : (decimal?)null;
            }
            set
            {
                tbCharges.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? "";
            }
        }

        public string FromTo
        {
            get { return tbFromTo.Text; }
            set { tbFromTo.Text = value; }
        }

        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public decimal? UsdCredits { get; set; }
        public decimal? UsdDebits { get; set; }
        public string Report
        {
            get { return tbReport.Text; }
            set { tbReport.Text = value; }
        }
        public decimal? Dcc { get; set; }
        public decimal? UsdDcc { get; set; }

        public DateTime? TransactionDate
        {
            get { return dtpTransactionDate.Value; }
            set
            {
                if (value != null) dtpTransactionDate.Value = value.Value;
            }
        }

        #endregion //Details

        #region DetailsList

        public List<AccountExtDto> AccountList
        {
            set
            {
                cmbAccount.DataSource = value;
                cmbAccount.DisplayMember = "DisplayMember";
            }
        }
        public List<KeyValuePair<int, string>> TransactionTypeList
        {
            set
            {
                cmbTransactionType.DataSource = value;
                cmbTransactionType.ValueMember = "Key";
                cmbTransactionType.DisplayMember = "Value";
            }
        }

        #endregion DetailsList

        #endregion //ITransactionView implementation

        #region IRefreshedView

        private void SetInfoLabels()
        {
            lblRecCount.Text = $"{dgvItems.RowCount.ToString("N0")}";

            var sumCredits = dgvItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[nameof(TransactionExtDto.Credits)].Value == DBNull.Value ? 0 : t.Cells[nameof(TransactionExtDto.Credits)].Value))
                ;
            lblSumCredits.Text = $"{sumCredits.ToString("N2", CultureInfo.InvariantCulture)}";
            var sumDebits = dgvItems.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToDecimal(t.Cells[nameof(TransactionExtDto.Debits)].Value == DBNull.Value ? 0 : t.Cells[nameof(TransactionExtDto.Debits)].Value))
                ;
            lblSumDebits.Text = $"{sumDebits.ToString("N2", CultureInfo.InvariantCulture)}";
        }

        public void RefreshItems()
        {
            dgvItems.DataSource = _presenter.BindingSource;
            SetInfoLabels();

            var column = dgvItems.Columns[nameof(TransactionExtDto.Id)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.BankId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.AccountId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.TransactionTypeId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.Dcc)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.UsdDcc)];
            if (column != null) column.Visible = false;

            column = dgvItems.Columns[nameof(TransactionExtDto.TransactionDate)];
            if (column != null) column.DisplayIndex = 0;
            column = dgvItems.Columns[nameof(TransactionExtDto.BankName)];
            if (column != null) column.DisplayIndex = 1;
            column = dgvItems.Columns[nameof(TransactionExtDto.AccountName)];
            if (column != null) column.DisplayIndex = 2;
            column = dgvItems.Columns[nameof(TransactionExtDto.CurrencyId)];
            if (column != null) column.DisplayIndex = 3;
            column = dgvItems.Columns[nameof(TransactionExtDto.TransactionTypeName)];
            if (column != null) column.DisplayIndex = 4;

            column = dgvItems.Columns[nameof(TransactionExtDto.TransactionDate)];
            if (column != null) column.HeaderText = @"Date";

            column = dgvItems.Columns[nameof(TransactionExtDto.Charges)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionExtDto.Credits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionExtDto.Debits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionExtDto.UsdCredits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionExtDto.UsdDebits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        public void SetEventHandlers()
        {
            if (_isEventHandlerSets) return;
            _isEventHandlerSets = true;

            btnRefresh.Click += btnRefresh_Click;
            btnExcelExport.Click += btnExcelExport_Click;
            btnLoadCashUpdateXls.Click += btnLoadCashUpdateXls_Click;
            dgvItems.FilterStringChanged += dgvItems_FilterStringChanged;
            dgvItems.SortStringChanged += dgvItems_SortStringChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnDelete.Click += btnDelete_Click;

            dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;
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
            if (TransactionDate <= DateTime.Today.AddDays(-5)) btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            if (TransactionDate <= DateTime.Today.AddDays(-5)) btnEdit.Enabled = false;
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

            SetInfoLabels();
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
            dtpTransactionDate.Value = DateTime.Today;
            cmbAccount.SelectedIndex = -1;
            cmbTransactionType.SelectedIndex = -1;
            tbCredits.Text = "";
            tbDebits.Text = "";
            tbCharges.Text = "";
            tbFromTo.Text = "";
            tbDescription.Text = "";
            tbReport.Text = "";
        }

        public void EnableInput()
        {
            //tbId.Enabled = true;
            dtpTransactionDate.Enabled = true;
            cmbAccount.Enabled = true;
            cmbTransactionType.Enabled = true;
            tbCredits.Enabled = true;
            tbDebits.Enabled = true;
            tbCharges.Enabled = true;
            tbFromTo.Enabled = true;
            tbDescription.Enabled = true;
            tbReport.Enabled = true;
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            dtpTransactionDate.Enabled = false;
            cmbAccount.Enabled = false;
            cmbTransactionType.Enabled = false;
            tbCredits.Enabled = false;
            tbDebits.Enabled = false;
            tbCharges.Enabled = false;
            tbFromTo.Enabled = false;
            tbDescription.Enabled = false;
            tbReport.Enabled = false;
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
            SetInfoLabels();
        }

        private void dgvItems_SortStringChanged(object sender, EventArgs e)
        {
            _presenter.BindingSource.Sort = dgvItems.SortString;
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            _transactionViewFilter.DateFrom = dtpDateFrom.Value;
            _presenter.Reopen();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            _transactionViewFilter.DateTo = dtpDateTo.Value;
            _presenter.Reopen();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            if (!await SetData()) return;
            _presenter.Save();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _presenter.Reopen();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { FileName = $"ComLog_{DateTime.Now.ToString("yyyyMMdd_HHmm")}.xlsx" };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var dataTable = (DataTable)_presenter.BindingSource.DataSource;// bsQuery.DataSource;
            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            CreateExcelFile.CreateExcelDocument(dataSet, saveFileDialog.FileName);
            if (File.Exists(saveFileDialog.FileName)) Process.Start(saveFileDialog.FileName);
        }

        private void btnLoadCashUpdateXls_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            var runMacroForm = new RunMacroForm(openFileDialog.FileName);
            if (runMacroForm.ShowDialog() == DialogResult.OK) btnRefresh_Click(this, null);
        }

        #endregion //Event handlers

        private bool ValidateData()
        {
            if (TransactionDate <= DateTime.Today.AddDays(-5))
            {
                MessageBox.Show(
                    $"Transaction date must be greater than {DateTime.Today.AddDays(-6).ToString("dd-MM-yyyy")}",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private async Task<bool> SetData()
        {
            var accountExtDto = cmbAccount.SelectedItem as AccountExtDto;
            if (accountExtDto == null) return false;
            BankId = accountExtDto.BankId;
            CurrencyId = accountExtDto.CurrencyId;
            var rate = 1m;
            if (TransactionDate != null)
            {
                try
                {
                    rate = await _presenter.DataMаnager.GetCurrencyExchangeRate(CurrencyId, TransactionDate.Value);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }

            if (!Credits.HasValue) UsdCredits = null;
            else
            {
                UsdCredits = Credits * rate;
            }
            if (Debits.HasValue && Debits > 0) Debits = Debits * -1;
            if (Charges.HasValue && Charges > 0) Charges = Charges * -1;
            if (!Debits.HasValue && !Charges.HasValue) UsdDebits = null;
            else
            {
                if (Debits.HasValue) UsdDebits = Debits * rate;
                if (Charges.HasValue)
                {
                    if (UsdDebits.HasValue) UsdDebits += Charges * rate;
                    else
                    {
                        UsdDebits = Charges * rate;
                    }
                }
            }
            return true;
        }
    }
}
