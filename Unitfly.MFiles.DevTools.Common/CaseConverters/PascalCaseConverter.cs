using System.Globalization;

namespace Unitfly.MFiles.DevTools.Common.CaseConverters
{
    public class PascalCaseConverter : CaseConverter
    {
        public PascalCaseConverter(bool removeSpecialChars = true, bool removeWhitespace = true, bool removeAccents = true) : base(removeSpecialChars, removeWhitespace, removeAccents)
        {
        }

        protected override string Transform(string input)
        {
            if (input is null)
            {
                return null;
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input?.ToLower());
        }
    }
}