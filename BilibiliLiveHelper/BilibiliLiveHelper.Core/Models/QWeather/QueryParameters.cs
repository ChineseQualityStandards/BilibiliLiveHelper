using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core.Models.QWeather
{
    /// <summary>
    /// 请求信息
    /// </summary>
    public class QueryParameters
    {
        public QueryParameters() { }
        public QueryParameters(string key, string location, string lat, string lon, string adm, string unit, string range, string lang, int? number)
        {
            _key = key;
            _location = location;
            _lat = lat;
            _lon = lon;
            _adm = adm;
            _unit = unit;
            _range = range;
            _lang = lang;
            _number = number;
        }

        /// <summary>
        /// [必选]用户认证key
        /// </summary>
        public string _key { get; set; }
        /// <summary>
        /// [选填]地区/城市名称或代码
        /// </summary>
        public string _location { get; set; }
        /// <summary>
        /// 地区/城市纬度
        /// </summary>
        public string _lat { get; set; }
        /// <summary>
        /// 地区/城市经度
        /// </summary>
        public string _lon { get; set; }
        /// <summary>
        /// [选填]城市的上级行政区划
        /// </summary>
        public string _adm { get; set; }
        /// <summary>
        /// 数据单位设置，可选值包括unit=m（公制单位，默认）和unit=i（英制单位）。
        /// </summary>
        public string _unit { get; set; } = "m";
        /// <summary>
        /// 搜索范围
        /// </summary>
        public string _range { get; set; } = "cn";
        /// <summary>
        /// 设置返回的语言格式
        /// </summary>
        public string _lang { get; set; } = "zh";
        /// <summary>
        /// 返回结果的数量，取值范围1-20，默认返回10个结果。
        /// </summary>
        public int? _number { get; set; } = 10;
    }
}
