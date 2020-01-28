namespace Unitfly.MFiles.DevTools.NameUpdate.App
{
    public class App : NameUpdater
    {
        public App()
        {
        }

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
            : base(loginType,
                  vaultName,
                  username,
                  password,
                  domain,
                  protocolSequence,
                  networkAddress,
                  endpoint,
                  encryptedConnection,
                  localComputerName)
        {
        }
    }
}
