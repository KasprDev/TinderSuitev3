using System.IO;
using System.Windows;
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

            if (!Directory.Exists(Directories.BaseDir))
            {
                Directory.CreateDirectory(Directories.BaseDir);
                Directory.CreateDirectory(Directories.AccountsDir);
            }
        }
    }
}