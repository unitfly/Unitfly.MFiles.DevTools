using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Common;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = InitAppSettings();
            var app = SetupApp(appSettings);

            try
            {
                app?.SetAliases(appSettings.AliasTemplates, appSettings.ItemNameTransform.CasingConverter, appSettings.AliasUpdateBehaviour);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error updating aliases.");
            }

            Log.Debug("Exiting application.");
            Log.CloseAndFlush();
        }

        private static AliasUpdater SetupApp(AppSettings appSettings)
        {
            var app = default(AliasUpdater);

            try
            {
                Enum.TryParse(appSettings.Vault.LoginType, out LoginType loginType);
                app = new AliasUpdater(loginType: loginType,
                    vaultName: appSettings.Vault.VaultName,
                    username: appSettings.Vault.Username,
                    password: appSettings.Vault.Password,
                    domain: appSettings.Vault.Domain,
                    protocolSequence: appSettings.Vault.ProtocolSequence,
                    networkAddress: appSettings.Vault.NetworkAddress,
                    endpoint: appSettings.Vault.Endpoint,
                    encryptedConnection: appSettings.Vault.EncryptedConnection,
                    localComputerName: appSettings.Vault.LocalComputerName);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error connecting to the vault {vault} as {loginType} user {user}.",
                    appSettings?.Vault?.VaultName, appSettings?.Vault?.LoginType,
                    string.IsNullOrWhiteSpace(appSettings?.Vault?.Domain)
                        ? appSettings?.Vault.Username
                        : $"{appSettings?.Vault?.Domain}\\{appSettings?.Vault?.Username}");
            }

            return app;
        }

        private static AppSettings InitAppSettings()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                .WriteTo.File(path: "./logs/log-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug, shared: true)
                .CreateLogger();

            Log.Debug("Starting application.");

            var configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                Build();

            var appSettings = new AppSettings();
            configuration.Bind(appSettings);
            Log.Debug("Read application settings.");

            return appSettings;
        }
    }
}
