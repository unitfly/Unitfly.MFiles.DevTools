using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unitfly.MFiles.DevTools.GenerateSql
{
    public class Table
    {
        private string _createQuery;
        private string _updateQuery;
        private string _insertIntoQuery;
        private string _deleteQuery;

        public string Name { get; }
        public Column IdColumn { get; }
        public IEnumerable<Column> Columns { get; }

        public Table(string name, IEnumerable<Column> columns, Column idColumn = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Columns = columns ?? throw new ArgumentNullException(nameof(columns));
            IdColumn = idColumn;
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
                    _createQuery = sb.ToString().Trim();
                }
                return _createQuery;
            }
        }

        public string UpdateQuery
        {
            get
            {
                if (_updateQuery is null)
                {
                    var id = IdColumn?.Name ?? "[ID]";
                    var sb = new StringBuilder();
                    sb.AppendLine($"UPDATE {Name} SET");
                    sb.AppendLine(string.Join(",\r\n", Columns.Select(c => $"  {c?.Name} = ?")));
                    sb.AppendLine($"WHERE {id} = ?");
                    _updateQuery = sb.ToString().Trim();
                }
                return _updateQuery;
            }
        }

        public string InsertIntoQuery
        {
            get
            {
                if (_insertIntoQuery is null)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine($"INSERT INTO {Name} (");
                    sb.AppendLine(string.Join(",\r\n", Columns.Select(c => $"  {c?.Name}")));
                    sb.AppendLine($") VALUES (");
                    sb.AppendLine(string.Join(",\r\n", Columns.Select(c => "  ?")));
                    sb.AppendLine($")");
                    _insertIntoQuery = sb.ToString().Trim();
                }
                return _insertIntoQuery;
            }
        }

        public string DeleteQuery
        {
            get
            {
                if (_deleteQuery is null)
                {
                    var id = IdColumn?.Name ?? "[ID]";
                    _deleteQuery = $"DELETE FROM {Name} WHERE {id} = ?";
                }
                return _deleteQuery;
            }
        }

        private static string ColumnDefinition(Column c)
        {
            var @type = c.Type.ToString().ToLower();
            if (type.EndsWith("varchar"))
            {
                type += "(256)";
            }

            var isNullable = c.Nulllable ? "NULL" : "NOT NULL";

            return $"{c.Name} {@type} {isNullable}";
        }
    }
}
