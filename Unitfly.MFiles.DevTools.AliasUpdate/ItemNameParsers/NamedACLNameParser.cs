using MFilesAPI;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public class NamedACLNameParser : ItemNameParser<NamedACLAdmin>
    {
        public NamedACLNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(NamedACLAdmin namedACL, IVault vault)
        {
            return Template?.Replace("{ObjectType}", NameConverter.ToString(namedACL.NamedACL.Name));
        }
    }
}
