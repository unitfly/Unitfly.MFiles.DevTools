﻿using CommandLine;
using Serilog;
using System;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Common;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Commands
{
    [Verb("login", HelpText = "Login to an M-Files vault.")]
    public class Login
    {
        public static int Execute(ref AppSettings appSettings, ref AliasUpdater Updater, Login opts = null)
        {
            try
            {
                Enum.TryParse(appSettings.Vault.LoginType, out LoginType loginType);
                Updater = new AliasUpdater(loginType: loginType,
                    vaultName: appSettings.Vault.VaultName,
                    username: appSettings.Vault.Username,
                    password: appSettings.Vault.Password,
                    domain: appSettings.Vault.Domain,
                    protocolSequence: appSettings.Vault.ProtocolSequence,
                    networkAddress: appSettings.Vault.NetworkAddress,
                    endpoint: appSettings.Vault.Endpoint,
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