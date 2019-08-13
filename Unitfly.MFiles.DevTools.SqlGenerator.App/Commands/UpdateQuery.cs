using CommandLine;
using Serilog;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Commands
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
