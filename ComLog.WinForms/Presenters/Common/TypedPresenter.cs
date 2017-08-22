using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AutoMapper;
using ComLog.Dto;
using ComLog.WinForms.Interfaces.Common;

namespace ComLog.WinForms.Presenters.Common
{
    public abstract class TypedPresenter<T, TK> : IPresenter where T : class, IDto<TK>
    {
        private readonly ITypedDataMànager<T, TK> _typedDataMànager;
        protected readonly IDataMànager DataMànager;
        protected readonly ITypedView<T, TK> View;
        

        protected TypedPresenter(ITypedView<T, TK> view, ITypedDataMànager<T, TK> typedDataMànager,
            IDataMànager dataMànager, PresenterMode presenterMode = PresenterMode.Read)
        {
            View = view;
            _typedDataMànager = typedDataMànager;
            DataMànager = dataMànager;

            BindingSource = new BindingSource();
            BindingSource.CurrentChanged += BindingSourceOnCurrentChanged;
            if (presenterMode == PresenterMode.Read) SetItems();
        }

        public PresenterMode PresenterMode { get; private set; }

        public BindingSource BindingSource { get; }

        public void SetDetailData()
        {
            T item = null;
            if (BindingSource.Current != null)
            {
                var current = (DataRowView) BindingSource.Current;
                item = ToDto(current);
            }
            Mapper.Map(item, View);
            View.EnterDetailsMode();
        }

        public void Reopen()
        {
            SetItems();
        }

        public void AddNew()
        {
            PresenterMode = PresenterMode.AddNew;
            View.EnterAddNewMode();
        }

        public void Edit()
        {
            PresenterMode = PresenterMode.Edit;
            View.EnterEditMode();
        }

        public void Save()
        {
            switch (PresenterMode)
            {
                case PresenterMode.AddNew:
                    Create();
                    break;
                case PresenterMode.Edit:
                    Update();
                    break;
                default:
                    MessageBox.Show(@"Error: You can't use 'Save' button in this mode.", @"Error");
                    break;
            }
        }

        public void Cancel()
        {
            PresenterMode = PresenterMode.Read;
            View.EnterReadMode();
        }

        public async void Delete()
        {
            const string question = @"You really want to delete this record?";
            const string caption = @"Delete warning";
            if (MessageBox.Show(question, caption, MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            var item = Mapper.Map<T>(View);

            var success = await _typedDataMànager.DeleteItem(item.Id);
            if (success)
            {
                BindingSource.RemoveCurrent();
            }
            else
            {
                MessageBox.Show(@"Error: You can't delete this item.", @"Error");
            }

            View.EnterReadMode();
            PresenterMode = PresenterMode.Read;
        }

        private void BindingSourceOnCurrentChanged(object sender, EventArgs eventArgs)
        {
            SetDetailData();
        }

        private async void SetItems()
        {
            BindingSource.DataSource = ToDataTable((await _typedDataMànager.GetItems()).ToList());
            View.RefreshItems();
            View.SetEventHandlers();
        }

        private async void Create()
        {
            var item = Mapper.Map<T>(View);
            item = await _typedDataMànager.PostItem(item);
            Mapper.Map(item, View);

            if (item != null)
            {
                BindingSource.DataSource = ToDataTable((await _typedDataMànager.GetItems()).ToList());
            }
            PresenterMode = PresenterMode.Read;
            View.EnterReadMode();
        }

        private async void Update()
        {
            var item = Mapper.Map<T>(View);
            item = await _typedDataMànager.PutItem(item);
            Mapper.Map(item, View);

            BindingSource.DataSource = ToDataTable((await _typedDataMànager.GetItems()).ToList());

            View.EnterReadMode();
            PresenterMode = PresenterMode.Read;
        }

        private static DataTable ToDataTable(IEnumerable<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var type = prop.PropertyType.IsGenericType &&
                           prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    ? Nullable.GetUnderlyingType(prop.PropertyType)
                    : prop.PropertyType;
                if (type != null) dataTable.Columns.Add(prop.Name, type);
            }
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        //private static void ToRow(DataRowView data, T item)
        //{
        //    var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    for (var i = 0; i < props.Length; i++)
        //    {
        //        data.Row.ItemArray[i] = props[i].GetValue(item, null);
        //    }
        //}

        private static T ToDto(DataRowView data)
        {
            var result = (T) Activator.CreateInstance(typeof(T), null);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < props.Length; i++)
            {
                var value = data.Row.ItemArray[i];
                if (value != DBNull.Value)
                {
                    props[i].SetValue(result, data.Row.ItemArray[i]);
                }
            }
            return result;
        }
    }
}