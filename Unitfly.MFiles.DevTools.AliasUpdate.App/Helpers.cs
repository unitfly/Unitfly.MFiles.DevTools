using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Unitfly.MFiles.DevTools.Common.UpdateBehaviours;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    public static class Helpers
    {
        public static IUpdateBehaviour GetUpdateBehaviour(this UpdateBehaviour behaviour)
        {
            switch (behaviour)
            {
                case UpdateBehaviour.Append:
                    return new AppendBehaviour();
                case UpdateBehaviour.Overwrite:
                    return new OverwriteBehaviour();
                case UpdateBehaviour.SetIfEmpty:
                default:
                    return new SetEmptyBehaviour();
            }
        }

        public static CaseConverter GetCasingConverter(this CasingType casingType, bool removeNonAlphaNumericChars, bool removeWhiteSpace, bool removeAccents)
        {
            switch (casingType)
            {
                case CasingType.UpperCase:
                    return new UpperCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
                case CasingType.LowerCase:
                    return new LowerCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
                case CasingType.PascalCase:
                    return new PascalCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
                case CasingType.CamelCase:
                    return new CamelCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
                case CasingType.HypenCase:
                    return new HypenCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
                case CasingType.SnakeCase:
                    return new SnakeCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
                case CasingType.Original:
                default:
                    return new OriginalCaseConverter(removeNonAlphaNumericChars, removeWhiteSpace, removeAccents);
            }
        }
    }
}
