using MFilesAPI;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public class ValueListNameParser : ItemNameParser<ObjTypeAdmin>
    {
        public ValueListNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(ObjTypeAdmin valueList, IVault vault)
        {
            return Template?.Replace("{ValueList}", NameConverter.ToString(valueList.ObjectType.NamePlural));
        }
    }
}
