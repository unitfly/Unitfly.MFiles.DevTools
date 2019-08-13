using CommandLine;
using Serilog;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Commands
{
    [Verb("insert", HelpText = "Generate sql INSERT query for an M-Files class.")]
    public class InsertQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.InsertIntoQuery);
        }
    }
}
