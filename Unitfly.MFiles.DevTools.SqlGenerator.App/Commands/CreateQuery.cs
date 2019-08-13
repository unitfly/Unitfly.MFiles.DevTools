using CommandLine;
using Serilog;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Commands
{
    [Verb("create", HelpText = "Generate sql CREATE query for an M-Files class.")]
    public class CreateQuery : Query
    {
        protected override void PrintQuery(Table table)
        {
            Log.Information(table.CreateQuery);
        }
    }
}
