namespace Unitfly.MFiles.DevTools.Common.CaseConverters
{
    public class LowerCaseConverter : CaseConverter
    {
        public LowerCaseConverter(bool removeSpecialChars = false, bool removeWhitespace = false, bool removeAccents = true) : base(removeSpecialChars, removeWhitespace, removeAccents)
        {
        }

        protected override string Transform(string input)
        {
            return input?.ToLower();
        }
    }
}