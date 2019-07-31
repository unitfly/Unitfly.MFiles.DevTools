using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                Build();

            var appSettings = new AppSettings();
            configuration.Bind(appSettings);

            var app = default(AliasesOperationsApp);
            try
            {
                app = new AliasesOperationsApp(appSettings.Vault.VaultName, appSettings.Vault.LoginType, appSettings.Vault.Username, appSettings.Vault.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to the vault. {e.Message}\r\n{e.StackTrace}");
                return;
            }

            try
            {
                app.SetAliases(appSettings.AliasTemplates, appSettings.ItemNameTransform.CasingConverter, appSettings.AliasUpdateBehaviour);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error setting aliases. {e.Message}\r\n{e.StackTrace}");
            }
        }
    }
}
