using System.Collections.Generic;

namespace ComLog.WinForms.Utils
{
    public class MacroRunSettings
    {
        public string MacroWorkBook { get; set; }
        public string MacroName { get; set; }
        public string SourceFilename { get; set; }
        public string DestinationFilename { get; set; }
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
    }
}