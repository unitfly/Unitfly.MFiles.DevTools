namespace Unitfly.MFiles.DevTools.Common.CaseConverters
{
    public class SnakeCaseConverter : CaseConverter
    {
        public SnakeCaseConverter(bool removeSpecialChars = true, bool removeWhitespace = true, bool removeAccents = true) : base(removeSpecialChars, removeWhitespace, removeAccents)
        {
        }

        protected override string Transform(string input)
        {
            return input?.ToLower().Replace(' ', '_');
        }
    }
}