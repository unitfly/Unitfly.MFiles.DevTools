using System.Globalization;

namespace Unitfly.MFiles.DevTools.CaseConverters
{
    public class CamelCaseConverter : CaseConverter
    {
        public CamelCaseConverter(bool removeSpecialChars = true, bool removeWhitespace = true, bool removeAccents = true) : base(removeSpecialChars, removeWhitespace, removeAccents)
        {
        }

        protected override string Transform(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return char.ToLowerInvariant(input[0]) + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower()).Substring(1);
        }
    }
}