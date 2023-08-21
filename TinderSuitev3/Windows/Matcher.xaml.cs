using System.Globalization;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Serilog;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
    public partial class Matcher
    {
        private CancellationTokenSource? _cancelTokenSource;
        private readonly BrushConverter _bc;
        public static int AmountLiked;

        public TinderRecommendedUser[]? MatchCards { get; set; }

        public bool Running { get; set; }

        public Matcher()
        {
            InitializeComponent();
            DataContext = this;
            Instances.Matcher = this;

            _bc = new BrushConverter();
        }

        /// <summary>
        /// Display the user that's currently being processed and also do the processing.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public async Task DisplayCard(TinderRecommendedUser card)
        {
            Log.Debug($"Card for {card.User.Name} has been loaded.");

            var like = true;
            var image = await ImageHelper.DownloadImage(card.User.Photos.First().Url, false);

            UserPhoto.Source = ImageHelper.BytesToBitmap(image);
            UserName.Text = card.User.Name + $" ({CalculateAge(card.User.BirthDate)})";

            // If an disliked zodiac sign is selected, skip the user.
            if (!ProcessZodiac(card))
                like = false;

            IntentCard.Text = card.User.RelationshipIntent?.BodyText;

            // If an unpreferred race is selected, skip the user.
            if (!ProcessRace(image))
                like = false;

            // Check if the user is real, if not; skip them.
            if (!await ProcessIfUserIsReal(card))
                like = false;

            // Process the user's yearly income and skip if required.
            if (!await ProcessIncome(card))
                like = false;

            LikedStatus.Text = like ? "Yes" : "No";
            LikedStatus.Foreground = like ? (Brush)_bc.ConvertFrom("#099132")! : (Brush)_bc.ConvertFrom("#ab0733")!;

            if (like)
            {
                await Tinder.Instances.First().LikeUser(card.User.Id);
                AmountLiked++;
                LikesThisSession.Text = AmountLiked.ToString();
            }
            else
            {
                await Tinder.Instances.First().PassUser(card.User.Id, card.User.SNumber);
            }

            await Task.Delay(new Random().Next(1000, 8000));
        }

        /// <summary>
        /// Display various account information on a loop.
        /// </summary>
        private async void UpdateAccountInfo()
        {
            while (true)
            {
                var account = Tinder.Instances.FirstOrDefault();

                if (account != null)
                {
                    var data = await Tinder.Instances.First().GetTeasers();
                    var profile = await Tinder.Instances.First().GetUserHiddenDetails();

                    LocationLon.Text = profile?.Data.User.Pos.Lon.ToString(CultureInfo.InvariantCulture);
                    LocationLat.Text = profile?.Data.User.Pos.Lat.ToString(CultureInfo.InvariantCulture);

                    LikesYou.Text = data.Data.Count.ToString();
                    await Task.Delay(TimeSpan.FromMinutes(2));
                }
                else
                {
                    await Task.Delay(TimeSpan.FromSeconds(3));
                }
            }
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

            NoCis.IsChecked = prefs.NoCis;
            NoTrans.IsChecked = prefs.NoTrans;
            NoKids.IsChecked = prefs.NoKids;
            NoPets.IsChecked = prefs.NoPets;
            NoPoly.IsChecked = prefs.NoPoly;
            NoSmokers.IsChecked = prefs.NoSmokers;

            MinimumIncome.Text = prefs.MinimumIncome.ToString();
            RequireMinIncome.IsChecked = prefs.EnableIncomeCheck;
            MinimumIncome.IsEnabled = prefs.EnableIncomeCheck;

            UpdateAccountInfo();
        }

        /// <summary>
        ///     Process the user's zodiac sign.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>True or false on if the user should not be liked.</returns>
        private bool ProcessZodiac(TinderRecommendedUser card)
        {
            ZodiacCard.Text = card.User.Descriptors?.FirstOrDefault(x => x.Name == "Zodiac")?.Selections.First().Name;

            if (!string.IsNullOrWhiteSpace(ZodiacCard.Text) && ZodiacList.SelectedItems.Contains(ZodiacCard.Text))
            {
                ZodiacCardBack.Background = (Brush)_bc.ConvertFrom("#370f0f")!;
                return false;
            }

            ZodiacCardBack.Background = (Brush)_bc.ConvertFrom("#222")!;
            return true;
        }

        /// <summary>
        ///     Process the user's ethnicity.
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <returns>True or false on if the user should not be liked.</returns>
        private bool ProcessRace(byte[] imageBytes)
        {
            RaceCard.Text = Engine.ProcessEthnicity(imageBytes);

            if (PreferredEthnicities.SelectedItems.Contains(RaceCard.Text))
            {
                RaceCardBack.Background = (Brush)_bc.ConvertFrom("#222")!;
                return true;
            }

            RaceCardBack.Background = (Brush)_bc.ConvertFrom("#370f0f")!;
            return false;
        }

        /// <summary>
        ///     Process whether or not the user is a bot.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>True or false on if the user should not be liked.</returns>
        private async Task<bool> ProcessIfUserIsReal(TinderRecommendedUser card)
        {
            RealPersonMeter.Value = Engine.ScoreUser(card.User);

            var settings = await Settings.GetSettings();

            if (RealPersonMeter.Value < settings?.WeightThreshold)
            {
                if (ReportBots.IsChecked!.Value)
                    await Tinder.Instances.First().ReportUser(card.User.Id);

                return false;
            }

            return true;
        }

        /// <summary>
        ///     Process the user's income (if provided)
        /// </summary>
        /// <param name="card"></param>
        /// <returns>True or false on if the user should not be liked.</returns>
        private async Task<bool> ProcessIncome(TinderRecommendedUser card)
        {
            var income = await Engine.GetIncome(card.User);
            IncomeCard.Text = income;

            var incomeNum = income?.Replace("$", null).Replace(",", null);

            if (decimal.TryParse(incomeNum, out _))
            {
                if (RequireMinIncome.IsChecked!.Value && Convert.ToDecimal(MinimumIncome.Text) > Convert.ToDecimal(incomeNum))
                {
                    IncomeCardBack.Background = (Brush)_bc.ConvertFrom("#370f0f")!;
                    return false;
                }
            }

            IncomeCardBack.Background = (Brush)_bc.ConvertFrom("#222")!;
            return true;
        }

        /// <summary>
        /// Load a list of "Match Cards" (eg: A list of users to swipe through).
        /// </summary>
        public async Task LoadMatchCards()
        {
            var res = await Tinder.Instances.First().GetMatchCards();
            MatchCards = res?.Data.Results?.ToArray();
            Log.Debug($"{MatchCards?.Length} match cards have been loaded.");
        }

        /// <summary>
        /// Calculate the user's age based on their birthday.
        /// </summary>
        /// <param name="birthDate">The user's birthday.</param>
        /// <returns>The user's age in years.</returns>
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

        /// <summary>
        /// The main "Start / Stop" functionality for the automation.
        /// </summary>
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
                    }

                    if (_cancelTokenSource!.IsCancellationRequested)
                        break;
                }
            }
            else
            {
                SystemSounds.Beep.Play();
                await _cancelTokenSource!.CancelAsync();
                Log.Information($"Match automation has been cancelled by the user.");
                StartAutomationButton.Content = "Start Automation";
                Running = false;
            }
        }

        /// <summary>
        /// Save the user's match preferences.
        /// </summary>
        private async void SavePreferences_OnClick(object sender, RoutedEventArgs e)
        {
            var prefs = new SavedMatchPreference()
            {
                Ethnicities = PreferredEthnicities.SelectedItems.Cast<string>().ToArray(),
                Intent = IntentList.SelectedItems.Cast<string>().ToArray(),
                ZodiacSigns = ZodiacList.SelectedItems.Cast<string>().ToArray(),
                Interests = IntentList.Items.Cast<string>().ToArray(),
                MinimumIncome = Convert.ToInt64(MinimumIncome.Text),
                EnableIncomeCheck = (bool)RequireMinIncome.IsChecked!,
                NoPets = NoPets.IsChecked!.Value,
                NoCis = NoCis.IsChecked!.Value,
                NoKids = NoKids.IsChecked!.Value,
                NoPoly = NoPoly.IsChecked!.Value,
                NoSmokers = NoSmokers.IsChecked!.Value,
                NoTrans = NoTrans.IsChecked!.Value
            };

            await Settings.UpdateMatchPreferences(prefs);
            new DarkMessageBox("Your match preferences have been saved!").ShowDialog();
        }

        /// <summary>
        /// Change if the minimum income input box is enabled.
        /// </summary>
        private void RequireMinIncome_OnClick(object sender, RoutedEventArgs e)
        {
            MinimumIncome!.IsEnabled = (bool)RequireMinIncome.IsChecked!;
        }

        private async void UpdateLocation_OnClick(object sender, RoutedEventArgs e)
        {
            if (!LocationHelper.IsValidLatitude(Convert.ToDouble(LocationLat.Text)))
            {
                new DarkMessageBox("Please enter a valid latitude.").ShowDialog();
                return;
            }

            if (!LocationHelper.IsValidLongitude(Convert.ToDouble(LocationLon.Text)))
            {
                new DarkMessageBox("Please enter a valid longitude.").ShowDialog();
                return;
            }


            await Tinder.Instances.First()
                .ChangeLocation(Convert.ToDecimal(LocationLat.Text), Convert.ToDecimal(LocationLon.Text));

            new DarkMessageBox("Your location has been updated!").ShowDialog();
        }

        /// <summary>
        /// Text box that only allows number inputs.
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void InvisibilityMode_OnClick(object sender, RoutedEventArgs e)
        {
            await Tinder.Instances.First().EnableInvisibilityMode(true);
            new DarkMessageBox(
                    "Invisibility mode has been enabled. You will not show up to other users unless you have liked them. To disable this, turn ON Discovery mode from your Tinder settings from the official app.")
                .ShowDialog();
        }
    }
}
