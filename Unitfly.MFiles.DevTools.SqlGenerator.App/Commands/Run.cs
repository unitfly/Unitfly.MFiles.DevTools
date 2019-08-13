using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.SqlGenerator.App.Configuration;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Commands
{
    public abstract class Query
    {
        [Value(0, MetaName = "Class", Required = true, HelpText = "M-Files class to enerate sql query for.")]
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

    [Verb("create-query", HelpText = "Generate sql CREATE query for an M-Files class.")]
    public class CreateQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.CreateQuery);
        }
    }

    [Verb("update-query", HelpText = "Generate sql UPDATE query for an M-Files class.")]
    public class UpdateQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.UpdateQuery);
        }
    }

    [Verb("insert-query", HelpText = "Generate sql INSERT query for an M-Files class.")]
    public class InsertQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.InsertIntoQuery);
        }
    }

    [Verb("delete-query", HelpText = "Generate sql DELETE query for an M-Files class.")]
    public class DeleteQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.DeleteQuery);
        }
    }
}
