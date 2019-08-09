using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Configuration
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
        [JsonConverter(typeof(StringEnumConverter))]
        public CasingType Casing { get; set; }

        [JsonIgnore]
        public CaseConverter CasingConverter => Casing.GetCasingConverter(RemoveNonAlphaNumericChars, RemoveWhiteSpace, RemoveAccents);
    }
}
