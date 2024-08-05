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
    public enum WeatherCondition
    {
        Sunny = 100,
        Cloudy = 101,
        FewClouds = 102,
        PartlyCloudy = 103,
        Overcast = 104,
        LightRain = 305
    }

    /// <summary>
    /// 天气状况[Fill]
    /// </summary>
    public enum WeatherConditionFill
    {
        SunnyFill = 100,
        CloudyFill = 101,
        FewCloudsFill = 102,
        PartlyCloudFill = 103,
        OvercastFill = 104,
        LightRainFill = 305
    }
}
