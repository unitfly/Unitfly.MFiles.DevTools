﻿namespace Unitfly.MFiles.DevTools.NameUpdate.App.Configuration
{
    public class AppSettings : Unitfly.MFiles.DevTools.AppBase.Configuration.AppSettings
    {
        public VaultStructureElementFiles CsvFiles { get; set; }

        public string CsvDelimiter { get; set; }
    }
}
