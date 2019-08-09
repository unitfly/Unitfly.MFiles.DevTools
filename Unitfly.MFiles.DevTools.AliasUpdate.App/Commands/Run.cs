using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Commands
{
    [Verb("run", HelpText = "Execute alias update.")]
    public class Run
    {
        [Option('d', "dry-run", Required = false, HelpText = "Only show which aliases will be updated.")]
        public bool DryRun { get; set; }

        public static int Execute(ref AppSettings appSettings, ref AliasUpdaterApp updater, Run opts)
        {
            try
            {
                if (Login.Execute(ref appSettings, ref updater) != 0)
                {
                    return 1;
                }

                updater.SetAliases(appSettings.AliasTemplates, appSettings.ItemNameTransform.CasingConverter, appSettings.AliasUpdateBehaviour, opts.DryRun);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error updating aliases.");
                return 1;
            }
            return 0;
        }
    }
}
