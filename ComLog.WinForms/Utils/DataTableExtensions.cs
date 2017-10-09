﻿using System;
using System.Data;

namespace ComLog.WinForms.Utils
{
    public static class DataTableExtensions
    {
        public static void SetColumnsOrder(this DataTable table, params string[] columnNames)
        {
            var columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                table.Columns[columnName].SetOrdinal(columnIndex);
                columnIndex++;
            }
        }
    }
}