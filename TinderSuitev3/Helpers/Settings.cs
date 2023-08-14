using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        public static async Task Refresh()
        {
            _settings = null;
            await GetSettings();
        }

        public static async Task UpdateMatchPreferences(SavedMatchPreference prefs)
        {
            await File.WriteAllTextAsync(Path.Combine(Directories.BaseDir, "MatchPreferences.json"), JsonConvert.SerializeObject(prefs));
        }

        public static async Task<SavedMatchPreference?> GetMatchPreferences()
        {
            return File.Exists(Path.Combine(Directories.BaseDir, "MatchPreferences.json")) ? JsonConvert.DeserializeObject<SavedMatchPreference>(await File.ReadAllTextAsync(Path.Combine(Directories.BaseDir, "MatchPreferences.json")))! : null;
        }
    }
}
