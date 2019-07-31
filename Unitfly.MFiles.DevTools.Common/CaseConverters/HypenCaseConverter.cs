namespace Unitfly.MFiles.DevTools.Common.CaseConverters
{
    public class HypenCaseConverter : CaseConverter
    {
        public HypenCaseConverter(bool removeSpecialChars = true, bool removeWhitespace = true, bool removeAccents = true) : base(removeSpecialChars, removeWhitespace, removeAccents)
        {
        }

        protected override string Transform(string input)
        {
            return input?.ToLower().Replace("  ", " ").Replace(' ', '-');
        }
    }
}