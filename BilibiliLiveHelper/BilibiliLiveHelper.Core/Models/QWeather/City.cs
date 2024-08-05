using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core.Models.QWeather
{
    /// <summary>
    /// 城市的基本信息及列表
    /// </summary>
    public class City
    {
        public City() { }

        /// <summary>
        /// 状态码
        /// </summary>
        public string code {  get; set; }

        /// <summary>
        /// 和风天气城市的基本信息列表
        /// </summary>
        public ObservableCollection<Location> location { get; set; }

        /// <summary>
        /// 数据来源信息
        /// </summary>
        public Refer refer { get; set; }
    }

    /// <summary>
    /// 和风天气城市的基本信息
    /// </summary>
    public class Location
    {
        public Location() { }

        /// <summary>
        /// 地区/城市名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 地区/城市ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 地区/城市纬度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 地区/城市经度
        /// </summary>
        public string lon { get; set; }
        /// <summary>
        /// 地区/城市的上级行政区划名称
        /// </summary>
        public string adm1 { get; set; }
        /// <summary>
        /// 地区/城市所属一级行政区域
        /// </summary>
        public string adm2 { get; set; }
        /// <summary>
        /// 地区/城市所属国家名称
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 地区/城市所在时区
        /// </summary>
        public string tz { get; set; }
        /// <summary>
        /// 地区/城市目前与UTC时间偏移的小时数
        /// </summary>
        public string uctOffset { get; set; }
        /// <summary>
        /// 地区/城市是否当前处于夏令时。
        /// <![CDATA[0]]> 表示当前不是夏令时。
        /// <![CDATA[1]]> 表示当前处于夏令时。
        /// </summary>
        public string isDst { get; set; }
        /// <summary>
        /// 地区/城市的属性
        /// </summary>
        public string type { get; set; }
        /// <summary>
        ///  地区评分
        /// </summary>
        public string rank { get; set; }
        /// <summary>
        /// 该地区的天气预报网页链接，便于嵌入你的网站或应用
        /// </summary>
        public string fxLink { get; set; }

    }
}
