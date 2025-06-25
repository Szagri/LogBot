using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OverlayWidgetApp.Services
{
    public class UserDataService
    {
        public string Login { get; private set; } = "";
        public string Password { get; private set; } = "";
        public DateTime Date { get; private set; } = DateTime.MinValue;

        [JsonIgnore]
        public string PasswordD 
        {
            get
            {
                byte[] passwordEncrypted = Convert.FromBase64String(Password);
                byte[] passwordDecrypted = ProtectedData.Unprotect(passwordEncrypted, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(passwordDecrypted);
            }
        }

        public  UserDataService(string login, string password, DateTime date)
        {
            Login = login;
            Password = password;
            Date = date;
        }

        private void SetupUserDataFile()
        {
            if(!Directory.Exists(AppPaths.FolderPath))
            {
                Directory.CreateDirectory(AppPaths.FolderPath);
            }

            if (!File.Exists(AppPaths.UsersPath))
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(AppPaths.UsersPath, json);
            }
        }

        public static UserDataService Load()
        {
            if (File.Exists(AppPaths.UsersPath))
            {
                string json = File.ReadAllText(AppPaths.UsersPath);
                return JsonSerializer.Deserialize<UserDataService>(json) ?? new UserDataService("", "", DateTime.MinValue);
            }

            return new UserDataService("", "", DateTime.MinValue);
        }

        public void Save()
        {
            SetupUserDataFile();
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(AppPaths.UsersPath, json);
        }

        public void Update(string login, string password, DateTime date)
        {
            Login = login;
            Date = date;

            byte[] passwordEncrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(password), null, DataProtectionScope.CurrentUser);
            Password = Convert.ToBase64String(passwordEncrypted);
        }

        private DateTime RefreshDataFromDisk()
        {
            var json = File.ReadAllText(AppPaths.UsersPath);
            var data = JsonSerializer.Deserialize<UserDataService>(json);
            return data.Date;
        }

        public void RefreshDate()
        {
            Date = RefreshDataFromDisk();
        }
    }
}

