using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core.Models.QWeather
{
    /// <summary>
    /// 天气状况
    /// </summary>
    public static class WeatherCondition
    {

        private static Dictionary<string,string> WeatherConditionMap = new Dictionary<string, string>() 
        {
            { "100", "Sunny" },
            { "101", "Cloudy" },
            { "102", "FewClouds" },
            { "103", "PartlyCloudy" },
            { "104", "Overcast" },
            { "150", "ClearNight" },
            { "151", "CloudyNight" },
            { "152", "FewCloudsNight" },
            { "153", "PartlyCloudyNight" },
            { "300", "ShowerRain" },
            { "301", "HeavyShowerRain" },
            { "302", "Thundershower" },
            { "303", "HeavyThunderstorm" },
            { "304", "ThundershowerWithHail" },
            { "305", "LightRain" },
            { "306", "ModerateRain" },
            { "307", "HeavyRain" },
            { "308", "ExtremeRain" },
            { "309", "DrizzleRain" },
            { "310", "Storm" },
        };


        private static Dictionary<string, string> WeatherConditionFillMap = new Dictionary<string, string>()
        {
            { "100", "SunnyFill" },
            { "101", "CloudyFill" },
            { "102", "FewCloudsFill" },
            { "103", "PartlyCloudyFill" },
            { "104", "OvercastFill" },
            { "150", "ClearNightFill" },
            { "151", "CloudyNightFill" },
            { "152", "FewCloudsNightFill" },
            { "153", "PartlyCloudyNightFill" },
            { "300", "ShowerRainFill" },
            { "301", "HeavyShowerRainFill" },
            { "302", "ThundershowerFill" },
            { "303", "HeavyThunderstormFill" },
            { "304", "ThundershowerWithHailFill" },
            { "305", "LightRainFill" },
            { "306", "ModerateRainFill" },
            { "307", "HeavyRainFill" },
            { "308", "ExtremeRainFill" },
            { "309", "DrizzleRain" },
            { "310", "Storm" },
        };

        public static string GetWeatherCondition(string code)
        {
            return WeatherConditionMap[code];
        }

        public static string GetWeatherConditionFill(string code)
        {
            return WeatherConditionFillMap[code];
        }
    }

}
