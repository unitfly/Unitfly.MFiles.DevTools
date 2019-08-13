using CommandLine;
using Serilog;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Commands
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
