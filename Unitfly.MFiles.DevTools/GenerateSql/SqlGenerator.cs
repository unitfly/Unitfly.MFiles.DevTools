using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MFilesAPI;
using Serilog;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.GenerateSql
{
    public class SqlGenerator : ServerApplication
    {
        public SqlGenerator(ILogger logger, LoginType loginType, string vaultName, string username, string password, string domain = null,
            string protocolSequence = "ncacn_ip_tcp", string networkAddress = "localhost", string endpoint = "2266",
            bool encryptedConnection = false, string localComputerName = "") :
            base(loginType, vaultName, username, password, domain, protocolSequence,
                networkAddress, endpoint, encryptedConnection, localComputerName)
        {
            Log.Logger = logger;
            Log.Information("Logged in to vault {vault} as {loginType} user {user}.",
                vaultName, loginType, string.IsNullOrWhiteSpace(domain) ? username : $"{domain}\\{username}");
        }

        public Table ConvertClassToTable(string @class, CaseConverter converter, bool ignoreBuiltinProperties)
        {
            var classObj = Vault.ClassOperations.GetAllObjectClasses()?
                .Cast<ObjectClass>()?
                .FirstOrDefault(c => c?.Name?.ToLower() == @class?.ToLower());

            if (classObj is null)
            {
                throw new Exception($"Unable to fetch class {@class} from vault.");
            }

            return ConvertClassToTable(classObj, converter, ignoreBuiltinProperties);
        }

        public Table ConvertClassToTable(ObjectClass @class, CaseConverter converter, bool ignoreBuiltinProperties)
        {
            var propertyDefs = Vault.PropertyDefOperations.GetPropertyDefs().Cast<PropertyDef>();
            var table = new Table(
                GetTableName(converter, @class),
                GetTableColumns(converter, @class, propertyDefs, ignoreBuiltinProperties)
            );
            Log.Debug("Converted  M-Files class {class} to an sql table.", @class?.Name);
            return table;
        }

        public IEnumerable<Table> ConvertAllClassesToTables(CaseConverter converter, bool ignoreBuiltinProperties)
        {
            var result = new List<Table>();
            var propertyDefs = Vault.PropertyDefOperations.GetPropertyDefs().Cast<PropertyDef>();
            var objClassses = Vault.ClassOperations.GetAllObjectClasses().Cast<ObjectClass>();
            foreach (var objClass in objClassses)
            {
                try
                {
                    result.Add(ConvertClassToTable(objClass, converter, ignoreBuiltinProperties));
                }
                catch (Exception e)
                {
                    Log.Warning(e, "Error converting M-Files class {class} to an sql table.", objClass?.Name);
                    continue;
                }
            }
            return result;
        }

        private static string GetTableName(CaseConverter converter, ObjectClass objClass)
        {
            return converter.ToString(objClass.Name);
        }

        private static IEnumerable<Column> GetTableColumns(CaseConverter converter,
            ObjectClass objClass, IEnumerable<PropertyDef> propertyDefs, bool ignoreBuiltinProperties)
        {
            var result = new List<Column>();
            var asspciatedPropDefs = objClass.AssociatedPropertyDefs.Cast<AssociatedPropertyDef>();
            foreach (var apd in asspciatedPropDefs)
            {
                var pd = propertyDefs.FirstOrDefault(p => p.ID == apd.PropertyDef);
                if (pd is null || (ignoreBuiltinProperties && pd.Predefined))
                {
                    continue;
                }

                var nullable = apd.Required ? "NOT NULL" : "NULL";
                result.Add(new Column(converter.ToString(pd.Name), MapType(pd.DataType), !apd.Required));
            }
            return result;
        }

        private static SqlDbType MapType(MFDataType mfDataType)
        {
            switch (mfDataType)
            {
                case MFDataType.MFDatatypeMultiLineText:
                case MFDataType.MFDatatypeText:
                    return SqlDbType.NVarChar;
                case MFDataType.MFDatatypeInteger:
                    return SqlDbType.Int;
                case MFDataType.MFDatatypeInteger64:
                    return SqlDbType.BigInt;
                case MFDataType.MFDatatypeFloating:
                    return SqlDbType.Float;
                case MFDataType.MFDatatypeDate:
                case MFDataType.MFDatatypeTime:
                case MFDataType.MFDatatypeTimestamp:
                case MFDataType.MFDatatypeFILETIME:
                    return SqlDbType.DateTime;
                case MFDataType.MFDatatypeBoolean:
                    return SqlDbType.Bit;
                case MFDataType.MFDatatypeLookup:
                    return SqlDbType.Int;
                case MFDataType.MFDatatypeMultiSelectLookup:
                case MFDataType.MFDatatypeUninitialized:
                case MFDataType.MFDatatypeACL:
                default:
                    return SqlDbType.NVarChar;
            }
        }
    }
}
