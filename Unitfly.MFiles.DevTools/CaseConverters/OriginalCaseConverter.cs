namespace Unitfly.MFiles.DevTools.CaseConverters
{
    public class OriginalCaseConverter : CaseConverter
    {
        public OriginalCaseConverter(bool removeSpecialChars = false, bool removeWhitespace = false, bool removeAccents = true) : base(removeSpecialChars, removeWhitespace, removeAccents)
        {
        }

        protected override string Transform(string input)
        {
            return input;
        }
    }
}