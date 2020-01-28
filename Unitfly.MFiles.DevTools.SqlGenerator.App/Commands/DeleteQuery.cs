using CommandLine;
using Serilog;
using Unitfly.MFiles.DevTools.GenerateSql;

namespace Unitfly.MFiles.DevTools.GenerateSql.App.Commands
{
    [Verb("delete", HelpText = "Generate sql DELETE query for an M-Files class.")]
    public class DeleteQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.DeleteQuery);
        }
    }
}
