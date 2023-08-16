using System.IO;

namespace TinderSuitev3.Helpers
{
    /// <summary>
    /// A predefined list of directories the program references from.
    /// </summary>
    public class Directories
    {
        public static string BaseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TinderSuite");
        public static string AccountsDir = Path.Combine(BaseDir, "Accounts");
        public static string LogDir = Path.Combine(BaseDir, "Logs");
    }
}
