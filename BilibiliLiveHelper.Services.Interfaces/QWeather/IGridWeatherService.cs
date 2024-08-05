using BilibiliLiveHelper.Core.Models.QWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Services.Interfaces.QWeather
{
    public interface IGridWeatherService
    {

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <param name="parameters">请求信息</param>
        /// <returns>城市的基本信息及列表</returns>
        City GetCity();

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <param name="query">请求信息</param>
        /// <returns></returns>
        City GetCity(QueryParameters query);

        /// <summary>
        /// 获取格点天气
        /// </summary>
        /// <param name="parameters">请求信息</param>
        /// <returns></returns>
        GridWeather GetGridWeather();

        /// <summary>
        /// 获取格点天气
        /// </summary>
        /// <param name="query">请求信息</param>
        /// <returns></returns>
        GridWeather GetGridWeather(QueryParameters query);

    }
}
