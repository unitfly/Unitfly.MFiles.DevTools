using CsvHelper.Configuration.Attributes;
using Unitfly.MFiles.DevTools.Rename;

namespace Unitfly.MFiles.DevTools.Rename.App.Configuration
{
    public class CsvFile
    {
        [Optional]
        [Name("Alias")]
        public string Alias { get; set; }

        [Optional]
        [Name("ID")]
        public int? ID { get; set; }

        [Optional]
        [Name("OldName")]
        public string OldName { get; set; }

        [Name("NewName")]
        public string NewName { get; set; }

        public RenameRule ToRule()
        {
            return new RenameRule()
            {
                Alias = Alias,
                ID = ID,
                OldName = OldName,
                NewName = NewName
            };
        }
    }
}
