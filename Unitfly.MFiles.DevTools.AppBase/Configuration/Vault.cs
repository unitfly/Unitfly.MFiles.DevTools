using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Unitfly.MFiles.DevTools.AppBase.Configuration
{
    public class Vault
    {
        [JsonProperty("VaultName", Required = Required.Always)]
        public string VaultName { get; set; }

        [JsonProperty("LoginType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LoginType LoginType { get; set; } = LoginType.MFiles;

        [JsonProperty("Domain")]
        public string Domain { get; set; } = null;

        [JsonProperty("Username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("Password", Required = Required.Always)]
        public string Password { get; set; }

        [JsonProperty("Protocol")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProtocolSequence Protocol { get; set; } = ProtocolSequence.TcpIp;

        [JsonProperty("NetworkAddress")]
        public string NetworkAddress { get; set; } = "localhost";

        [JsonProperty("Port")]
        public int Port { get; set; } = 2266;

        [JsonProperty("EncryptedConnection")]
        public bool EncryptedConnection { get; set; }

        [JsonProperty("LocalComputerName")]
        public string LocalComputerName { get; set; } = "";
    }
}
