using CommandLine;
using Serilog;
using Unitfly.MFiles.DevTools.GenerateSql;

namespace Unitfly.MFiles.DevTools.GenerateSql.App.Commands
{
    [Verb("update", HelpText = "Generate sql UPDATE query for an M-Files class.")]
    public class UpdateQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.UpdateQuery);
        }
    }
}
