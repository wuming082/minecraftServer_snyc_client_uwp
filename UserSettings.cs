using System;
using System.IO;
using System.Text.Json;

namespace minecraftServer_snyc_client_UWP_
{
    public class UserSettings
    {
        public string server_destnation { get; set; } = string.Empty;
        public string port { get; set; } = string.Empty;

        public string path_mod { get; set; } = string.Empty;

        public string path_server_modID { get; set; } = string.Empty;


        private static readonly string SettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user_settings.json");

        public static UserSettings Load()
        {
            if (File.Exists(SettingsFile))
            {
                try
                {
                    string json = File.ReadAllText(SettingsFile);
                    return JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
                }
                catch
                {
                    return new UserSettings();
                }
            }
            return new UserSettings();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFile, json);
        }
    }
}
