using System.IO;
using System.Windows;
using Newtonsoft.Json;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3
{
    public partial class AddAccount : Window
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = false;
            if (string.IsNullOrWhiteSpace(XAuthTokenTxt.Text))
            {
                new DarkMessageBox("Please enter the X-Auth-Token for your account.").ShowDialog();
                LoginButton.IsEnabled = true;
                return;
            }

            var t = new Tinder(XAuthTokenTxt.Text, null);

            if (!await t.IsValidToken())
            {
                new DarkMessageBox("Invalid X-Auth-Token. Please try again.").ShowDialog();
                LoginButton.IsEnabled = true;
                return;
            }

            var user = await t.GetUser();

            var u = new SavedAccount()
            {
                Name = user.Name,
                CreatedOn = DateTime.Now,
                LastUsed = DateTime.Now,
                ProfilePicture = user.Photos.FirstOrDefault()?.Url,
                XAuthToken = XAuthTokenTxt.Text
            };

            if (!Directory.Exists(Directories.AccountsDir))
                Directory.CreateDirectory(Directories.AccountsDir);

            await File.WriteAllTextAsync(Path.Combine(Directories.AccountsDir, $"{XAuthTokenTxt.Text}.json"), JsonConvert.SerializeObject(u));
            Tinder.Instances.Add(t);
            Instances.MainWindow?.LoggedIn();
            Close();
        }
    }
}
