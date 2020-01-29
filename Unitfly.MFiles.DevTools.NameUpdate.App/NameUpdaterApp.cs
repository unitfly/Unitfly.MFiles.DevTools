using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unitfly.MFiles.DevTools.NameUpdate.App.Configuration;

namespace Unitfly.MFiles.DevTools.NameUpdate.App
{
    public class NameUpdaterApp : NameUpdater
    {
        public NameUpdaterApp()
        {
        }

        public NameUpdaterApp(
            LoginType loginType,
            string vaultName,
            string username,
            string password,
            string domain = null,
            string protocolSequence = "ncacn_ip_tcp",
            string networkAddress = "localhost",
            string endpoint = "2266",
            bool encryptedConnection = false,
            string localComputerName = "")
            : base(loginType,
                  vaultName,
                  username,
                  password,
                  domain,
                  protocolSequence,
                  networkAddress,
                  endpoint,
                  encryptedConnection,
                  localComputerName)
        {
        }

        private Dictionary<string, string> CsvToDict(string file, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                return null;
            }

            if (!File.Exists(file))
            {
                Log.Warning("File {file} doesn't exist.", file);
                return null;
            }

            if (string.IsNullOrWhiteSpace(delimiter))
            {
                Log.Warning("Empty deilimter is not allowed.");
                return null;
            }

            var lines = File.ReadLines(file);
            if (lines is null)
            {
                return null;
            }

            var fields = lines.Select(line => line.Split(new string[] { delimiter }, System.StringSplitOptions.RemoveEmptyEntries));
            if (fields is null)
            {
                return null;
            }

            var dict = new Dictionary<string, string>();
            foreach (var field in fields)
            {
                if (field.Length != 2)
                {
                    Log.Warning("Invalid line in {file}: {line}. " +
                        "Expected {expected} fields, got {actual}.", 
                        file, string.Join(delimiter, fields), 2, field.Length);
                    continue;
                }

                dict[field[0]] = field[1];
            }

            return dict;
        }

        public void UpdateNames(VaultStructureElementFiles names, string csvDelimiter, bool dryRun)
        {
            if (names?.ObjectTypes != null)
            {
                UpdateObjTypeNames(CsvToDict(names.ObjectTypes, csvDelimiter), dryRun);
            }

            if (names?.ValueLists != null)
            {
                UpdateValueListNames(CsvToDict(names.ValueLists, csvDelimiter), dryRun);
            }

            if (names?.PropertyDefs != null)
            {
                UpdatePropertyDefNames(CsvToDict(names.PropertyDefs, csvDelimiter), dryRun);
            }

            if (names?.Classes != null)
            {
                UpdateClassNames(CsvToDict(names.Classes, csvDelimiter), dryRun);
            }

            if (names?.Workflows != null)
            {
                UpdateWorkflowNames(CsvToDict(names.Workflows, csvDelimiter), dryRun);
            }

            if (names?.States != null)
            {
                UpdateStateNames(CsvToDict(names.States, csvDelimiter), dryRun);
            }

            if (names?.StateTransitions != null)
            {
                UpdateStateTransitionNames(CsvToDict(names.StateTransitions, csvDelimiter), dryRun);
            }

            if (names?.UserGroups != null)
            {
                UpdateUserGroupNames(CsvToDict(names.UserGroups, csvDelimiter), dryRun);
            }

            if (names?.NamedACLs != null)
            {
                UpdateNamedACLNames(CsvToDict(names.NamedACLs, csvDelimiter), dryRun);
            }
        }

        public void UpdateNames(VaultStructureElements names, bool dryRun)
        {
            if (names?.ObjectTypes != null)
            {
                UpdateObjTypeNames(names.ObjectTypes, dryRun);
            }

            if (names?.ValueLists != null)
            {
                UpdateValueListNames(names.ValueLists, dryRun);
            }

            if (names?.PropertyDefs != null)
            {
                UpdatePropertyDefNames(names.PropertyDefs, dryRun);
            }

            if (names?.Classes != null)
            {
                UpdateClassNames(names.Classes, dryRun);
            }

            if (names?.Workflows != null)
            {
                UpdateWorkflowNames(names.Workflows, dryRun);
            }

            if (names?.States != null)
            {
                UpdateStateNames(names.States, dryRun);
            }

            if (names?.StateTransitions != null)
            {
                UpdateStateTransitionNames(names.StateTransitions, dryRun);
            }

            if (names?.UserGroups != null)
            {
                UpdateUserGroupNames(names.UserGroups, dryRun);
            }

            if (names?.NamedACLs != null)
            {
                UpdateNamedACLNames(names.NamedACLs, dryRun);
            }
        }
    }
}
