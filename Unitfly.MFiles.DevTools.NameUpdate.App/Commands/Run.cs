using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AppBase.Commands;
using Unitfly.MFiles.DevTools.NameUpdate.App.Configuration;

namespace Unitfly.MFiles.DevTools.NameUpdate.App.Commands
{
    [Verb("run", HelpText = "Execute name update.")]
    public class Run
    {
        [Option('d', "dry-run", Required = false, HelpText = "Only show which aliases will be updated.")]
        public bool DryRun { get; set; }

        public static int Execute(ref AppSettings appSettings, ref NameUpdaterApp updater, Run opts)
        {
            try
            {
                if (Login.Execute(ref appSettings, ref updater) != 0)
                {
                    return 1;
                }

                updater.UpdateNames(appSettings.Names, opts.DryRun);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error updating names.");
                return 1;
            }
            return 0;
        }
    }
}
