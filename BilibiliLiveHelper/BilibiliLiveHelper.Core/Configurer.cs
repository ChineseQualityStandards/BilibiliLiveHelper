using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core
{
    public static class Configurer
    {
        public static string EncryptedString { get; } = "**********";
        public static string WeatherKey { get; private set; } = "";

        public static void SetWeatherKey(string newKey)
        {
            WeatherKey = newKey;
            ConfigurationManager.AppSettings["WeatherKey"] = WeatherKey;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var appSettingsSection = config.AppSettings.Settings;
            appSettingsSection.Remove("WeatherKey"); // 删除旧项
            appSettingsSection.Add("WeatherKey", WeatherKey); // 添加新项
            config.Save(ConfigurationSaveMode.Modified); // 保存更改

            config.Save(ConfigurationSaveMode.Modified);
        }

        public static void GetWeatherKey()
        {
            WeatherKey = ConfigurationManager.AppSettings["WeatherKey"];
        }
    }
}
