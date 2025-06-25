using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayWidgetApp
{
    /// <summary>
    /// Class for all paths to files used in project
    /// </summary>
    public static class AppPaths
    {
        public static readonly string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LogBot");

        public static readonly string UsersPath = Path.Combine(FolderPath, "users.json");

        public static readonly string SettingsPath = Path.Combine(FolderPath, "settings.json");

        public static readonly string exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
    }
}
