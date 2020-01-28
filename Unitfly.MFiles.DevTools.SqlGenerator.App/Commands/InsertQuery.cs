using CommandLine;
using Serilog;
using Unitfly.MFiles.DevTools.GenerateSql;

namespace Unitfly.MFiles.DevTools.GenerateSql.App.Commands
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
