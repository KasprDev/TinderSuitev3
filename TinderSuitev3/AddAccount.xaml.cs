using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using TinderSuitev3;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace DotNetServerManager
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
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

            await File.WriteAllTextAsync(System.IO.Path.Combine(Directories.AccountsDir, $"{XAuthTokenTxt.Text}.json"), JsonConvert.SerializeObject(u));

            Tinder.Instances.Add(t);

            Instances.MainWindow?.LoggedIn();

            this.Close();
        }
    }
}
