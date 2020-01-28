using CommandLine;
using Serilog;
using System;
using System.Collections.Generic;
using Unitfly.MFiles.DevTools.AppBase.Commands;
using Unitfly.MFiles.DevTools.GenerateSql;
using Unitfly.MFiles.DevTools.GenerateSql.App.Commands;
using Unitfly.MFiles.DevTools.GenerateSql.App.Configuration;

namespace Unitfly.MFiles.DevTools.GenerateSql.App
{
    class Program : AppBase.Program<AppSettings>
    {
        public static SqlGenerator Generator;

        new static void Main(string[] args)
        {
            AppBase.Program<AppSettings>.Main(args);

            Reload.Execute(ref AppSettings);

            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                var arg = input.Contains(" ")
                    ? new string[] { input.Substring(0, input.IndexOf(" ")), input.Substring(input.IndexOf(" ") + 1) }
                    : new string[] { input };

                Parser.Default
                    .ParseArguments<Login, CreateQuery, UpdateQuery, InsertQuery, DeleteQuery, Print, Reload, Exit>(arg)
                    .MapResult(
                      (Login opts) => Login.Execute(ref AppSettings, ref Generator, opts),
                      (CreateQuery opts) => new CreateQuery().Execute(ref AppSettings, ref Generator, opts),
                      (UpdateQuery opts) => new UpdateQuery().Execute(ref AppSettings, ref Generator, opts),
                      (InsertQuery opts) => new InsertQuery().Execute(ref AppSettings, ref Generator, opts),
                      (DeleteQuery opts) => new DeleteQuery().Execute(ref AppSettings, ref Generator, opts),
                      (Print opts) => Print.Execute(ref AppSettings, opts),
                      (Reload opts) => Reload.Execute(ref AppSettings, opts),
                      (Exit opts) => Exit.Execute(opts),
                      errs => 1);

                if (arg.Length == 1 && arg[0] == "exit") break;
            }

            Exit.Execute();
        }
    }
}
