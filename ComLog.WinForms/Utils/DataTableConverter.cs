using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using log4net;

namespace ComLog.WinForms.Utils
{
    public static class DataTableConverter
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            Log.Info($"ToDataTable start {typeof(T).Name}");
            var dataTable = new DataTable(typeof(T).Name);

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var type = prop.PropertyType.IsGenericType &&
                           prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    ? Nullable.GetUnderlyingType(prop.PropertyType)
                    : prop.PropertyType;
                if (type != null) dataTable.Columns.Add(prop.Name, type);
                Log.Info($"prop.Name {prop.Name}");
            }
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                    Log.Info($"values[i] {props[i].GetValue(item, null)}");
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}