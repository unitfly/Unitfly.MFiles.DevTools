using MFilesAPI;
using System;
using System.Linq;
using Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers;
using Unitfly.MFiles.DevTools.Common;
using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Unitfly.MFiles.DevTools.Common.UpdateBehaviours;

namespace Unitfly.MFiles.DevTools.AliasUpdate
{
    public class AliasesOperations : VaultAdmin
    {
        private static int[] _ignorePropDefs = new int[]
        {
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefCreated,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefLastModified,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefSingleFileObject,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefLastModifiedBy,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefStatusChanged,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefCreatedBy,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefSizeOnServerThisVersion,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefSizeOnServerAllVersions,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefMarkedForArchiving,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefObjectChanged,
            (int)MFBuiltInPropertyDef.MFBuiltInPropertyDefClassGroups
        };

        public AliasesOperations(string vaultName, string loginType, string username, string password, string domain = null)
            : base(vaultName, loginType, username, password, domain)
        {
        }

        
        public void UpdateUserGroupAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new UserGroupNameParser(nameTemplate, converter);
            var groups = Vault.UserGroupOperations.GetUserGroupsAdmin()?.Cast<UserGroupAdmin>();
            if (groups == null) return;

            foreach (var group in groups)
            {
                UpdateAlias(group,
                    (g) => Vault.UserGroupOperations.UpdateUserGroupAdmin(g),
                    parser,
                    behaviour,
                    group.SemanticAliases);
            }
        }

        public void UpdateNamedACLAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new NamedACLNameParser(nameTemplate, converter);
            var namedAcls = Vault.NamedACLOperations.GetNamedACLs()?.Cast<NamedACL>();
            if (namedAcls == null) return;

            foreach (var namedAcl in namedAcls)
            {
                var namedAclAdmin = Vault.NamedACLOperations.GetNamedACLAdmin(namedAcl.ID);
                UpdateAlias(namedAclAdmin,
                    (n) => Vault.NamedACLOperations.UpdateNamedACLAdmin(n),
                    parser,
                    behaviour,
                    namedAclAdmin.SemanticAliases);
            }
        }

        public void UpdateStateTransitionAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new StateTransitionNameParser(nameTemplate, converter);
            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                var transitions = workflow.StateTransitions?.Cast<StateTransition>();
                if (transitions is null) continue;

                foreach (var transition in transitions)
                {
                    UpdateAlias(transition,
                        (s) => { },
                        parser,
                        behaviour,
                        transition.SemanticAliases);
                }

                Vault.WorkflowOperations.UpdateWorkflowAdmin(workflow);
            }
        }

        public void UpdateStateAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new StateNameParser(nameTemplate, converter);
            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                var states = workflow.States?.Cast<StateAdmin>();
                if (states is null) continue;

                foreach (var state in states)
                {
                    UpdateAlias(state,
                        (s) => { },
                        parser,
                        behaviour,
                        state.SemanticAliases);
                }

                Vault.WorkflowOperations.UpdateWorkflowAdmin(workflow);
            }
        }

        public void UpdateWorkflowAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new WorkflowNameParser(nameTemplate, converter);
            var workflows = Vault.WorkflowOperations.GetWorkflowsAdmin()?.Cast<WorkflowAdmin>();
            if (workflows == null) return;

            foreach (var workflow in workflows)
            {
                UpdateAlias(workflow,
                    (w) => Vault.WorkflowOperations.UpdateWorkflowAdmin(w),
                    parser,
                    behaviour,
                    workflow.SemanticAliases);
            }
        }

        public void UpdatePropertyDefAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new PropertyDefNameParser(nameTemplate, converter);
            var propDefs = Vault.PropertyDefOperations.GetPropertyDefsAdmin()?.Cast<PropertyDefAdmin>();
            if (propDefs == null) return;

            foreach (var propDef in propDefs)
            {
                UpdateAlias(propDef,
                    (p) => Vault.PropertyDefOperations.UpdatePropertyDefAdmin(p),
                    parser,
                    behaviour,
                    propDef.SemanticAliases);
            }
        }

        public void UpdateValueListAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new ValueListNameParser(nameTemplate, converter);
            var valueLists = Vault.ValueListOperations.GetValueListsAdmin()?.Cast<ObjTypeAdmin>();
            if (valueLists == null) return;

            foreach (var valueList in valueLists)
            {
                UpdateAlias(valueList,
                    (vl) => Vault.ValueListOperations.UpdateValueListAdmin(vl),
                    parser,
                    behaviour,
                    valueList.SemanticAliases);
            }
        }

        public void UpdateClassAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new ClassNameParser(nameTemplate, converter);
            var classesAdmin = Vault.ClassOperations.GetAllObjectClassesAdmin()?.Cast<ObjectClassAdmin>();
            if (classesAdmin == null) return;

            foreach (var classAdmin in classesAdmin)
            {
                UpdateAlias(classAdmin,
                    (ca) => UpdateClassAdmin(ca),
                    parser,
                    behaviour,
                    classAdmin.SemanticAliases);
            }
        }

        public void UpdateObjTypeAliases(string nameTemplate, CaseConverter converter, IUpdateBehaviour behaviour)
        {
            var parser = new ObjectTypeNameParser(nameTemplate, converter);
            var objTypes = Vault.ObjectTypeOperations.GetObjectTypesAdmin()?.Cast<ObjTypeAdmin>();
            if (objTypes == null) return;

            foreach (var objType in objTypes)
            {
                UpdateAlias(objType,
                    (ot) => Vault.ObjectTypeOperations.UpdateObjectTypeAdmin(ot),
                    parser,
                    behaviour,
                    objType.SemanticAliases);
            }
        }

        private void UpdateClassAdmin(ObjectClassAdmin classAdmin)
        {
            var @class = Vault.ClassOperations.GetObjectClass(classAdmin.ID);
            classAdmin.AssociatedPropertyDefs = new AssociatedPropertyDefs();
            foreach (var apd in @class.AssociatedPropertyDefs.Cast<AssociatedPropertyDef>())
            {
                if (_ignorePropDefs.Contains(apd.PropertyDef))
                {
                    continue;
                }

                classAdmin.AssociatedPropertyDefs.Add(-1, apd);
            }
            Vault.ClassOperations.UpdateObjectClassAdmin(classAdmin);
        }

        private void UpdateAlias<T>(T item, Action<T> updateAction, ItemNameParser<T> parser, IUpdateBehaviour behaviour, ISemanticAliases aliases)
        {
            try
            {
                var expanded = parser.Expand(item, Vault);
                var newAlias = behaviour.UpdateAlias(aliases.Value, expanded);

                if (aliases.Value == newAlias) return;

                aliases.Value = newAlias;
                updateAction(item);
            }
            catch (Exception)
            {
                // TODO log
            }
        }
    }
}
