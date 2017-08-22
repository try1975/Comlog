using System;
using System.Windows.Forms;
using ComLog.Dto;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters;

namespace ComLog.WinForms.Controls
{
    public partial class TransactionControl : UserControl, ITransactionView
    {
        private readonly IPresenter _presenter;
        private bool _isEventHandlerSets;
        public TransactionControl(ITransactionDataManager transactionDataManager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _presenter = new TransactionPresenter(this, transactionDataManager, dataMаnager);
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
        public DateTime Dt { get; set; }
        public int BankId { get; set; }
        public int AccountId { get; set; }
        public int? TransactionTypeId { get; set; }
        public string CurrencyId { get; set; }
        public decimal? Credits { get; set; }
        public decimal? Debits { get; set; }
        public decimal? Charges { get; set; }
        public string FromTo { get; set; }
        public string Description { get; set; }
        public decimal? UsdCredits { get; set; }
        public decimal? UsdDebits { get; set; }
        public string Report { get; set; }
        public decimal? Dcc { get; set; }
        public decimal? UsdDcc { get; set; }
        public DateTime? TransactionDate { get; set; }

        #endregion //Details

        #region DetailsLists

        #endregion //DetailsLists

        #endregion //ITransactionTypeView implementation

        #region IRefreshedView

        public void RefreshItems()
        {
            dgvItems.DataSource = _presenter.BindingSource;

            var column = dgvItems.Columns[nameof(TransactionDto.Id)];
            if (column != null) column.Visible = false;

            column = dgvItems.Columns[nameof(TransactionDto.Charges)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionDto.Credits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionDto.Debits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionDto.UsdCredits)];
            if (column != null)
            {
                column.DefaultCellStyle.Format = "N2";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            column = dgvItems.Columns[nameof(TransactionDto.UsdDebits)];
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
        }

        public void EnableInput()
        {
            //tbId.Enabled = true;
            tbName.Enabled = true;
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            tbName.Enabled = false;
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
