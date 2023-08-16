using System.IO;
using Newtonsoft.Json;
using TinderSuitev3.Objects;

namespace TinderSuitev3.Helpers
{
    public static class Settings
    {
        private static ProgramSettingsDto? _settings { get; set; }
        public static async Task<ProgramSettingsDto?> GetSettings()
        {
            var settings = Path.Combine(Directories.BaseDir, "Settings.json");

            if (_settings == null && File.Exists(settings))
                _settings = JsonConvert.DeserializeObject<ProgramSettingsDto>(await File.ReadAllTextAsync(settings));

            return _settings;
        }

        /// <summary>
        /// Refresh the user's settings program-wide so the program doesn't have to be
        /// restarted for them to apply.
        /// </summary>
        /// <returns></returns>
        public static async Task Refresh()
        {
            _settings = null;
            await GetSettings();
        }

        /// <summary>
        /// Update the user's saved Match Preferences (Ethnicity, Income, etc.)
        /// </summary>
        /// <param name="prefs"></param>
        /// <returns></returns>
        public static async Task UpdateMatchPreferences(SavedMatchPreference prefs)
        {
            await File.WriteAllTextAsync(Path.Combine(Directories.BaseDir, "MatchPreferences.json"), JsonConvert.SerializeObject(prefs));
        }

        /// <summary>
        /// Get the user's saved Match Preferences (Ethnicity, Income, etc.)
        /// </summary>
        /// <returns></returns>
        public static async Task<SavedMatchPreference?> GetMatchPreferences()
        {
            return File.Exists(Path.Combine(Directories.BaseDir, "MatchPreferences.json")) ? JsonConvert.DeserializeObject<SavedMatchPreference>(await File.ReadAllTextAsync(Path.Combine(Directories.BaseDir, "MatchPreferences.json")))! : null;
        }
    }
}
