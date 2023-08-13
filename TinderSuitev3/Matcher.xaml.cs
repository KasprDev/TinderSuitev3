using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;

namespace TinderSuitev3
{
    /// <summary>
    /// Interaction logic for Matcher.xaml
    /// </summary>
    public partial class Matcher : Page
    {
        public static string[] Races => Lists.Races;
        public static string[] ZodiacSigns => Lists.StarSigns;
        public static string[] Hobbies => Lists.Hobbies;
        public bool Running { get; set; }

        private CancellationTokenSource? _cancelTokenSource;

        public TinderRecommendedUser[]? MatchCards { get; set; }

        private static BrushConverter _bc;

        public Matcher()
        {
            InitializeComponent();
            DataContext = this;
            Instances.Matcher = this;
            
            _bc = new BrushConverter();
            
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var prefs = await Settings.GetMatchPreferences();

            if (prefs == null) return;

            foreach (var item in PreferredEthnicities.Items)
            {
                if (prefs.Ethnicities.Contains(item))
                    PreferredEthnicities.SelectedItems.Add(item);
            }
        }

        public async Task DisplayCard(TinderRecommendedUser card)
        {
            using var http = new HttpClient();
            var imageBytes = await http.GetByteArrayAsync(card.User.Photos.First().Url);

            var bitmap = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(imageBytes);
            bitmap.EndInit();

            UserPhoto.Source = bitmap;
            UserName.Text = card.User.Name + $" ({CalculateAge(card.User.BirthDate)})";

            if (_cancelTokenSource!.IsCancellationRequested)
                return;

            var ethnicity = Engine.ProcessEthnicity(imageBytes);
            RaceCard.Text = ethnicity;

            if (PreferredEthnicities.SelectedItems.Contains(ethnicity))
            {
                RaceCardBack.Background = (Brush)_bc.ConvertFrom("#222")!;
            }
            else
            {
                RaceCardBack.Background = (Brush)_bc.ConvertFrom("#7F1010")!;
                return;
            }
        }

        public async Task LoadMatchCards()
        {
            var res = await Tinder.Instances.First().GetMatchCards();
            MatchCards = res?.Data.Results?.ToArray();
        }

        public static int CalculateAge(DateTime birthDate)
        {
            var currentDate = DateTime.Today;
            var age = currentDate.Year - birthDate.Year;

            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            return age; 
        }

        private async void StartAutomationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!Running)
            {
                Running = true;
                StartAutomationButton.Content = "Stop Automation";
                _cancelTokenSource = new CancellationTokenSource();

                while (true)
                {
                    await LoadMatchCards();
                    if (MatchCards == null) break;

                    foreach (var user in MatchCards)
                    {
                        if (_cancelTokenSource!.IsCancellationRequested)
                            break;

                        await DisplayCard(user);
                        await Task.Delay(5000);
                    }

                    if (_cancelTokenSource!.IsCancellationRequested)
                        break;
                }
            }
            else
            {
                SystemSounds.Beep.Play();
                await _cancelTokenSource!.CancelAsync();
                StartAutomationButton.Content = "Start Automation";
                Running = false;
            }
        }

        private async void SavePreferences_OnClick(object sender, RoutedEventArgs e)
        {
            var prefs = new SavedMatchPreference()
            {
                Ethnicities = PreferredEthnicities.SelectedItems.Cast<string>().ToArray(),
                Intent = IntentList.SelectedItems.Cast<string>().ToArray(),
                ZodiacSigns = ZodiacList.SelectedItems.Cast<string>().ToArray(),
                Interests = IntentList.Items.Cast<string>().ToArray()
            };

            await Settings.UpdateMatchPreferences(prefs);
        }
    }
}
