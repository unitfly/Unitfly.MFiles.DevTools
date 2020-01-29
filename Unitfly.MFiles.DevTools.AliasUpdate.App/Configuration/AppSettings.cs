namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration
{
    public class AppSettings : AppBase.Configuration.AppSettings
    {
        public UpdateBehaviour AliasUpdateBehaviour { get; set; }

        public NameTansform ItemNameTransform { get; set; }

        public VaultStructureElements AliasTemplates { get; set; }
    }
}
