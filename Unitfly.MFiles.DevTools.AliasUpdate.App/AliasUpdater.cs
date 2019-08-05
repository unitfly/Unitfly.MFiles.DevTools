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

        public void SetAliases(AliasTemplates names, CaseConverter converter, UpdateBehaviour behaviour, bool dryRun)
        {
            var aliasUpdateBehaviour = behaviour.GetUpdateBehaviour();
            if (names?.ObjectType != null)
            {
                UpdateObjTypeAliases(names.ObjectType, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.ValueList!= null)
            {
                UpdateValueListAliases(names.ValueList, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.PropertyDef!= null)
            {
                UpdatePropertyDefAliases(names.PropertyDef, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.Class!= null)
            {
                UpdateClassAliases(names.Class, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.Workflow!= null)
            {
                UpdateWorkflowAliases(names.Workflow, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.State!= null)
            {
                UpdateStateAliases(names.State, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.StateTransition!= null)
            {
                UpdateStateTransitionAliases(names.StateTransition, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.UserGroup!= null)
            {
                UpdateUserGroupAliases(names.UserGroup, converter, aliasUpdateBehaviour, dryRun);
            }

            if (names?.NamedACL!= null)
            {
                UpdateNamedACLAliases(names.NamedACL, converter, aliasUpdateBehaviour, dryRun);
            }
        }
    }
}
