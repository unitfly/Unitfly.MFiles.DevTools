using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unitfly.MFiles.DevTools.ClassToSql
{
    public class Table
    {
        private string _createQuery;

        public string Name { get; }
        public IEnumerable<Column> Columns { get; }

        public Table(string name, IEnumerable<Column> columns)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Columns = columns ?? throw new ArgumentNullException(nameof(columns));
        }

        public string CreateQuery
        {
            get
            {
                if (_createQuery is null)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine($"CREATE TABLE {Name} (");
                    sb.AppendLine(string.Join(",\r\n", Columns.Select(c => $"  {ColumnDefinition(c)}")));
                    sb.AppendLine(")");
                    _createQuery = sb.ToString();
                }
                return _createQuery;
            }
        }

        private static string ColumnDefinition(Column c)
        {
            var @type = c.Type.ToString().ToLower();
            if (type.EndsWith("varchar"))
            {
                type += "(256)";
            }

            var isNullable = c.Nulllable ? "NULL" : "IS NOT NULL";

            return $"{c.Name} {@type} {isNullable}";
        }
    }
}
