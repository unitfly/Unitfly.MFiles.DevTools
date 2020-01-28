namespace Unitfly.MFiles.DevTools.SqlGenerator.App
{
    public class App : GenerateSql.SqlGenerator
    {
        public App() { }

        public App(
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
            : base(loginType: loginType,
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
    }
}
