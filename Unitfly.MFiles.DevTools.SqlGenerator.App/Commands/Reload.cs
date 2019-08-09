using CommandLine;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using Unitfly.MFiles.DevTools.SqlGenerator.App.Configuration;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Commands
{
    [Verb("reload-config", HelpText = "Reload settings from configuration file.")]
    public class Reload
    {
        public static int Execute(ref AppSettings appSettings, ref ClassSqlGenerator converter, Reload opts = null)
        {
            try
            {
                var configuration = new ConfigurationBuilder().
                    SetBasePath(Directory.GetCurrentDirectory()).
                    AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                    Build();

                appSettings = new AppSettings();
                configuration.Bind(appSettings);
                Log.Information("Loaded config from {file}.", "appsettings.json");

                return 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "Error loading configuration from {file}.", "appsettings,json");
                return 1;
            }
        }
    }
}
