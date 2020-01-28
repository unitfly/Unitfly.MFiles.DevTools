using MFilesAPI;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public class ClassNameParser : ItemNameParser<ObjectClassAdmin>
    {
        public ClassNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(ObjectClassAdmin @class, IVault vault)
        {
            var @type = vault.ObjectTypeOperations.GetObjectType(@class.ObjectType);
            return Template
               ?.Replace("{Class}", NameConverter.ToString(@class.Name))
               ?.Replace("{ObjectType}", NameConverter.ToString(@type.NameSingular));
        }
    }
}
