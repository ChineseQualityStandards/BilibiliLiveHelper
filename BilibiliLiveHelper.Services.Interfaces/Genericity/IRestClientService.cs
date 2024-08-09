using BilibiliLiveHelper.Core.Models.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Services.Interfaces.Genericity
{
    /// <summary>
    /// RestClient泛用接口
    /// </summary>
    public interface IRestClientService
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="requestURL">请求地址</param>
        /// <param name="paras">请求参数</param>
        /// <returns></returns>
        T Get<T>(RequestParameterModels rpms) where T : class;

        Task<T> GetAsync<T>(RequestParameterModels rpms) where T : class;
    }
}
