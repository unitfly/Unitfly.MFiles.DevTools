using Newtonsoft.Json;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration
{
    public class NameTansform
    {
        [JsonProperty("RemoveWhiteSpace")]
        public bool RemoveWhiteSpace { get; set; }

        [JsonProperty("RemoveNonAlphaNumericChars")]
        public bool RemoveNonAlphaNumericChars { get; set; }

        [JsonProperty("RemoveAccents")]
        public bool RemoveAccents { get; set; }

        [JsonProperty("Casing")]
        public CasingType Casing { get; set; }

        [JsonIgnore]
        public CaseConverter CasingConverter => Casing.GetCasingConverter(RemoveNonAlphaNumericChars, RemoveWhiteSpace, RemoveAccents);
    }
}
