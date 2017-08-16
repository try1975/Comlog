using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace ComLog.Loader.Core
{
    public class LoaderAce
    {
        private readonly LoaderSettings _loaderSettings;

        public LoaderAce(LoaderSettings loaderSettings)
        {
            _loaderSettings = loaderSettings;
        }

        public void Load()
        {
            if (!string.IsNullOrEmpty(_loaderSettings.LoadedFilePath) && File.Exists(_loaderSettings.LoadedFilePath))
            {
                var watch = Stopwatch.StartNew();
                try
                {
                    // Before Load Script
                    ExecuteScript(_loaderSettings.BeforeLoadScriptFilename);

                    using (var bulkCopy = new SqlBulkCopy(_loaderSettings.SqlConnectionString))
                    {
                        bulkCopy.DestinationTableName = _loaderSettings.BulkTableName;
                        using (var connection = new OleDbConnection(_loaderSettings.XlsConnectionString))
                        {
                            connection.Open();
                            using (var dtTablesList = connection.GetSchema("Tables"))
                            {
                                for (var i = 0; i < dtTablesList.Rows.Count; i++)
                                {
                                    var sheetName = dtTablesList.Rows[i]["TABLE_NAME"].ToString();
                                    _loaderSettings.WriteMessage($"Loading {sheetName} ...");
                                    var command = new OleDbCommand(string.Format(_loaderSettings.BulkSelectStatement, sheetName), connection);
                                    using (DbDataReader dr = command.ExecuteReader())
                                    {
                                        if (dr == null) continue;
                                        //mapping 
                                        bulkCopy.ColumnMappings.Clear();
                                        for (var j = 0; j < dr.FieldCount; j++)
                                        {
                                            var xlsFieldName = dr.GetName(j);
                                            //Debug.WriteLine(xlsFieldName);
                                            if (FieldMap.Map.ContainsKey(xlsFieldName))
                                                bulkCopy.ColumnMappings.Add(xlsFieldName, FieldMap.Map[xlsFieldName]);
                                        }

                                        bulkCopy.WriteToServer(dr); // Bulk Copy to SQL Server 
                                    }
                                }
                            }
                        }
                    }
                    // After Load Script
                    ExecuteScript(_loaderSettings.AfterLoadScriptFilename);
                }
                catch (Exception ex)
                {
                    _loaderSettings.WriteMessage(ex.Message);
                }
                watch.Stop();
                _loaderSettings.WriteMessage($"{watch.ElapsedMilliseconds / 1000.000}s");
            }
            else
            {
                _loaderSettings.WriteMessage($"File {_loaderSettings.LoadedFilePath} not found");
            }
        }

        private void ExecuteScript(string scriptFilename)
        {
            if (string.IsNullOrEmpty(scriptFilename)) return;
            if (!File.Exists(scriptFilename))
            {
                _loaderSettings.WriteMessage($"File not found: {scriptFilename}");
                return;
            }
            using (var sqlConnection = new SqlConnection(_loaderSettings.SqlConnectionString))
            {
                var cmdText = string.Join(Environment.NewLine, File.ReadAllLines(scriptFilename));
                if(string.IsNullOrEmpty(cmdText)) return;
                Debug.WriteLine(cmdText);
                sqlConnection.Open();
                using (var command = new SqlCommand(cmdText, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
    }
}
