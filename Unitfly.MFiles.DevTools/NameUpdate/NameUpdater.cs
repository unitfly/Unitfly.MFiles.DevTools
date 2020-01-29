using MFilesAPI;
using Serilog;
using System;
using System.Collections.Generic;
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

        public void UpdateObjTypeNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.ObjectTypeOperations.GetObjectTypesAdmin()?.Cast<ObjTypeAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                UpdateObjTypeOrValueList(item, names, dryRun);
            }
        }

        public void UpdateValueListNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.ValueListOperations.GetValueListsAdmin()?.Cast<ObjTypeAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                if (item.ObjectType.RealObjectType)
                {
                    continue;
                }

                UpdateObjTypeOrValueList(item, names, dryRun);
            }
        }

        private void UpdateObjTypeOrValueList(ObjTypeAdmin item, Dictionary<string, string> names, bool dryRun)
        {
            var change = false;
            var old = item.ObjectType.NameSingular;
            if (names.ContainsKey(old))
            {
                var @new = names[old];

                item.ObjectType.NameSingular = @new;

                Update(item,
                    i => { change = change || true; },
                    old,
                    @new,
                    dryRun);
            }

            old = item.ObjectType.NamePlural;
            if (names.ContainsKey(old))
            {
                var @new = names[old];

                item.ObjectType.NamePlural = @new;

                Update(item,
                    i => { change = change || true; },
                    old,
                    @new,
                    dryRun);
            }

            if (change && !dryRun) Vault.ObjectTypeOperations.UpdateObjectTypeAdmin(item);
        }

        public void UpdateClassNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.ClassOperations.GetAllObjectClassesAdmin()?.Cast<ObjectClassAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                var old = item.Name;
                if (names.ContainsKey(old))
                {
                    var @new = names[old];

                    item.Name = @new;

                    Update(item,
                        i => Vault.ClassOperations.UpdateObjectClassAdmin(i),
                        old,
                        @new,
                        dryRun);
                }
            }
        }

        public void UpdateNamedACLNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.NamedACLOperations.GetNamedACLsAdmin()?.Cast<NamedACLAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                var old = item.NamedACL.Name;
                if (names.ContainsKey(old))
                {
                    var @new = names[old];

                    item.NamedACL.Name = @new;

                    Update(item,
                        i => Vault.NamedACLOperations.UpdateNamedACLAdmin(i),
                        old,
                        @new,
                        dryRun);
                }
            }
        }

        public void UpdateUserGroupNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.UserGroupOperations.GetUserGroupsAdmin()?.Cast<UserGroupAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                var old = item.UserGroup.Name;
                if (names.ContainsKey(old))
                {
                    var @new = names[old];

                    item.UserGroup.Name = @new;

                    Update(item,
                        i => Vault.UserGroupOperations.UpdateUserGroupAdmin(i),
                        old,
                        @new,
                        dryRun);
                }
            }
        }

        public void UpdateWorkflowNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                var old = item.Workflow.Name;
                if (names.ContainsKey(old))
                {
                    var @new = names[old];

                    item.Workflow.Name = @new;

                    Update(item,
                        i => Vault.WorkflowOperations.UpdateWorkflowAdmin(i),
                        old,
                        @new,
                        dryRun);
                }
            }
        }

        public void UpdateStateTransitionNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                var transitions = workflow.StateTransitions?.Cast<StateTransition>();
                if (transitions is null)
                {
                    continue;
                }

                bool change = false;
                foreach (var item in transitions)
                {
                    var old = item.Name;
                    if (names.ContainsKey(old))
                    {
                        var @new = names[old];

                        item.Name = @new;

                        Update(item,
                            (i) => { change = change || true; },
                            old,
                            @new,
                            dryRun);
                    }
                }

                if (change && !dryRun) Vault.WorkflowOperations.UpdateWorkflowAdmin(workflow);
            }
        }

        public void UpdateStateNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                var states = workflow.States?.Cast<StateAdmin>();
                if (states is null)
                {
                    continue;
                }

                bool change = false;
                foreach (var item in states)
                {
                    var old = item.Name;
                    if (names.ContainsKey(old))
                    {
                        var @new = names[old];

                        item.Name = @new;

                        Update(item,
                            (i) => { change = change || true; },
                            old,
                            @new,
                            dryRun);
                    }
                }

                if (change && !dryRun) Vault.WorkflowOperations.UpdateWorkflowAdmin(workflow);
            }
        }


        public void UpdatePropertyDefNames(Dictionary<string, string> names, bool dryRun)
        {
            if (names is null || !names.Any())
            {
                return;
            }

            var items = Vault.PropertyDefOperations.GetPropertyDefsAdmin()?.Cast<PropertyDefAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                var old = item.PropertyDef.Name;
                if (names.ContainsKey(old))
                {
                    var @new = names[old];

                    item.PropertyDef.Name = @new;

                    Update(item,
                        i => Vault.PropertyDefOperations.UpdatePropertyDefAdmin(i),
                        old,
                        @new,
                        dryRun);
                }
            }
        }
        
        private void Update<T>(T item, Action<T> updateAction, string oldName, string newName, bool dryRun)
        {
            try
            {
                if (!dryRun) updateAction(item);
                var msg = dryRun
                    ? "Would update {type} name {old} to {new}."
                    : "Updated {type} name {old} to {new}.";
                Log.Information(msg, PrettyName<T>(), oldName, newName);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error updating {type} name {old} to {new}.", PrettyName<T>(), oldName, newName);
            }
        }

        private static string PrettyName<T>()
        {
            var ret = typeof(T).Name.Trim();
            if (ret.EndsWith("Admin")) ret = ret.Substring(0, ret.Length - "Admin".Length);
            return ret;
        }
    }
}
