using CommandLine;
using Newtonsoft.Json;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.GenerateSql.App.Configuration;

namespace Unitfly.MFiles.DevTools.GenerateSql.App.Commands
{
    [Verb("print-config", HelpText = "Print configuration file.")]
    public class Print
    {
        public static int Execute(ref AppSettings appSettings, Print opts = null)
        {
            try
            {
                Log.Information("{config}", JsonConvert.SerializeObject(appSettings, Formatting.Indented));
                return 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "Error printing configuration from {file}.", "appsettings,json");
                return 1;
            }
        }
    }
}
