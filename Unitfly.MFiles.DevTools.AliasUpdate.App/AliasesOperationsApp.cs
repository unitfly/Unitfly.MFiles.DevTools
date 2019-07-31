using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    public class AliasesOperationsApp : AliasesOperations
    {
        public AliasesOperationsApp(string vaultName, string loginType, string username, string password, string domain = null) : base(vaultName, loginType, username, password, domain)
        {
        }

        public void SetAliases(AliasTemplates names, CaseConverter converter, UpdateBehaviour behaviour)
        {
            var aliasUpdateBehaviour = behaviour.GetUpdateBehaviour();
            if (!string.IsNullOrWhiteSpace(names?.ObjectType))
            {
                UpdateObjTypeAliases(names.ObjectType, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.ValueList))
            {
                UpdateValueListAliases(names.ValueList, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.PropertyDef))
            {
                UpdatePropertyDefAliases(names.PropertyDef, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.Class))
            {
                UpdateClassAliases(names.Class, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.Workflow))
            {
                UpdateWorkflowAliases(names.Workflow, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.State))
            {
                UpdateStateAliases(names.State, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.StateTransition))
            {
                UpdateStateTransitionAliases(names.StateTransition, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.UserGroup))
            {
                UpdateUserGroupAliases(names.UserGroup, converter, aliasUpdateBehaviour);
            }

            if (!string.IsNullOrWhiteSpace(names?.NamedACL))
            {
                UpdateNamedACLAliases(names.NamedACL, converter, aliasUpdateBehaviour);
            }
        }
    }
}
