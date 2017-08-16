namespace ComLog.Loader.Core
{
    public class LoaderSettings
    {
        public string LoadedFilePath { get; set; }
        public string XlsConnectionString => $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={LoadedFilePath};Extended Properties=Excel 8.0";
        public string SqlConnectionString { get; set; }
        public string BulkTableName { get; set; }
        public string BulkSelectStatement { get; set; }
        public string BeforeLoadScriptFilename { get; set; }
        public string AfterLoadScriptFilename { get; set; }
        public delegate void MessageWriter(string message);
        public event MessageWriter OnMessage;

        public void WriteMessage(string message)
        {
            OnMessage?.Invoke(message);
        }
    }
}
