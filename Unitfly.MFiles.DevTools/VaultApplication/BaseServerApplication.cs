﻿using MFilesAPI;
using System;

namespace Unitfly.MFiles.DevTools
{
    public abstract class BaseServerApplication
    {
        protected IVault Vault { get; set; }

        public BaseServerApplication() { }

        public BaseServerApplication(
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
        {
            Login(loginType, vaultName, username, password, domain, protocolSequence, networkAddress, endpoint, encryptedConnection, localComputerName);
        }

        public void Login(
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

            var serverApp = GetServerApp(username, password, domain, protocolSequence, networkAddress, endpoint, encryptedConnection, localComputerName, authType);

            var vault = serverApp.GetVaults()?.GetVaultByName(vaultName) ?? throw new Exception($"Unable to find vault by name '{vaultName}'"); ;
            Vault = vault?.LogIn();
        }

        protected virtual MFilesServerApplication GetServerApp(
            string username,
            string password,
            string domain,
            string protocolSequence,
            string networkAddress,
            string endpoint,
            bool encryptedConnection,
            string localComputerName,
            MFAuthType authType)
        {
            var serverApp = new MFilesServerApplication();
            serverApp.ConnectEx3(AuthType: authType,
                UserName: username,
                Password: password,
                Domain: domain,
                ProtocolSequence: protocolSequence,
                NetworkAddress: networkAddress,
                Endpoint: endpoint,
                EncryptedConnection: encryptedConnection,
                LocalComputerName: localComputerName);
            return serverApp;
        }
    }
}
