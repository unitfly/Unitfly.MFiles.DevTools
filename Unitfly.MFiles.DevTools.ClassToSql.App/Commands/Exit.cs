using CommandLine;
using Serilog;

namespace Unitfly.MFiles.DevTools.ClassToSql.App.Commands
{
    [Verb("exit", HelpText = "Exit the application.")]
    public class Exit
    {
        public static int Execute(Exit opts = null)
        {
            Log.Debug("Exiting application.");
            Log.CloseAndFlush();
            return 0;
        }
    }
}
