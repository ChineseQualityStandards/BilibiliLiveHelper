using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Core.Models.RestClient
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class RequestParameterModels
    {
        /// <summary>
        /// 可使用标志
        /// </summary>
        public bool Flag { get; set; } = false;
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestURL { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        public Method Method { get; set; } = Method.Get;
        /// <summary>
        /// 请求参数
        /// </summary>
        public Dictionary<string, string> paras { get; set; } = new Dictionary<string, string>();
    }
}
