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
        public static string EncryptedString 
        { 
            get 
            { 
                return SetEncryptedString(WeatherKey, '*'); 
            } 
        }
        public static string WeatherKey { get; private set; } = string.Empty;
        public static string LocationRequestUrl { get; private set; } = string.Empty;
        public static string WeatherRequestUrl { get; private set; } = string.Empty;

        /// <summary>
        /// 生成一个和传入字符串一样长的字符串
        /// </summary>
        /// <param name="key">传入字符串</param>
        /// <param name="replacement">替换的字符</param>
        /// <returns>生成的带替换后符号的字符串</returns>
        public static string SetEncryptedString(string key, char replacement)
        {
            StringBuilder builder = new StringBuilder(); 
            foreach (char c in key)
            {
                builder.Append(replacement);
            }
            return builder.ToString();
        }

        public static void GetWeatherKey()
        {
            WeatherKey = ConfigurationManager.AppSettings["WeatherKey"];
        }

        public static void SetWeatherKey(string newKey)
        {
            WeatherKey = newKey;
            ConfigurationManager.AppSettings["WeatherKey"] = WeatherKey;

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var appSettingsSection = configuration.AppSettings.Settings;
            appSettingsSection.Remove("WeatherKey"); // 删除旧项
            appSettingsSection.Add("WeatherKey", WeatherKey); // 添加新项
            configuration.Save(ConfigurationSaveMode.Modified); // 保存更改
        }

        public static void GetLocationRequestUrl()
        {
            LocationRequestUrl = ConfigurationManager.AppSettings["LocationRequestUrl"];
        }

        public static void SetLocationRequestUrl(string newUrl)
        {
            LocationRequestUrl = newUrl;
            ConfigurationManager.AppSettings["LocationRequestUrl"] = LocationRequestUrl;
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettingsSection = configuration.AppSettings.Settings;
            appSettingsSection.Remove("LocationRequestUrl"); // 删除旧项
            appSettingsSection.Add("LocationRequestUrl",LocationRequestUrl); // 添加新项
            configuration.Save(ConfigurationSaveMode.Modified); // 保存更改
        }

        public static void GetWeatherRequestUrl()
        {
            WeatherRequestUrl = ConfigurationManager.AppSettings["WeatherRequestUrl"];
        }

        public static void SetWeatherRequestUrl(string newUrl)
        {
            WeatherRequestUrl = newUrl;
            ConfigurationManager.AppSettings["WeatherRequestUrl"] = WeatherRequestUrl;
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettingsSection = configuration.AppSettings.Settings;
            appSettingsSection.Remove("WeatherRequestUrl"); // 删除旧项
            appSettingsSection.Add("WeatherRequestUrl", WeatherRequestUrl); // 添加新项
            configuration.Save(ConfigurationSaveMode.Modified); // 保存更改
        }

        public static void ReLoadSetting()
        {
            GetWeatherKey();
            GetLocationRequestUrl();
            GetWeatherRequestUrl();
        }
    }
}
