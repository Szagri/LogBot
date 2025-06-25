using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OverlayWidgetApp.Services
{
    public class SettingsService
    {
        public bool ShowMessageOnLogin { get; set; } = false;
        public bool ShowMessageOnLogout { get; set; } = false;
        public bool ShowMessageOnEndWork { get; set; } = false;
        public bool ShowInformationPanel { get; set; } = false;
        public bool CloseSystemOnLogout { get; set; } = false;
        public int WaitTimeLogin { get; set; } = 30;
        public int WaitTimeLogout { get; set; } = 30;

        public SettingsService()
        {
 
        }

        private static void SetupSettingDataFile()
        {
            if (!Directory.Exists(AppPaths.FolderPath))
            {
                Directory.CreateDirectory(AppPaths.FolderPath);
            }

            if (!File.Exists(AppPaths.SettingsPath))
            {
                var defaultSettings = new SettingsService();
                string json = JsonSerializer.Serialize(defaultSettings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(AppPaths.SettingsPath, json);
            }
        }

        public static SettingsService Load()
        {
            SetupSettingDataFile();

            if (File.Exists(AppPaths.SettingsPath))
            {
                string json = File.ReadAllText(AppPaths.SettingsPath);
                return JsonSerializer.Deserialize<SettingsService>(json) ?? new SettingsService();
            }
            return new SettingsService();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(AppPaths.SettingsPath, json);
        }
    }
}
