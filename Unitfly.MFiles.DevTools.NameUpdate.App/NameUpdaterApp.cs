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
