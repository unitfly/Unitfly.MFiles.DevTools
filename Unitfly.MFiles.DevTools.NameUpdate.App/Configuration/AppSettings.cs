namespace Unitfly.MFiles.DevTools.NameUpdate.App.Configuration
{
    public class AppSettings : Unitfly.MFiles.DevTools.AppBase.Configuration.AppSettings
    {
        public VaultStructureElements Names { get; set; }

        public VaultStructureElementFiles CsvFiles { get; set; }

        public string CsvDelimiter { get; set; }
    }
}
