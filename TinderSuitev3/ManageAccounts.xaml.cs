using System.IO;
using System.Windows;
using Newtonsoft.Json;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using Directory = System.IO.Directory;
using Path = System.IO.Path;

namespace TinderSuitev3
{
    /// <summary>
    /// Interaction logic for ManageAccounts.xaml
    /// </summary>
    public partial class ManageAccounts : Window
    {
        public ManageAccounts()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            var accounts = new List<SavedAccount>() { };
            foreach (var account in Directory.GetFiles(Directories.AccountsDir))
            {
                accounts.Add(JsonConvert.DeserializeObject<SavedAccount>(File.ReadAllText(account))!);
            }

            AccountsGrid.ItemsSource = accounts;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = (SavedAccount)AccountsGrid.SelectedItem;

            if (selected != null)
            {
                File.Delete(Path.Combine(Directories.AccountsDir, $"{selected.XAuthToken}.json"));
                LoadList();
            }
        }
    }
}
