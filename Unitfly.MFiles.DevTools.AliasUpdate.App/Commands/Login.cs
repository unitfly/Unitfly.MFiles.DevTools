using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Commands
{
    [Verb("login", HelpText = "Login to an M-Files vault.")]
    public class Login
    {
        public static int Execute(ref AppSettings appSettings, ref AliasUpdaterApp Updater, Login opts = null)
        {
            try
            {
                Updater = new AliasUpdaterApp(loginType: appSettings.Vault.LoginType,
                    vaultName: appSettings.Vault.VaultName,
                    username: appSettings.Vault.Username,
                    password: appSettings.Vault.Password,
                    domain: appSettings.Vault.Domain,
                    protocolSequence: appSettings.Vault.Protocol.ProtocolSequenceToString(),
                    networkAddress: appSettings.Vault.NetworkAddress,
                    endpoint: appSettings.Vault.Port.ToString(),
                    encryptedConnection: appSettings.Vault.EncryptedConnection,
                    localComputerName: appSettings.Vault.LocalComputerName);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error connecting to the vault {vault} as {loginType} user {user}.",
                    appSettings?.Vault?.VaultName, appSettings?.Vault?.LoginType,
                    string.IsNullOrWhiteSpace(appSettings?.Vault?.Domain)
                        ? appSettings?.Vault.Username
                        : $"{appSettings?.Vault?.Domain}\\{appSettings?.Vault?.Username}");
                return 1;
            }

            return 0;
        }
    }
}
