namespace Unitfly.MFiles.DevTools.SqlGenerator.App.Configuration
{
    public class AppSettings
    {
        public Vault Vault { get; set; }
        
        public NameTansform ItemNameTransform { get; set; }

        public bool IgnoreBuiltinProperties { get; set; }
    }
}
