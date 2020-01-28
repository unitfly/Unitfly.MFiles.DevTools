using MFilesAPI;

namespace Unitfly.MFiles.DevTools
{
    public class ServerAdminApplication : BaseServerApplication
    {
        public ServerAdminApplication(LoginType loginType, string vaultName, string username, string password, string domain = null,
            string protocolSequence = "ncacn_ip_tcp", string networkAddress = "localhost", string endpoint = "2266",
            bool encryptedConnection = false, string localComputerName = "") : base(loginType, vaultName, username, password, domain, protocolSequence, networkAddress, endpoint, encryptedConnection, localComputerName)
        {
        }

        protected override MFilesServerApplication GetServerApp(string username, string password, string domain, string protocolSequence,
            string networkAddress, string endpoint, bool encryptedConnection, string localComputerName, MFAuthType authType)
        {
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
            return serverApp;
        }
    }
}
