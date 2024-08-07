using RestSharp;
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

        /// <summary>
        /// 请求地址
        /// </summary>
        public string requestURL { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public Method method { get; set; }
        /// <summary>
        /// [必选]用户认证key
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// [选填]地区/城市名称或代码
        /// </summary>
        public string cityName { get; set; }
        /// <summary>
        /// [选填]地区/城市名称或代码
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 地区/城市纬度
        /// </summary>
        public string lat { get; set; }
        /// <summary>
        /// 地区/城市经度
        /// </summary>
        public string lon { get; set; }
        
        /// <summary>
        /// [选填]城市的上级行政区划
        /// </summary>
        public string adm1 { get; set; }
        /// <summary>
        /// [选填]城市
        /// </summary>
        public string adm2 { get; set; }
        /// <summary>
        /// 数据单位设置，可选值包括unit=m（公制单位，默认）和unit=i（英制单位）。
        /// </summary>
        public string unit { get; set; } = "m";
        /// <summary>
        /// 搜索范围
        /// </summary>
        public string range { get; set; } = "cn";
        /// <summary>
        /// 设置返回的语言格式
        /// </summary>
        public string lang { get; set; } = "zh";
        /// <summary>
        /// 返回结果的数量，取值范围1-20，默认返回10个结果。
        /// </summary>
        public int? number { get; set; } = 10;
    }
}
