using System.Diagnostics;
using System.IO;
using System.Windows;
using TinderSuitev3.Helpers;

namespace TinderSuitev3
{
    public partial class RegisterLicense : Window
    {
        public RegisterLicense()
        {
            InitializeComponent();
        }

        private async void Register_OnClick(object sender, RoutedEventArgs e)
        {
            Register.IsEnabled = false;

            var l = new Licensing.Licensing();

            var result = await l.RegisterLicense(LicenseKey.Text);

            if (result)
            {
                await File.WriteAllTextAsync(Path.Combine(Directories.BaseDir, "license.lic"), LicenseKey.Text);

                Process.Start(Process.GetCurrentProcess().MainModule!.FileName);
                Application.Current.Shutdown();
            }

            Register.IsEnabled = true;
        }
    }
}
