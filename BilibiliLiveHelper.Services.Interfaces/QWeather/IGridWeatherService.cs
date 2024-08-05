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
        Task<City> GetCityAsync(QueryParameters parameters);

        /// <summary>
        /// 获取格点天气
        /// </summary>
        /// <param name="parameters">请求信息</param>
        /// <returns></returns>
        Task<GridWeather> GetGridWeatherAsync(QueryParameters parameters);  

    }
}
