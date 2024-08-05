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
        /// 输入城市的基本信息
        /// </summary>
        /// <param name="code"><seealso cref="_code"/></param>
        /// <param name="locations"><seealso cref="_locations"/></param>
        /// <param name="refer"><seealso cref="_refer"/></param>
        public City(string code, ObservableCollection<Location> locations, Refer refer)
        {
            _code = code;
            _locations = locations;
            _refer = refer;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        private string _code {  get; set; }

        /// <summary>
        /// 和风天气城市的基本信息列表
        /// </summary>
        private ObservableCollection<Location> _locations { get; set; }

        /// <summary>
        /// 数据来源信息
        /// </summary>
        private Refer _refer { get; set; }
    }

    /// <summary>
    /// 和风天气城市的基本信息
    /// </summary>
    public class Location
    {
        public Location() { }
        /// <summary>
        /// 接收地区/城市信息
        /// </summary>
        /// <param name="name">地区/城市名称</param>
        /// <param name="id">地区/城市ID</param>
        /// <param name="lat">地区/城市纬度</param>
        /// <param name="lon">地区/城市经度</param>
        /// <param name="adm1">地区/城市的上级行政区划名称</param>
        /// <param name="adm2">地区/城市所属一级行政区域</param>
        /// <param name="country">地区/城市所属国家名称</param>
        /// <param name="tz">地区/城市所在时区</param>
        /// <param name="uctOffset">地区/城市目前与UTC时间偏移的小时数</param>
        /// <param name="isDst">地区/城市是否当前处于夏令时。 <![CDATA[0]]> 表示当前不是夏令时。<![CDATA[1]]> 表示当前处于夏令时。</param>
        /// <param name="type">地区/城市的属性</param>
        /// <param name="rank">地区评分</param>
        /// <param name="fxLink">该地区的天气预报网页链接</param>
        public Location(string? name, string? id, string? lat, string? lon,
            string? adm1, string? adm2, string? country, string? tz, string?
            uctOffset, string? isDst, string? type, string? rank, string? fxLink)
        {
            _name = name;
            _id = id;
            _lat = lat;
            _lon = lon;
            _adm1 = adm1;
            _adm2 = adm2;
            _country = country;
            _tz = tz;
            _uctOffset = uctOffset;
            _isDst = isDst;
            _type = type;
            _rank = rank;
            _fxLink = fxLink;
        }

        /// <summary>
        /// 地区/城市名称
        /// </summary>
        private string _name { get; set; }
        /// <summary>
        /// 地区/城市ID
        /// </summary>
        private string _id { get; set; }
        /// <summary>
        /// 地区/城市纬度
        /// </summary>
        private string _lat { get; set; }
        /// <summary>
        /// 地区/城市经度
        /// </summary>
        private string _lon { get; set; }
        /// <summary>
        /// 地区/城市的上级行政区划名称
        /// </summary>
        private string _adm1 { get; set; }
        /// <summary>
        /// 地区/城市所属一级行政区域
        /// </summary>
        private string _adm2 { get; set; }
        /// <summary>
        /// 地区/城市所属国家名称
        /// </summary>
        private string _country { get; set; }
        /// <summary>
        /// 地区/城市所在时区
        /// </summary>
        private string _tz { get; set; }
        /// <summary>
        /// 地区/城市目前与UTC时间偏移的小时数
        /// </summary>
        private string _uctOffset { get; set; }
        /// <summary>
        /// 地区/城市是否当前处于夏令时。
        /// <![CDATA[0]]> 表示当前不是夏令时。
        /// <![CDATA[1]]> 表示当前处于夏令时。
        /// </summary>
        private string _isDst { get; set; }
        /// <summary>
        /// 地区/城市的属性
        /// </summary>
        private string _type { get; set; }
        /// <summary>
        ///  地区评分
        /// </summary>
        private string _rank { get; set; }
        /// <summary>
        /// 该地区的天气预报网页链接，便于嵌入你的网站或应用
        /// </summary>
        private string _fxLink { get; set; }

    }
}
