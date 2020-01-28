using MFilesAPI;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.Update.ItemNameParsers
{
    public class NamedACLNameParser : ItemNameParser<NamedACLAdmin>
    {
        public NamedACLNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(NamedACLAdmin namedACL, IVault vault)
        {
            return Template?.Replace("{NamedACL}", NameConverter.ToString(namedACL.NamedACL.Name));
        }
    }
}
