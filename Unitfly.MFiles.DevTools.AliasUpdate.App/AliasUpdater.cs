using Serilog;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Common;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    public class AliasUpdater : AliasesOperations
    {
        public AliasUpdater(LoginType loginType, string vaultName, string username, string password,
            string domain = null, string protocolSequence = "ncacn_ip_tcp", string networkAddress = "localhost",
            string endpoint = "2266", bool encryptedConnection = false, string localComputerName = "")
            : base(Log.Logger, 
                  loginType: loginType,
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
