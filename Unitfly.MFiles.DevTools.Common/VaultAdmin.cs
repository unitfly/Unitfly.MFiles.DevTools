using MFilesAPI;
using System;

namespace Unitfly.MFiles.DevTools.Common
{

    public class VaultAdmin
    {
        protected IVault Vault;

        public VaultAdmin(LoginType loginType, string vaultName, string username, string password,
            string domain = null, string protocolSequence = "ncacn_ip_tcp", string networkAddress = "localhost",
            string endpoint = "2266", bool encryptedConnection = false, string localComputerName = "")
        {
            Vault = GetVaultAdmin(loginType: loginType,
                vaultName: vaultName,
                username: username,
                password: password,
                domain: domain,
                protocolSequence: protocolSequence,
                networkAddress: networkAddress,
                endpoint: endpoint,
                encryptedConnection: encryptedConnection,
                localComputerName: localComputerName);
        }

        private static IVault GetVaultAdmin(LoginType loginType, string vaultName, string username, string password,
            string domain = null, string protocolSequence = "ncacn_ip_tcp", string networkAddress = "localhost",
            string endpoint = "2266", bool encryptedConnection = false, string localComputerName = "")
        {
            var authType = MFAuthType.MFAuthTypeUnknown;
            switch (loginType)
            {
                case LoginType.Windows:
                    authType = username is null
                        ? MFAuthType.MFAuthTypeLoggedOnWindowsUser
                        : MFAuthType.MFAuthTypeSpecificWindowsUser;
                    break;
                case LoginType.MFiles:
                    authType = MFAuthType.MFAuthTypeSpecificMFilesUser;
                    break;
                default:
                    break;
            }

            var serverApp = new MFilesServerApplication();
            serverApp.ConnectAdministrativeEx(AuthType: authType,
                UserName: username,
                Password: password,
                Domain: domain,
                ProtocolSequence: protocolSequence,
                NetworkAddress: networkAddress,
                Endpoint: endpoint,
                EncryptedConnection: encryptedConnection,
                LocalComputerName: localComputerName);

            var vault = serverApp.GetVaults()?.GetVaultByName(vaultName) ?? throw new Exception($"Unable to find vault by name '{vaultName}'"); ;
            return vault?.LogIn();
        }
    }
}
