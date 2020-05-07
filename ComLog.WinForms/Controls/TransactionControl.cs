using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComLog.Dto.Ext;
using ComLog.WinForms.Administration;
using ComLog.WinForms.Forms;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Interfaces.Filter;
using ComLog.WinForms.Presenters;
using ComLog.WinForms.Utils;
using log4net;

namespace ComLog.WinForms.Controls
{
    public partial class TransactionControl : UserControl, ITransactionView
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IPresenter _presenter;
        private readonly ITransactionViewFilter _transactionViewFilter;
        private bool _isEventHandlerSets;
        private int EditableDays
        {
            get
            {
                if (CurrentUser.Login.ToLower().Equals("am")) return 720;
                int editableDays;
                return int.TryParse(ConfigurationManager.AppSettings[nameof(EditableDays)], out editableDays) ? editableDays : 7;
            }
        }

        public TransactionControl(ITransactionDataManager transactionDataManager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _transactionViewFilter = transactionDataManager.TransactionViewFilter;
            _presenter = new TransactionPresenter(this, transactionDataManager, dataMаnager);
            dtpDateFrom.Value = _transactionViewFilter.DateFrom;
            dtpDateTo.Value = _transactionViewFilter.DateTo;
            //var accountControl = CompositionRoot.Resolve<IAccountView>();
            //accountControl.HideAll();
            //AddControlToWorkArea((Control)accountControl);
            pnlAccounts.Visible = false;
            splitter2.Visible = false;
            pnlDetails.Visible = true;
        }

        private void AddControlToWorkArea(Control control)
        {
            control.Dock = DockStyle.Fill;
            pnlAccounts.Controls.Clear();
            pnlAccounts.Controls.Add(control);
        }

        private bool ValidateData()
        {
            if (TransactionDate <= DateTime.Today.AddDays(-EditableDays))
            {
                MessageBox.Show(
                    $@"Transaction date must be greater than {DateTime.Today.AddDays(-(EditableDays + 1)):dd-MM-yyyy}",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (TransactionDate >= DateTime.Today.AddDays(1))
            {
                MessageBox.Show(
                    $@"Transaction date must be less or equal than {DateTime.Today:dd-MM-yyyy}",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (string.IsNullOrEmpty(cmbAllAccount.Text))
            {
                MessageBox.Show(
                    @"Account must be set",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (cmbAllAccount.SelectedItem == null)
            {
                MessageBox.Show(
                    @"Account must be set",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (string.IsNullOrEmpty(cmbTransactionType.Text))
            {
                MessageBox.Show(
                    @"Transaction type must be set",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (cmbTransactionType.SelectedItem == null)
            {
                MessageBox.Show(
                    @"Transaction type must be set",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (!string.IsNullOrEmpty(tbCredits.Text) && !Credits.HasValue)
            {
                MessageBox.Show(
                    $@"Check Credits number format [{tbCredits.Text}]",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (!string.IsNullOrEmpty(tbDebits.Text) && !Debits.HasValue)
            {
                MessageBox.Show(
                    $@"Check Debits number format [{tbDebits.Text}]",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (!string.IsNullOrEmpty(tbCharges.Text) && !Charges.HasValue)
            {
                MessageBox.Show(
                    $@"Check Charges number format [{tbCharges.Text}]",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (!Credits.HasValue && !Debits.HasValue && !Charges.HasValue)
            {
                MessageBox.Show(
                    @"Credits or Debits or Charges  must have value",
                    @"Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            var accountExtDto = cmbAllAccount.SelectedItem as AccountExtDto;
            var msDaily = false;
            if (accountExtDto?.MsDaily01 != null) msDaily = accountExtDto.MsDaily01.Value;
            if (string.IsNullOrEmpty(cmbNewFormType.Text) && msDaily && string.IsNullOrEmpty(tbReport.Text) && string.IsNullOrEmpty(tbPmrq.Text) && string.IsNullOrEmpty(tbCharges.Text))
            {
                return MessageBox.Show(
                    @"NewForm type must be set?",
                    @"Important Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1)==DialogResult.No;
            }
            return true;
        }

        private async Task<bool> SetData()
        {
            var accountExtDto = cmbAllAccount.SelectedItem as AccountExtDto;
            if (accountExtDto == null) return false;
            AccountId = accountExtDto.Id;
            BankId = accountExtDto.BankId;
            CurrencyId = accountExtDto.CurrencyId;
            var rate = 1m;
            if (TransactionDate != null)
                try
                {
                    rate = await _presenter.DataMаnager.GetCurrencyExchangeRate(CurrencyId, TransactionDate.Value);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

            if (!Credits.HasValue) UsdCredits = null;
            else
                UsdCredits = Credits * rate;
            if (Debits.HasValue && Debits > 0) Debits = Debits * -1;
            if (Charges.HasValue && Charges > 0) Charges = Charges * -1;
            if (!Debits.HasValue && !Charges.HasValue)
            {
                UsdDebits = null;
            }
            else
            {
                decimal? usdDebits = null;
                if (Debits.HasValue) usdDebits = Debits * rate;
                if (Charges.HasValue)
                {
                    if (usdDebits.HasValue) usdDebits += Charges * rate;
                    else
                        usdDebits = Charges * rate;
                }
                UsdDebits = usdDebits;
            }
            if (TransactionDate != null && TransactionDate.Value.Date == DateTime.Today)
                dtpDateTo.Value = DateTime.Today;

            Report = Report.Trim();
            return true;
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
                var accountExtDto = cmbAllAccount.SelectedItem as AccountExtDto;
                return accountExtDto?.Id ?? 0;
            }
            set
            {
                var list = cmbAllAccount.DataSource as List<AccountExtDto>;
                if (list == null) return;
                var accountExtDto = list.FirstOrDefault(z => z.Id == value);
                cmbAllAccount.SelectedItem = accountExtDto;
            }
            //get { return (int)cmbAllAccount.SelectedValue; }
            //set { cmbAllAccount.SelectedValue = value; }
        }

        public int? TransactionTypeId
        {
            get { return (int?)cmbTransactionType.SelectedValue; }
            set { cmbTransactionType.SelectedValue = value; }
        }

        public int? NewFormTypeId
        {
            get { return (int?)cmbNewFormType.SelectedValue; }
            set
            {
                if (value == null) { cmbNewFormType.SelectedIndex = -1; }
                else { cmbNewFormType.SelectedValue = value; }
            }
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
            set { tbCredits.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? ""; }
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
            set { tbDebits.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? ""; }
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
            set { tbCharges.Text = value?.ToString("N2", CultureInfo.InvariantCulture) ?? ""; }
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

        public string Pmrq
        {
            get { return tbPmrq.Text; }
            set { tbPmrq.Text = value; }
        }

        public decimal? Dc { get; set; }
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

        public DateTime? WeekDt
        {
            get { return dtpWeekDt.Value; }
            set
            {
                if (value != null) dtpWeekDt.Value = value.Value;
                else if (TransactionDate != null) dtpWeekDt.Value = TransactionDate.Value;
            }
        }

        #endregion //Details

        #region DetailsList

        public List<AccountExtDto> AllAccountList
        {
            set
            {
                cmbAllAccount.DataSource = value;
                cmbAllAccount.DisplayMember = "DisplayMember";
            }
        }

        public List<AccountExtDto> NotClosedAccountList
        {
            set
            {
                cmbNotClosedAccounts.DataSource = value;
                cmbNotClosedAccounts.DisplayMember = "DisplayMember";
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

        public List<KeyValuePair<int, string>> NewFormTypeList
        {
            set
            {
                cmbNewFormType.DataSource = value;
                cmbNewFormType.ValueMember = "Key";
                cmbNewFormType.DisplayMember = "Value";
            }
        }

        #endregion DetailsList

        #endregion //ITransactionView implementation

        #region IRefreshedView

        private void SetInfoLabels()
        {
            lblRecCount.Text = $@"{dgvItems.RowCount:N0}";

            var sumCredits = dgvItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells[nameof(TransactionExtDto.Credits)].Value == DBNull.Value
                        ? 0
                        : t.Cells[nameof(TransactionExtDto.Credits)].Value))
                ;
            lblSumCredits.Text = $@"{sumCredits.ToString("N2", CultureInfo.InvariantCulture)}";
            var sumDebits = dgvItems.Rows.Cast<DataGridViewRow>()
                    .Sum(t => Convert.ToDecimal(t.Cells[nameof(TransactionExtDto.Debits)].Value == DBNull.Value
                        ? 0
                        : t.Cells[nameof(TransactionExtDto.Debits)].Value))
                ;
            lblSumDebits.Text = $@"{sumDebits.ToString("N2", CultureInfo.InvariantCulture)}";
        }

        private void AfterGridDataChange()
        {
            GridColors.SetRowColors(dgvItems);
            ColumnSettings();
            SetInfoLabels();
        }

        private void ColumnSettings()
        {
            var column = dgvItems.Columns[nameof(TransactionExtDto.Id)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.BankId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.AccountId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.TransactionTypeId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.NewFormTypeId)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.Dcc)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.Dc)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.UsdDcc)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.UsdCredits)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.UsdDebits)];
            if (column != null) column.Visible = false;
            column = dgvItems.Columns[nameof(TransactionExtDto.MsDaily01)];
            if (column != null)
            {
                column.Visible = true;
                column.DisplayIndex = dgvItems.Columns.Count - 1 - 1;
            }
            column = dgvItems.Columns[nameof(TransactionExtDto.CurrencyOrd)];
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
            column = dgvItems.Columns[nameof(TransactionExtDto.NewFormTypeName)];
            if (column != null)
            {
                column.DisplayIndex = dgvItems.Columns.Count - 1 - 2;
            }

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
            btnLoadCashUpdateXls.Click += btnLoadCashUpdateXls_Click;
            btnLoadCashMovement.Click += btnLoadCashMovement_Click;
            btnMsDaily.Click += btnMsDaily_Click;
            btnReportY.Click += btnReportY_Click;
            btnLoadCl.Click += btnLoadCl_Click;
            dgvItems.FilterStringChanged += dgvItems_FilterStringChanged;
            dgvItems.SortStringChanged += dgvItems_SortStringChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnDelete.Click += btnDelete_Click;

            dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;
            btnToday.Click += btnToday_Click;
            btnDateFromAdd.Click += btnDateFromAdd_Click;
            btnDateFromSubtract.Click += btnDateFromSubtract_Click;

            btnClearNewForm.Click += btnClearNewForm_Click;
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

            //pnlAllAccount.Visible = false;
            //pnlNotClosedAccounts.Visible = true;
        }

        public void EnterDetailsMode()
        {
            DisableInput();

            btnDelete.Enabled = true;
            if (TransactionDate <= DateTime.Today.AddDays(-EditableDays)) btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            if (TransactionDate <= DateTime.Today.AddDays(-EditableDays)) btnEdit.Enabled = false;
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

            //pnlAllAccount.Visible = true;
            //pnlNotClosedAccounts.Visible = false;

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

            //pnlAllAccount.Visible = false;
            //pnlNotClosedAccounts.Visible = true;
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
            cmbAllAccount.SelectedIndex = -1;
            //cmbNotClosedAccounts.SelectedIndex = -1;
            cmbTransactionType.SelectedIndex = -1;
            cmbNewFormType.SelectedIndex = -1;
            tbCredits.Text = string.Empty;
            tbDebits.Text = string.Empty;
            tbCharges.Text = string.Empty;
            tbFromTo.Text = string.Empty;
            tbDescription.Text = string.Empty;
            tbReport.Text = string.Empty;
            tbPmrq.Text = string.Empty;
            dtpWeekDt.Value = DateTime.Today;
        }

        public void EnableInput()
        {
            //tbId.Enabled = true;
            dtpTransactionDate.Enabled = true;
            cmbAllAccount.Enabled = true;
            cmbTransactionType.Enabled = true;
            cmbNewFormType.Enabled = true;
            btnClearNewForm.Enabled = true;
            tbCredits.Enabled = true;
            tbDebits.Enabled = true;
            tbCharges.Enabled = true;
            tbFromTo.Enabled = true;
            tbDescription.Enabled = true;
            tbReport.Enabled = true;
            tbPmrq.Enabled = true;
            dtpWeekDt.Enabled = true;

            cmbAllAccount.Focus();
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            dtpTransactionDate.Enabled = false;
            cmbAllAccount.Enabled = false;
            cmbTransactionType.Enabled = false;
            cmbNewFormType.Enabled = false;
            btnClearNewForm.Enabled = false;
            tbCredits.Enabled = false;
            tbDebits.Enabled = false;
            tbCharges.Enabled = false;
            tbFromTo.Enabled = false;
            tbDescription.Enabled = false;
            tbReport.Enabled = false;
            tbPmrq.Enabled = false;
            dtpWeekDt.Enabled = false;
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
            _presenter.BindingSource.ResetBindings(false);
            AfterGridDataChange();
        }

        private void dgvItems_SortStringChanged(object sender, EventArgs e)
        {
            _presenter.BindingSource.Sort = dgvItems.SortString;
            _presenter.BindingSource.ResetBindings(false);
            AfterGridDataChange();
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

        private void btnReportY_Click(object sender, EventArgs e)
        {
            var sourceDataTable = (DataTable)_presenter.BindingSource.DataSource;
            var sort = $"[{nameof(TransactionExtDto.BankName)}] ASC, [{nameof(TransactionExtDto.CurrencyOrd)}] ASC";
            var rowFilter = $"{nameof(TransactionExtDto.Report)} in ('Y','y')";
            var view = new DataView(sourceDataTable, rowFilter, sort, DataViewRowState.CurrentRows);
            var dataTable = view.ToTable();
            var fieldNames = new[]
            {
                nameof(TransactionExtDto.BankName), nameof(TransactionExtDto.CurrencyId),
                nameof(TransactionExtDto.FromTo), nameof(TransactionExtDto.Description), nameof(TransactionExtDto.Dcc)
            };
            dataTable.SetColumnsOrder(fieldNames);
            for (var i = dataTable.Columns.Count - 1; i >= 0; i--)
            {
                if (!fieldNames.Any(f => f.Equals(dataTable.Columns[i].ColumnName)))
                    dataTable.Columns.RemoveAt(i);
            }

            var fileName = $"ComLog_Y_{dtpDateFrom.Value:yyMMdd}";
            if (dtpDateFrom.Value != dtpDateTo.Value) fileName = fileName + $"_{dtpDateTo.Value:yyMMdd}";
            if (dtpDateTo.Value.Date != DateTime.Today) fileName = fileName + $"_{DateTime.Today:yyMMdd}";
            fileName = fileName + $"_{DateTime.Now:HHmm}.xlsx";
            var saveFileDialog = new SaveFileDialog { FileName = fileName };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            CreateExcelFile.CreateExcelDocument(dataTable, saveFileDialog.FileName);
            var macroRunSettings = new MacroRunSettings
            {
                MacroWorkBook = ConfigurationManager.AppSettings[nameof(MacroSettings.MacroWorkBook)],
                MacroName = ConfigurationManager.AppSettings[nameof(MacroSettings.ReportYMacro)],
                SourceFilename = saveFileDialog.FileName,
                DestinationFilename = saveFileDialog.FileName.Replace(".xls", "_Formated.xls")
            };
            if (dtpDateFrom.Value != dtpDateTo.Value)
            {
                macroRunSettings.Params["Period"] = $"{dtpDateFrom.Value:dd-MMM-yy} to {dtpDateTo.Value:dd-MMM-yy}";
            }
            else
            {
                macroRunSettings.Params["Period"] = $"{dtpDateFrom.Value:dd-MMM-yy}";
            }

            var runMacroForm = new RunMacroForm(macroRunSettings);
            if (runMacroForm.NotShow)
            {
                runMacroForm.Close();
            }
            else
            {
                runMacroForm.ShowDialog();
            }
            if (!File.Exists(macroRunSettings.DestinationFilename)) return;
            try
            {
                File.Delete(macroRunSettings.SourceFilename);
                File.Move(macroRunSettings.DestinationFilename, macroRunSettings.SourceFilename);
                Process.Start(macroRunSettings.SourceFilename);
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { FileName = $"ComLog_{DateTime.Now:yyyyMMdd_HHmm}.xlsx" };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var sourceDataTable = (DataTable)_presenter.BindingSource.DataSource;
            var view = new DataView(sourceDataTable, dgvItems.FilterString, dgvItems.SortString, DataViewRowState.CurrentRows);
            //var dataTable = sourceDataTable.Copy();
            var dataTable = view.ToTable();
            dataTable.SetColumnsOrder(
                nameof(TransactionExtDto.TransactionDate)
                , nameof(TransactionExtDto.BankName)
                , nameof(TransactionExtDto.AccountName)
                , nameof(TransactionExtDto.CurrencyId)
                , nameof(TransactionExtDto.Credits)
                , nameof(TransactionExtDto.Debits)
                , nameof(TransactionExtDto.Charges)
                , nameof(TransactionExtDto.FromTo)
                , nameof(TransactionExtDto.Description)
                , nameof(TransactionExtDto.Report)
                , nameof(TransactionExtDto.TransactionTypeName)
                , nameof(TransactionExtDto.UsdDebits)
                , nameof(TransactionExtDto.UsdCredits)
                , nameof(TransactionExtDto.Dcc)
                , nameof(TransactionExtDto.ChangeBy)
                , nameof(TransactionExtDto.ChangeAt)
            );
            CreateExcelFile.CreateExcelDocument(dataTable, saveFileDialog.FileName);
            if (File.Exists(saveFileDialog.FileName)) Process.Start(saveFileDialog.FileName);
        }

        private async void btnMsDaily_Click(object sender, EventArgs e)
        {
            var fileName = $"MS_ComLog_{dtpDateFrom.Value:yyMMdd}";
            if (dtpDateFrom.Value.Date != dtpDateTo.Value.Date) fileName = fileName + $"_{dtpDateTo.Value:yyMMdd}";
            //if (dtpDateTo.Value.Date != DateTime.Today) fileName = fileName + $"_{DateTime.Today:yyMMdd}";
            fileName = fileName + $"_{DateTime.Now:yyMMddHHmm}.xlsx";
            var saveFileDialog = new SaveFileDialog { FileName = fileName };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            var macroRunSettings = new MacroRunSettings
            {
                MacroWorkBook = ConfigurationManager.AppSettings[nameof(MacroSettings.MsDailyWorkBook)],
                MacroName = ConfigurationManager.AppSettings[nameof(MacroSettings.MsDailyMacro)],
                SourceFilename = saveFileDialog.FileName,
                DestinationFilename = saveFileDialog.FileName.Replace(".xlsx", "_Formated.xlsm")
            };
            if (dtpDateFrom.Value != dtpDateTo.Value)
            {
                macroRunSettings.Params["DTB"] = $"{dtpDateFrom.Value:dd-MMM-yy}";
                macroRunSettings.Params["DTE"] = $"{dtpDateTo.Value:dd-MMM-yy}";
            }
            else
            {
                macroRunSettings.Params["DTB"] = $"{dtpDateFrom.Value:dd-MMM-yy}";
                macroRunSettings.Params["DTE"] = "";
            }

            // Previous currency rate to params
            var date = dtpDateFrom.Value.Date;
            var previousDayCount = -1;
            if (date.DayOfWeek == DayOfWeek.Monday) previousDayCount = -3;
            date = date.AddDays(previousDayCount);
            // TODO: take date of previous report from transaction table
            var dateForm = new DateForm { Date = date };
            if (dateForm.ShowDialog() != DialogResult.OK) return;
            date = dateForm.Date.Date.AddDays(-1);

            var rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("EUR", date);
            macroRunSettings.Params["EUR_RATE_P"] = $"{rate:##.0000}";
            
            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("GBP", date);
            macroRunSettings.Params["GBP_RATE_P"] = $"{rate:##.0000}";
            
            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("CHF", date);
            macroRunSettings.Params["CHF_RATE_P"] = $"{rate:##.0000}";

            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("AED", date);
            macroRunSettings.Params["AED_RATE_P"] = $"{rate:##.0000}";


            // Current currency rate to params
            date = dtpDateTo.Value.Date.AddDays(-1);
            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("EUR", date);
            macroRunSettings.Params["EUR_RATE"] = $"{rate:##.0000}";
            
            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("GBP", date);
            macroRunSettings.Params["GBP_RATE"] = $"{rate:##.0000}";
            
            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("CHF", date);
            macroRunSettings.Params["CHF_RATE"] = $"{rate:##.0000}";

            rate = await _presenter.DataMаnager.GetCurrencyExchangeRate("AED", date);
            macroRunSettings.Params["AED_RATE"] = $"{rate:##.0000}";


            var report = await _presenter.DataMаnager.GetAccountsReport01(dtpDateFrom.Value, dtpDateTo.Value);
            if (report == null)
            {
                const string errorText = "Data receive error.";
                Log.Error(errorText);
                MessageBox.Show(errorText, @"Error", MessageBoxButtons.OK);
                return;
            }
            var dataTable = DataTableConverter.ToDataTable(report);
            var fieldNames = new[]
            {
                nameof(AccountMsDailyDto.PrevBalance),
                nameof(AccountMsDailyDto.BankName), nameof(AccountMsDailyDto.CurrencyId),
                nameof(AccountMsDailyDto.FromTo), nameof(AccountMsDailyDto.Description),
                nameof(AccountMsDailyDto.Dc),nameof(AccountMsDailyDto.Charges),
                nameof(AccountMsDailyDto.Activity), nameof(AccountMsDailyDto.NewBalance),
                nameof(AccountMsDailyDto.Report), nameof(AccountMsDailyDto.Pmrq),
                nameof(AccountMsDailyDto.NewFormTypeName)
            };
            dataTable.SetColumnsOrder(fieldNames);
            for (var i = dataTable.Columns.Count - 1; i >= 0; i--)
            {
                if (!fieldNames.Any(f => f.Equals(dataTable.Columns[i].ColumnName)))
                    dataTable.Columns.RemoveAt(i);
            }
            CreateExcelFile.CreateExcelDocument(dataTable, saveFileDialog.FileName);

            var runMacroForm = new RunMacroForm(macroRunSettings);
            if (runMacroForm.NotShow)
            {
                runMacroForm.Close();
            }
            else
            {
                runMacroForm.ShowDialog();
            }
            if (!File.Exists(macroRunSettings.DestinationFilename)) return;
            try
            {
                File.Delete(macroRunSettings.SourceFilename);
                macroRunSettings.SourceFilename = macroRunSettings.SourceFilename.Replace(".xlsx", ".xlsm");
                File.Move(macroRunSettings.DestinationFilename, macroRunSettings.SourceFilename);
                Process.Start(macroRunSettings.SourceFilename);
            }
            catch (Exception exception)
            {
                Log.Error(exception);
                MessageBox.Show(exception.ToString());
            }
        }

        private void LoadByExcelMacro(string macroName)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            var macroRunSettings = new MacroRunSettings
            {
                MacroWorkBook = ConfigurationManager.AppSettings[nameof(MacroSettings.MacroWorkBook)],
                MacroName = ConfigurationManager.AppSettings[macroName],
                SourceFilename = openFileDialog.FileName,
                DestinationFilename = openFileDialog.FileName.Replace(".xls", "_Converted.xls")
            };
            macroRunSettings.Params[MacroRunSettings.ImportRun] = bool.TrueString;
            var runMacroForm = new RunMacroForm(macroRunSettings);
            if (runMacroForm.NotShow)
            {
                runMacroForm.Close();
            }
            else
            {
                if (runMacroForm.ShowDialog() == DialogResult.OK) btnRefresh_Click(this, null);
            }
        }

        private void btnLoadCashUpdateXls_Click(object sender, EventArgs e)
        {
            LoadByExcelMacro(nameof(MacroSettings.CashUpdateMacro));
        }

        private void btnLoadCashMovement_Click(object sender, EventArgs e)
        {
            LoadByExcelMacro(nameof(MacroSettings.CashMovementMacro));
        }

        private void btnLoadCl_Click(object sender, EventArgs e)
        {
            var date = DateTime.Today;
            var dateForm = new DateForm { Date = date, DateText = "Select date for cash list import" };
            if (dateForm.ShowDialog() != DialogResult.OK) return;
            date = dateForm.Date.Date;
            var macroRunSettings = new MacroRunSettings
            {
                MacroWorkBook = ConfigurationManager.AppSettings[nameof(MacroSettings.MacroWorkBook)],
                MacroName = ConfigurationManager.AppSettings[nameof(MacroSettings.CashListMacro)],
                Params = { [MacroRunSettings.ImportRun] = bool.TrueString, ["Date"] = $"{date:yyyyMMdd}" }
            };
            var runMacroForm = new RunMacroForm(macroRunSettings);
            if (runMacroForm.NotShow)
            {
                runMacroForm.Close();
            }
            else
            {
                if (runMacroForm.ShowDialog() == DialogResult.OK) btnRefresh_Click(this, null);
            }
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

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Value = DateTime.Today;
            dtpDateTo.Value = DateTime.Today;
            //_transactionViewFilter.DateFrom = dtpDateFrom.Value;
            //_presenter.Reopen();
            //_transactionViewFilter.DateTo = dtpDateTo.Value;
            //_presenter.Reopen();
        }

        private void btnDateFromSubtract_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Value = dtpDateFrom.Value.AddDays(-1);
        }

        private void btnDateFromAdd_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Value = dtpDateFrom.Value.AddDays(1);
        }

        private void btnClearNewForm_Click(object sender, EventArgs e)
        {
            cmbNewFormType.SelectedIndex = -1;
        }

        #endregion //Event handlers
    }
}