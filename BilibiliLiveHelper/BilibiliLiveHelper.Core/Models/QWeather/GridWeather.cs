using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core.Models.QWeather
{
    /// <summary>
    /// 基于全球任意坐标的高精度实时天气，精确到3-5公里范围，包括：温度、湿度、大气压、天气状况、风力、风向等。
    /// </summary>
    public class GridWeather
    {
        public GridWeather(){ }

        public GridWeather(GridWeather weather) 
        {
            _code = weather._code;
            _updateTime = weather._updateTime;
            _fxLink = weather._fxLink;
            _now = weather._now;
            _refer = weather._refer;
        }

        /// <summary>
        /// 获取实时天气
        /// </summary>
        /// <param name="code"><seealso cref="_code"/></param>
        /// <param name="updateTime"><seealso cref="_updateTime"/></param>
        /// <param name="fxLink"><seealso cref="_fxLink"/></param>
        /// <param name="now"><seealso cref="_now"/></param>
        /// <param name="refer"><seealso cref="_refer"/></param>
        public GridWeather(string code, string updateTime, string fxLink, Now now, Refer refer)
        {
            _code = code;
            _updateTime = updateTime;
            _fxLink = fxLink;
            _now = now;
            _refer = refer;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        public string _code {  get; set; }
        /// <summary>
        /// 当前API的最近更新时间
        /// </summary>
        public string _updateTime { get; set; }
        /// <summary>
        /// 当前数据的响应式页面，便于嵌入网站或应用
        /// </summary>
        public string _fxLink { get; set; }
        /// <summary>
        /// 实时天气
        /// </summary>
        public Now _now {  get; set; } = new Now();
        /// <summary>
        /// 数据来源信息
        /// </summary>
        public Refer _refer { get; set; } = new Refer();

    }
    /// <summary>
    /// 实时天气
    /// </summary>
    public class Now
    {

        public Now() { }

        /// <summary>
        /// 接收当前天气
        /// </summary>
        /// <param name="obsTime"><seealso cref="_obsTime"/></param>
        /// <param name="temp"><seealso cref="_temp"/></param>
        /// <param name="icon"><seealso cref="_icon"/></param>
        /// <param name="text"><seealso cref="_text"/></param>
        /// <param name="wind360"><seealso cref="_wind360"/></param>
        /// <param name="windDir"><seealso cref="_windDir"/></param>
        /// <param name="windScale"><seealso cref="_windScale"/></param>
        /// <param name="windSpeed"><seealso cref="_windSpeed"/></param>
        /// <param name="humidity"><seealso cref="_humidity"/></param>
        /// <param name="precip"><seealso cref="_precip"/></param>
        /// <param name="pressure"><seealso cref="_pressure"/></param>
        /// <param name="cloud"><seealso cref="_cloud"/></param>
        /// <param name="dew"><seealso cref="_dew"/></param>
        public Now(string obsTime, string temp, string icon, string text, 
            string wind360, string windDir, string windScale, string windSpeed, 
            string humidity, string precip, string pressure, string cloud, string dew)
        {
            _obsTime = obsTime;
            _temp = temp;
            _icon = icon;
            _text = text;
            _wind360 = wind360;
            _windDir = windDir;
            _windScale = windScale;
            _windSpeed = windSpeed;
            _humidity = humidity;
            _precip = precip;
            _pressure = pressure;
            _cloud = cloud;
            _dew = dew;
        }

        /// <summary>
        /// 数据观测时间
        /// </summary>
        public string _obsTime {  get; set; }
        /// <summary>
        /// 温度，默认单位：摄氏度
        /// </summary>
        public string  _temp {  get; set; }
        /// <summary>
        /// 天气状况的图标代码
        /// </summary>
        public string _icon {  get; set; }
        /// <summary>
        /// 天气状况的文字描述，包括阴晴雨雪等天气状态的描述
        /// </summary>
        public string _text {  get; set; }
        /// <summary>
        /// 风向360角度
        /// </summary>
        public string _wind360 {  get; set; }
        /// <summary>
        /// 风向
        /// </summary>
        public string _windDir {  get; set; }
        /// <summary>
        /// 风力等级
        /// </summary>
        public string _windScale {  get; set; }
        /// <summary>
        /// 风速，公里/小时
        /// </summary>
        public string _windSpeed {  get; set; }
        /// <summary>
        /// 相对湿度，百分比数值
        /// </summary>
        public string _humidity {  get; set; }
        /// <summary>
        /// 过去1小时降水量，默认单位：毫米
        /// </summary>
        public string _precip {  get; set; }
        /// <summary>
        /// 大气压强，默认单位：百帕
        /// </summary>
        public string _pressure {  get; set; }
        /// <summary>
        /// 云量，百分比数值。可能为空
        /// </summary>
        public string _cloud {  get; set; }
        /// <summary>
        /// 露点温度。可能为空
        /// </summary>
        public string _dew {  get; set; }
    }
}
