using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TinderSuitev3.Objects;

namespace TinderSuitev3.Helpers
{
    public static class Settings
    {
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
