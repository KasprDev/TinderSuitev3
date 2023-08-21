using System.IO;
using System.Windows;
using Serilog;
using TinderSuitev3.Helpers;

namespace TinderSuitev3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (Directory.Exists(Directories.LogDir))
                Directory.CreateDirectory(Directories.LogDir);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine(Directories.LogDir, "logs.txt"), retainedFileCountLimit: 20, retainedFileTimeLimit: TimeSpan.FromDays(7))
                .CreateLogger();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            if (!Directory.Exists(Directories.BaseDir))
            {
                Directory.CreateDirectory(Directories.BaseDir);
                Directory.CreateDirectory(Directories.AccountsDir);
            }

            if (File.Exists(Path.Combine(Directories.BaseDir, "license.lic")))
            {
                var l = new Licensing.Licensing();
                l.ValidateLicense(File.ReadAllText(Path.Combine(Directories.BaseDir, "license.lic")));

                new MainWindow().Show();
                return;
            }

            new RegisterLicense().Show();
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Fatal(e.ExceptionObject as Exception, "Unhandled Exception");
        }
    }
}