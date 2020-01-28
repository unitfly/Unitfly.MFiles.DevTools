using System.Linq;
using Unidecode.NET;

namespace Unitfly.MFiles.DevTools.CaseConverters
{
    public abstract class CaseConverter : ICaseConverter
    {
        private bool _removeSpecialChars;
        private bool _removeWhitespaces;
        private bool _removeAccents;

        protected CaseConverter(bool removeSpecialChars = true, bool removeWhitespace = true, bool removeAccents = true)
        {
            _removeSpecialChars = removeSpecialChars;
            _removeWhitespaces = removeWhitespace;
            _removeAccents = removeAccents;
        }

        public virtual string ToString(string input)
        {
            if (input is null)
            {
                return null;
            }

            if (_removeSpecialChars)
            {
                input = RemoveSpecialChars(input);
            }

            input = Transform(input);

            if (_removeWhitespaces)
            {
                input = RemoveWhitespaces(input);
            }

            return input;
        }

        protected abstract string Transform(string input);

        protected static string RemoveSpecialChars(string input)
        {
            return input is null ? null : new string(input.Select(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) ? c : ' ').ToArray());
        }

        protected static string RemoveWhitespaces(string input)
        {
            return input is null ? null : new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }

        protected static string RemoveAccents(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return input.Unidecode();
        }
    }
}
