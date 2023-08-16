using System.IO;
using System.Windows;
using Newtonsoft.Json;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using Path = System.IO.Path;

namespace TinderSuitev3.Windows
{
    public partial class ProgramSettings : Window
    {
        public static ProgramSettingsDto? Settings { get; set; }
        public ProgramSettings()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var settings = Path.Combine(Directories.BaseDir, "Settings.json");

            if (!File.Exists(settings)) return;

            Settings = JsonConvert.DeserializeObject<ProgramSettingsDto>(await File.ReadAllTextAsync(settings));
            OpenAiKey.Text = Settings?.OpenAiKey;
            WeightThreshold.Value = Convert.ToDouble(Settings?.WeightThreshold);
        }

        private async void SaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            var settings = Path.Combine(Directories.BaseDir, "Settings.json");

            var s = new ProgramSettingsDto()
            {
                OpenAiKey = OpenAiKey.Text,
                WeightThreshold = Convert.ToInt32(WeightThreshold.Value)
            };

            await File.WriteAllTextAsync(settings, JsonConvert.SerializeObject(s));

            await Helpers.Settings.Refresh();
            Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new DarkMessageBox("This will allow you to automatically skip or report fake profiles as you swipe. This is a scale from 0 to 100; the lower the number, the more likely the user is to be a fake profile.").ShowDialog();
        }
    }
}
