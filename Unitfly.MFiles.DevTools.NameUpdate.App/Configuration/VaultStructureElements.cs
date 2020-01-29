using Newtonsoft.Json;
using System.Collections.Generic;

namespace Unitfly.MFiles.DevTools.NameUpdate.App.Configuration
{
    public class VaultStructureElements
    {
        public Dictionary<string,string> Classes { get; set; }

        public Dictionary<string,string> UserGroups { get; set; }

        public Dictionary<string,string> ObjectTypes { get; set; }

        public Dictionary<string,string> ValueLists { get; set; }

        public Dictionary<string,string> PropertyDefs { get; set; }

        public Dictionary<string,string> Workflows { get; set; }

        public Dictionary<string,string> States { get; set; }

        public Dictionary<string,string> StateTransitions { get; set; }

        public Dictionary<string,string> NamedACLs { get; set; }
    }
}
