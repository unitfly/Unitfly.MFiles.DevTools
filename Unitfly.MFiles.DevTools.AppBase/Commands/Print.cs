using CommandLine;
using Newtonsoft.Json;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AppBase.Configuration;

namespace Unitfly.MFiles.DevTools.AppBase.Commands
{
    [Verb("print-config", HelpText = "Print configuration file.")]
    public class Print
    {
        public static int Execute<T>(ref T appSettings, Print opts = null) where T : AppSettings, new()
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
