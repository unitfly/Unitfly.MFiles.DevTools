using System;
using System.Data;

namespace Unitfly.MFiles.DevTools.ClassToSql
{
    public class Column
    {
        public string Name { get; }
        public SqlDbType Type { get; }
        public bool Nulllable { get; }

        public Column(string name, SqlDbType type, bool nulllable)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Nulllable = nulllable;
        }
    }
}
