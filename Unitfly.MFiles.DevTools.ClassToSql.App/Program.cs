using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using Unitfly.MFiles.DevTools.ClassToSql.App.Commands;
using Unitfly.MFiles.DevTools.ClassToSql.App.Configuration;

namespace Unitfly.MFiles.DevTools.ClassToSql.App
{
    class Program
    {
        public static ClassToSqlConverter Converter;
        public static AppSettings AppSettings;

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, outputTemplate: "{Message:lj}{NewLine}{Exception}")
                .WriteTo.File(path: "./logs/log-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, shared: true)
                .CreateLogger();

            Log.Debug("Starting application.");

            Reload.Execute(ref AppSettings, ref Converter);

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                var arg = input.Contains(" ")
                    ? new string[] { input.Substring(0, input.IndexOf(" ")), input.Substring(input.IndexOf(" ") + 1) }
                    : new string[] { input };

                Parser.Default
                    .ParseArguments<Exit, Login, CreateQuery, UpdateQuery, InsertQuery, DeleteQuery, Reload, Print>(arg)
                    .MapResult(
                      (Login opts) => Login.Execute(ref AppSettings, ref Converter, opts),
                      (CreateQuery opts) => new CreateQuery().Execute(ref AppSettings, ref Converter, opts),
                      (UpdateQuery opts) => new UpdateQuery().Execute(ref AppSettings, ref Converter, opts),
                      (InsertQuery opts) => new InsertQuery().Execute(ref AppSettings, ref Converter, opts),
                      (DeleteQuery opts) => new DeleteQuery().Execute(ref AppSettings, ref Converter, opts),
                      (Reload opts) => Reload.Execute(ref AppSettings, ref Converter, opts),
                      (Print opts) => Print.Execute(ref AppSettings, opts),
                      (Exit opts) => Exit.Execute(opts),
                      errs => 1);

                if (arg.Length == 1 && arg[0] == "exit") break;
            }

            Exit.Execute();
        }
    }
}
