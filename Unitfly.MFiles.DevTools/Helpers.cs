﻿using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools
{
    public static class Helpers
    {
        public static string ProtocolSequenceToString(this ProtocolSequence sequence)
        {
            switch (sequence)
            {
                case ProtocolSequence.LocalProcedureCall:
                    return "ncalrpc";
                case ProtocolSequence.Spx:
                    return "ncacn_spx";
                case ProtocolSequence.Https:
                    return "ncacn_http";
                case ProtocolSequence.TcpIp:
                default:
                    return "ncacn_ip_tcp";
            }
        }
        public static ProtocolSequence ProtocolSequenceFromString(this string sequence)
        {
            switch (sequence)
            {
                case "ncalrpc":
                    return ProtocolSequence.LocalProcedureCall;
                case "ncacn_spx":
                    return ProtocolSequence.Spx;
                case "ncacn_http":
                    return ProtocolSequence.Https;
                case "ncacn_ip_tcp":
                default:
                    return ProtocolSequence.TcpIp;
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
