using Newtonsoft.Json;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration
{
    public class Vault
    {
        [JsonProperty("VaultName", Required = Required.Always)]
        public string VaultName { get; set; }

        [JsonProperty("LoginType", Required = Required.Always)]
        public string LoginType { get; set; }

        [JsonProperty("Domain")]
        public string Domain { get; set; }

        [JsonProperty("Username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("Password", Required = Required.Always)]
        public string Password { get; set; }
    }
}
