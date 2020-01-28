using MFilesAPI;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public abstract class ItemNameParser<T>
    {
        public string Template { get; }
        public CaseConverter NameConverter { get; }

        protected ItemNameParser(string template, CaseConverter nameConverter = null)
        {
            Template = template;
            NameConverter = nameConverter ?? new OriginalCaseConverter();
        }

        public abstract string Expand(T input, IVault vault);
    }
}
