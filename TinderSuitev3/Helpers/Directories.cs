using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderSuitev3.Helpers
{
    public class Directories
    {
        public static string BaseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TinderSuite");
        public static string AccountsDir = Path.Combine(BaseDir, "Accounts");
        public static string LogDir = Path.Combine(BaseDir, "Logs");
    }
}
