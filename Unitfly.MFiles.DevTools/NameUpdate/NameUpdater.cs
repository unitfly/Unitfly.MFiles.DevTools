using MFilesAPI;
using Serilog;
using System.Linq;
using Unitfly.MFiles.DevTools.CaseConverters;
using Unitfly.MFiles.DevTools.UpdateBehaviours;

namespace Unitfly.MFiles.DevTools.NameUpdate
{
    public class NameUpdater : ServerAdminApplication
    {
        public NameUpdater() { }

        public NameUpdater(
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
            : base(loginType: loginType,
                vaultName: vaultName,
                username: username,
                password: password,
                domain: domain,
                protocolSequence: protocolSequence,
                networkAddress: networkAddress,
                endpoint: endpoint,
                encryptedConnection: encryptedConnection,
                localComputerName: localComputerName)
        {
            Log.Information("Logged in to vault {vault} as {loginType} user {user}.",
                vaultName, loginType, string.IsNullOrWhiteSpace(domain) ? username : $"{domain}\\{username}");
        }

        public void UpdateNamedACLName(string oldName, string newName, CaseConverter converter, IUpdateBehaviour behaviour, bool dryRun)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            var replaceItems = Vault.NamedACLOperations.GetNamedACLsAdmin()?.Cast<NamedACLAdmin>()?.Where(item => item.NamedACL.Name == oldName);
            if (replaceItems == null)
            {
                return;
            }

            foreach (var item in replaceItems)
            {
                item.NamedACL.Name = newName;

                if (!dryRun)
                {
                    Vault.NamedACLOperations.UpdateNamedACLAdmin(item);
                }
            }
        }

        public void UpdateUserGroupName(string oldName, string newName, bool dryRun)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            var replaceItems = Vault.UserGroupOperations.GetUserGroupsAdmin()?.Cast<UserGroupAdmin>()?.Where(item => item.UserGroup.Name == oldName);
            if (replaceItems == null)
            {
                return;
            }

            foreach (var item in replaceItems)
            {
                item.UserGroup.Name = newName;

                if (!dryRun)
                {
                    Vault.UserGroupOperations.UpdateUserGroupAdmin(item);
                }
            }

        }

        public void UpdateStateTransitionNames(string oldName, string newName, bool dryRun)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                var transitions = workflow.StateTransitions?.Cast<StateTransition>()?.Where(item => item.Name == oldName);
                if (transitions is null)
                {
                    continue;
                }

                foreach (var transition in transitions)
                {
                    transition.Name = newName;
                }

                if (!dryRun)
                {
                    Vault.WorkflowOperations.UpdateWorkflowAdmin(workflow);
                }
            }
        }

        public void UpdateStateNames(string oldName, string newName, bool dryRun)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                var states = workflow.States?.Cast<StateAdmin>()?.Where(item => item.Name == oldName);
                if (states is null)
                {
                    continue;
                }

                foreach (var state in states)
                {
                    state.Name = newName;
                }

                if (!dryRun)
                {
                    Vault.WorkflowOperations.UpdateWorkflowAdmin(workflow);
                }
            }
        }


        public void UpdatePropertyDefName(string oldName, string newName, CaseConverter converter, IUpdateBehaviour behaviour, bool dryRun)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            var replaceItems = Vault.PropertyDefOperations.GetPropertyDefsAdmin()?.Cast<PropertyDefAdmin>()?.Where(item => item.PropertyDef.Name == oldName);
            if (replaceItems == null)
            {
                return;
            }

            foreach (var item in replaceItems)
            {
                item.PropertyDef.Name = newName;

                if (!dryRun)
                {
                    Vault.PropertyDefOperations.UpdatePropertyDefAdmin(item);
                }
            }
        }
    }
}
