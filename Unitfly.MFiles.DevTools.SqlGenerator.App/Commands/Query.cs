using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AppBase.Commands;
using Unitfly.MFiles.DevTools.GenerateSql.App.Configuration;

namespace Unitfly.MFiles.DevTools.GenerateSql.App.Commands
{
    public abstract class Query
    {
        [Value(0, MetaName = "Class", Required = true, HelpText = "M-Files class to generate sql query for.")]
        public string Class { get; set; }

        public int Execute(ref AppSettings appSettings, ref SqlGenerator converter, Query opts)
        {
            try
            {
                if (Login.Execute(ref appSettings, ref converter) != 0)
                {
                    return 1;
                }

                var table = converter.ConvertClassToTable(opts.Class, appSettings.ItemNameTransform.CasingConverter, appSettings.IgnoreBuiltinProperties);
                PrintQuery(table);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error generating sql queries for class.");
                return 1;
            }
            return 0;
        }

        protected abstract void PrintQuery(Table table);
    }
}
