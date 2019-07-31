using MFilesAPI;
using System;

namespace Unitfly.MFiles.DevTools.Common
{
    public class VaultAdmin
    {
        protected IVault Vault;

        public VaultAdmin(string vaultName, string loginType, string username, string password, string domain = null)
        {
            Vault = GetVaultAdmin(vaultName, loginType, username, password, domain);
        }

        private static IVault GetVaultAdmin(string vaultName, string loginType, string username, string password, string domain = null)
        {
            var serverApp = new MFilesServerApplication();
            if (loginType?.ToLower()?.Trim() == "windows")
            {
                serverApp.ConnectAdministrativeEx(AuthType: MFAuthType.MFAuthTypeSpecificWindowsUser,
                    UserName: username,
                    Password: password,
                    Domain: domain);
            }
            else
            {
                serverApp.ConnectAdministrativeEx(AuthType: MFAuthType.MFAuthTypeSpecificMFilesUser,
                    UserName: username,
                    Password: password);
            }

            var vault = serverApp.GetVaults()?.GetVaultByName(vaultName) ?? throw new Exception($"Unable to find vault by name '{vaultName}'"); ;
            return vault?.LogIn();
        }
    }
}
