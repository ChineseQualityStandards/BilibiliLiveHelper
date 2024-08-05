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


        /// <summary>
        /// 状态码
        /// </summary>
        public string code {  get; set; }
        /// <summary>
        /// 当前API的最近更新时间
        /// </summary>
        public string updateTime { get; set; }
        /// <summary>
        /// 当前数据的响应式页面，便于嵌入网站或应用
        /// </summary>
        public string fxLink { get; set; }
        /// <summary>
        /// 实时天气
        /// </summary>
        public Now now {  get; set; }
        /// <summary>
        /// 数据来源信息
        /// </summary>
        public Refer refer { get; set; }

    }
    /// <summary>
    /// 实时天气
    /// </summary>
    public class Now
    {

        public Now() { }

        

        /// <summary>
        /// 数据观测时间
        /// </summary>
        public string obsTime {  get; set; }
        /// <summary>
        /// 温度，默认单位：摄氏度
        /// </summary>
        public string  temp {  get; set; }
        /// <summary>
        /// 天气状况的图标代码
        /// </summary>
        public string icon {  get; set; }
        /// <summary>
        /// 天气状况的文字描述，包括阴晴雨雪等天气状态的描述
        /// </summary>
        public string text {  get; set; }
        /// <summary>
        /// 风向360角度
        /// </summary>
        public string wind360 {  get; set; }
        /// <summary>
        /// 风向
        /// </summary>
        public string windDir {  get; set; }
        /// <summary>
        /// 风力等级
        /// </summary>
        public string windScale {  get; set; }
        /// <summary>
        /// 风速，公里/小时
        /// </summary>
        public string windSpeed {  get; set; }
        /// <summary>
        /// 相对湿度，百分比数值
        /// </summary>
        public string humidity {  get; set; }
        /// <summary>
        /// 过去1小时降水量，默认单位：毫米
        /// </summary>
        public string precip {  get; set; }
        /// <summary>
        /// 大气压强，默认单位：百帕
        /// </summary>
        public string pressure {  get; set; }
        /// <summary>
        /// 云量，百分比数值。可能为空
        /// </summary>
        public string cloud {  get; set; }
        /// <summary>
        /// 露点温度。可能为空
        /// </summary>
        public string dew {  get; set; }
    }
}
