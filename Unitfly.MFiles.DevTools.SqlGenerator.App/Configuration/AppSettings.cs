namespace Unitfly.MFiles.DevTools.GenerateSql.App.Configuration
{
    public class AppSettings
    {
        public Vault Vault { get; set; }
        
        public NameTansform ItemNameTransform { get; set; }

        public bool IgnoreBuiltinProperties { get; set; }
    }
}
