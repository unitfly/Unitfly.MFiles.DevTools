using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AppBase.Commands;
using Unitfly.MFiles.DevTools.AppBase.Configuration;

namespace Unitfly.MFiles.DevTools.AppBase
{
    public class Program<T> where T : AppSettings, new()
    {
        public static T AppSettings;

        protected static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, outputTemplate: "{Message:lj}{NewLine}{Exception}")
                .WriteTo.File(path: "./logs/log-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, shared: true)
                .CreateLogger();

            Log.Debug("Starting application.");
        }
    }
}
