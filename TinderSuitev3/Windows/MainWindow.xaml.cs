using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using DotNetServerManager;
using Newtonsoft.Json;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;
using TinderSuitev3.Windows;

namespace TinderSuitev3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // INotifyPropertyChanged was needed to make the dashboard update in real-time.
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _showDashboard = false;
        public bool ShowDashboard
        {
            get => _showDashboard;
            set
            {
                if (_showDashboard == value) return;
                _showDashboard = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Instances.MainWindow = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddAccount().Show();
        }

        private void AddAccount_OnClick(object sender, RoutedEventArgs e)
        {
            new AddAccount().ShowDialog();
        }

        private void ManageAccounts_OnClick(object sender, RoutedEventArgs e)
        {
            new ManageAccounts().ShowDialog();
        }

        public async void LoggedIn()
        {
            this.ShowDashboard = true;
            await Instances.Matcher!.LoadMatchCards();
            OnPropertyChanged("ShowDashboard");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(Directories.AccountsDir))
            {
                var files = Directory.GetFiles(Directories.AccountsDir);
                var acc = JsonConvert.DeserializeObject<SavedAccount>(await File.ReadAllTextAsync(files.First()));
                var t = new Tinder(acc.XAuthToken, null);

                if (await t.IsValidToken())
                {
                    Tinder.Instances.Add(t);
                    Instances.MainWindow?.LoggedIn();
                }
            }

            var settings = Path.Combine(Directories.BaseDir, "Settings.json");

            if (!File.Exists(settings))
            {

            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            new Messages().Show();
        }

        private void Settings_OnClick(object sender, RoutedEventArgs e)
        {
            new ProgramSettings().ShowDialog();
        }

        private async void HiddenDetails_OnClick(object sender, RoutedEventArgs e)
        {
            var data = await Tinder.Instances.First().GetUserHiddenDetails();
            new HiddenProfileDetails(data).Show();
        }

        private void EditProfile_OnClick(object sender, RoutedEventArgs e)
        {
            new EditProfile().Show();
        }
    }
}