using System;
using System.Windows.Forms;
using ComLog.Dto;
using ComLog.WinForms.Interfaces;
using ComLog.WinForms.Interfaces.Common;
using ComLog.WinForms.Interfaces.Data;
using ComLog.WinForms.Presenters;

namespace ComLog.WinForms.Controls
{
    public partial class BankControl : UserControl, IBankView
    {
        private readonly IPresenter _presenter;
        private bool _isEventHandlerSets;
        private DateTime? _closed;

        public BankControl(IBankDataMаnager bankDataMаnager, IDataMаnager dataMаnager)
        {
            InitializeComponent();
            _presenter = new BankPresenter(this, bankDataMаnager, dataMаnager);
        }

        #region IBankView

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

        public string BankName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        //public DateTime? Closed { get; set; }

        public DateTime? Closed
        {
            get { return _closed; }
            set
            {
                _closed = value;
                if(cbClosed.Checked != _closed.HasValue) cbClosed.Checked = _closed.HasValue;
            }
        }

        #endregion //Details

        #endregion IBankView

        #region IRefreshedView

        public void RefreshItems()
        {
            dgvItems.DataSource = _presenter.BindingSource;
            // hide columns
            var column = dgvItems.Columns[nameof(BankDto.Id)];
            if (column != null) column.Visible = false;

            column = dgvItems.Columns[nameof(BankDto.Name)];
            if (column != null) column.HeaderText = @"Bank Name";
        }

        public void SetEventHandlers()
        {
            if (_isEventHandlerSets) return;
            _isEventHandlerSets = true;

            dgvItems.SelectionChanged += dgvItems_SelectionChanged;
            dgvItems.FilterStringChanged += dgvItems_FilterStringChanged;
            dgvItems.SortStringChanged += dgvItems_SortStringChanged;

            btnAddNew.Click += btnAddNew_Click;
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            btnDelete.Click += btnDelete_Click;

            cbClosed.CheckedChanged += cbClosed_CheckedChanged;
        }

        #endregion //IRefreshedView

        #region IEnterMode

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

            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnAddNew.Enabled = true;
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
            cbClosed.Checked = false;
        }

        public void EnableInput()
        {
            //tbId.Enabled = true;
            tbName.Enabled = true;
            cbClosed.Enabled = true;
        }

        public void DisableInput()
        {
            tbId.Enabled = false;
            tbName.Enabled = false;
            cbClosed.Enabled = false;
        }

        #endregion //IEnterMode

        #region Event handlers

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            _presenter.SetDetailData();
        }

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

        private void cbClosed_CheckedChanged(object sender, EventArgs e)
        {
            if(cbClosed.Checked && !Closed.HasValue) Closed = DateTime.Now;
            if(!cbClosed.Checked && Closed.HasValue) Closed = null;
        }

        #endregion
    }
}