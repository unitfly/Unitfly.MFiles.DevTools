using CsvHelper;
using CsvHelper.Configuration;
using Serilog;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Unitfly.MFiles.DevTools.NameUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Rename;

namespace Unitfly.MFiles.DevTools.NameUpdate.App
{
    public class NameUpdaterApp : Renamer
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

        public void UpdateNames(VaultStructureElementFiles names, string csvDelimiter, bool dryRun)
        {
            if (names?.ObjectTypes != null)
            {
                UpdateObjTypeNames(RulesFromCsv(names.ObjectTypes, csvDelimiter), dryRun);
            }

            if (names?.ValueLists != null)
            {
                UpdateValueListNames(RulesFromCsv(names.ValueLists, csvDelimiter), dryRun);
            }

            if (names?.PropertyDefs != null)
            {
                UpdatePropertyDefNames(RulesFromCsv(names.PropertyDefs, csvDelimiter), dryRun);
            }

            if (names?.Classes != null)
            {
                UpdateClassNames(RulesFromCsv(names.Classes, csvDelimiter), dryRun);
            }

            if (names?.Workflows != null)
            {
                UpdateWorkflowNames(RulesFromCsv(names.Workflows, csvDelimiter), dryRun);
            }

            if (names?.States != null)
            {
                UpdateStateNames(RulesFromCsv(names.States, csvDelimiter), dryRun);
            }

            if (names?.StateTransitions != null)
            {
                UpdateStateTransitionNames(RulesFromCsv(names.StateTransitions, csvDelimiter), dryRun);
            }

            if (names?.UserGroups != null)
            {
                UpdateUserGroupNames(RulesFromCsv(names.UserGroups, csvDelimiter), dryRun);
            }

            if (names?.NamedACLs != null)
            {
                UpdateNamedACLNames(RulesFromCsv(names.NamedACLs, csvDelimiter), dryRun);
            }
        }

        private IEnumerable<RenameRule> RulesFromCsv(string file, string delimiter)
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

            var c = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter
            };
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, c))
            {
                return csv.GetRecords<CsvFile>()?.Select(f => f.ToRule()).ToList();
            }
        }
    }
}
