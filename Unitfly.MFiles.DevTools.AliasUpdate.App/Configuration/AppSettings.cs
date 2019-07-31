namespace Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration
{
    public class AppSettings
    {
        public Vault Vault { get; set; }

        public UpdateBehaviour AliasUpdateBehaviour { get; set; }

        public NameTansform ItemNameTransform { get; set; }

        public AliasTemplates AliasTemplates { get; set; }
    }
}
