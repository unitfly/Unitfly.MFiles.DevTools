namespace Unitfly.MFiles.DevTools.GenerateSql.App.Configuration
{
    public class AppSettings : AppBase.Configuration.AppSettings
    {        
        public NameTansform ItemNameTransform { get; set; }

        public bool IgnoreBuiltinProperties { get; set; }
    }
}
