using MFilesAPI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Unitfly.MFiles.DevTools.Rename
{
    public class Renamer : ServerAdminApplication
    {
        public Renamer() { }

        public Renamer(
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

        public void UpdateObjTypeNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.ObjectTypeOperations.GetObjectTypesAdmin()?.Cast<ObjTypeAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                UpdateObjTypeOrValueList(rule, items, dryRun);
            }
        }

        public void UpdateValueListNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.ValueListOperations.GetValueListsAdmin()?.Cast<ObjTypeAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                UpdateObjTypeOrValueList(rule, items, dryRun);
            }
        }

        private void UpdateObjTypeOrValueList(RenameRule rule, IEnumerable<ObjTypeAdmin> items, bool dryRun)
        {
            var forUpdate = rule.GetObjTypes(items);
            if (forUpdate is null || !forUpdate.Any())
            {
                Log.Information("Rule {rule} found nothing to update.", rule.ToString());
            }

            foreach (var item in forUpdate)
            {
                rule.OldName = item.ObjectType.NameSingular;
                item.ObjectType.NameSingular = rule.NewName;
                item.ObjectType.NamePlural = rule.NewPluralName();
                Update(item,
                    i => Vault.ObjectTypeOperations.UpdateObjectTypeAdmin(item),
                    rule.OldName,
                    rule.NewName,
                    dryRun);
            }
        }


        public void UpdateClassNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.ClassOperations.GetAllObjectClassesAdmin()?.Cast<ObjectClassAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                var forUpdate = rule.GetObjectClasses(items);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }
                               
                foreach (var item in forUpdate)
                {
                    rule.OldName = item.Name;
                    item.Name = rule.NewName;
                    Update(item,
                        i => Vault.ClassOperations.UpdateObjectClassAdmin(item),
                        rule.OldName,
                        rule.NewName,
                        dryRun);
                }
            }
        }

        public void UpdateNamedACLNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.NamedACLOperations.GetNamedACLsAdmin()?.Cast<NamedACLAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                var forUpdate = rule.GetNamedACLs(items);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }

                foreach (var item in forUpdate)
                {
                    rule.OldName = item.NamedACL.Name;
                    item.NamedACL.Name = rule.NewName;
                    Update(item,
                        i => Vault.NamedACLOperations.UpdateNamedACLAdmin(item),
                        rule.OldName,
                        rule.NewName,
                        dryRun);
                }
            }
        }

        public void UpdateUserGroupNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.UserGroupOperations.GetUserGroupsAdmin()?.Cast<UserGroupAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                var forUpdate = rule.GetUserGroups(items);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }

                foreach (var item in forUpdate)
                {
                    rule.OldName = item.UserGroup.Name;
                    item.UserGroup.Name = rule.NewName;
                    Update(item,
                        i => Vault.UserGroupOperations.UpdateUserGroupAdmin(item),
                        rule.OldName,
                        rule.NewName,
                        dryRun);
                }
            }
        }

        public void UpdatePropertyDefNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.PropertyDefOperations.GetPropertyDefsAdmin()?.Cast<PropertyDefAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                var forUpdate = rule.GetPropertyDefs(items);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }

                foreach (var item in forUpdate)
                {
                    rule.OldName = item.PropertyDef.Name;
                    item.PropertyDef.Name = rule.NewName;
                    Update(item,
                        i => Vault.PropertyDefOperations.UpdatePropertyDefAdmin(item),
                        rule.OldName,
                        rule.NewName,
                        dryRun);
                }
            }
        }

        public void UpdateWorkflowNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var items = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (items == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }
                var forUpdate = rule.GetWorkflows(items);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }

                foreach (var item in forUpdate)
                {
                    rule.OldName = item.Workflow.Name;
                    item.Workflow.Name = rule.NewName;
                    Update(item,
                        i => Vault.WorkflowOperations.UpdateWorkflowAdmin(item),
                        rule.OldName,
                        rule.NewName,
                        dryRun);
                }
            }
        }

        public void UpdateStateTransitionNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null)
            {
                return;
            }

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                var forUpdate = rule.GetWorkflowStateTransitions(workflows);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }

                foreach (var kvp in forUpdate)
                {
                    var wf = kvp.Key;
                    var transitions = kvp.Value.Select(i => i.ID);
                    var oldNames = new HashSet<string>();
                    foreach (var transition in wf.StateTransitions?.Cast<IStateTransition>())
                    {
                        if (transitions.Contains(transition.ID))
                        {
                            oldNames.Add(transition.Name);
                            rule.OldName = transition.Name;
                            transition.Name = rule.NewName;
                        }
                    }

                    Update(wf,
                        i => Vault.WorkflowOperations.UpdateWorkflowAdmin(wf),
                        string.Join(", ", oldNames),
                        rule.NewName,
                        dryRun);

                }
            }
        }

        public void UpdateStateNames(IEnumerable<RenameRule> rules, bool dryRun)
        {
            if (rules is null || !rules.Any())
            {
                return;
            }

            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var rule in rules)
            {
                if (!rule.IsValid())
                {
                    Log.Warning("Invalid rename rule {rule}.", rule.ToString());
                    continue;
                }

                var forUpdate = rule.GetWorkflowStates(workflows);
                if (forUpdate is null || !forUpdate.Any())
                {
                    Log.Information("Rule {rule} found nothing to update.", rule.ToString());
                }

                foreach (var kvp in forUpdate)
                {
                    var workflow = kvp.Key;
                    var states = kvp.Value.Select(i => i.ID);
                    var oldNames = new HashSet<string>();
                    foreach (var state in workflow.States?.Cast<StateAdmin>())
                    {
                        if (states.Contains(state.ID))
                        {
                            oldNames.Add(state.Name);
                            rule.OldName = state.Name;
                            state.Name = rule.NewName;
                        }
                    }

                    Update(workflow,
                        i => Vault.WorkflowOperations.UpdateWorkflowAdmin(i),
                        string.Join(", ", oldNames),
                        rule.NewName,
                        dryRun);

                }
            }
        }

        private void Update<T>(T item, Action<T> updateAction, string oldName, string newName, bool dryRun)
        {
            if (oldName == newName)
            {
                Log.Information("Name {new} already up to date.", newName);
                return;
            }

            try
            {
                if (!dryRun)
                {
                    updateAction(item);
                }

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
