using CommandLine;
using System;
using Unitfly.MFiles.DevTools.AppBase.Commands;
using Unitfly.MFiles.DevTools.Rename.App.Commands;
using Unitfly.MFiles.DevTools.Rename.App.Configuration;

namespace Unitfly.MFiles.DevTools.Rename.App
{
    class Program : AppBase.Program<AppSettings>
    {
        public static RenamerApp Updater;

        new static void Main(string[] args)
        {
            AppBase.Program<AppSettings>.Main(args);

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
