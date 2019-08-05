using CommandLine;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Commands;
using Unitfly.MFiles.DevTools.Common;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    class Program
    {
        public static AliasUpdater Updater;
        public static AppSettings AppSettings;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, outputTemplate: "{Message:lj}{NewLine}{Exception}")
                .WriteTo.File(path: "./logs/log-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, shared: true)
                .CreateLogger();

            Log.Debug("Starting application.");

            Reload.Execute(ref AppSettings);

            while (true)
            {
                Console.Write("> ");
                var arg = Console.ReadLine().Split(' ');

                Parser.Default
                    .ParseArguments<Exit, Login, Run, Reload, Print>(arg)
                    .MapResult(
                      (Login opts) => Login.Execute(ref AppSettings, ref Updater, opts),
                      (Run opts) => Run.Execute(ref AppSettings, ref Updater, opts),
                      (Reload opts) => Reload.Execute(ref AppSettings, opts),
                      (Print opts) => Print.Execute(ref AppSettings, opts),
                      (Exit opts) => Exit.Execute(opts),
                      errs => 1);

                if (arg.Length == 1 && arg[0] == "exit") break;
            }

            Exit.Execute();
        }
        
    }
}
