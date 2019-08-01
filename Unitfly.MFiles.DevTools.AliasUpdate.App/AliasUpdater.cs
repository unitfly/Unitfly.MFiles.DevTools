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
            if (names?.ObjectType != null)
            {
                UpdateObjTypeAliases(names.ObjectType, converter, aliasUpdateBehaviour);
            }

            if (names?.ValueList!= null)
            {
                UpdateValueListAliases(names.ValueList, converter, aliasUpdateBehaviour);
            }

            if (names?.PropertyDef!= null)
            {
                UpdatePropertyDefAliases(names.PropertyDef, converter, aliasUpdateBehaviour);
            }

            if (names?.Class!= null)
            {
                UpdateClassAliases(names.Class, converter, aliasUpdateBehaviour);
            }

            if (names?.Workflow!= null)
            {
                UpdateWorkflowAliases(names.Workflow, converter, aliasUpdateBehaviour);
            }

            if (names?.State!= null)
            {
                UpdateStateAliases(names.State, converter, aliasUpdateBehaviour);
            }

            if (names?.StateTransition!= null)
            {
                UpdateStateTransitionAliases(names.StateTransition, converter, aliasUpdateBehaviour);
            }

            if (names?.UserGroup!= null)
            {
                UpdateUserGroupAliases(names.UserGroup, converter, aliasUpdateBehaviour);
            }

            if (names?.NamedACL!= null)
            {
                UpdateNamedACLAliases(names.NamedACL, converter, aliasUpdateBehaviour);
            }
        }
    }
}
