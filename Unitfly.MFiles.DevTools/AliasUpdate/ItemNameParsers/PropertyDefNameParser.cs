using MFilesAPI;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public class PropertyDefNameParser : ItemNameParser<PropertyDefAdmin>
    {
        public PropertyDefNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(PropertyDefAdmin propertyDef, IVault vault)
        {
            return Template?.Replace("{PropertyDef}", NameConverter.ToString(propertyDef.PropertyDef.Name));
        }
    }
}
