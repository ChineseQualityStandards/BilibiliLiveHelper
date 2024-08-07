using BilibiliLiveHelper.Core.Models.QWeather;
using BilibiliLiveHelper.Services.Interfaces.QWeather;
using Newtonsoft.Json;
using RestSharp;
using System.Web;
using System.Windows;

namespace BilibiliLiveHelper.Services.QWeather
{
    public class GridWeatherService : IGridWeatherService
    {
        public City GetCity()
        {

            var options = new RestClientOptions("https://geoapi.qweather.com/v2/city/lookup?");

            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("location", "广州");
            request.AddParameter("key", "");
            request.AddParameter("adm", "guangzhou");
            request.AddParameter("range", "cn");
            request.AddParameter("lang", "zh");

            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<City>(response.Content);
        }

        public City GetCity(QueryParameters query)
        {

            var options = new RestClientOptions(query.requestURL);

            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = query.method;
            request.AddParameter("location", query.location);
            request.AddParameter("key", query.key);
            //request.AddParameter("adm", "guangzhou");
            //request.AddParameter("range", "cn");
            //request.AddParameter("lang", "zh");

            RestResponse response = client.Execute(request);



            return JsonConvert.DeserializeObject<City>(response.Content);
        }


        public GridWeather GetGridWeather()
        {
            var options = new RestClientOptions("https://devapi.qweather.com/v7/grid-weather/now?");
            
            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            //request.AddBody("");
            request.AddParameter("location", "113.28064,23.12518");
            request.AddParameter("key", "");
            request.AddParameter("lang", "zh");

            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<GridWeather>(response.Content);
        }


        public GridWeather GetGridWeather(QueryParameters query)
        {
            var options = new RestClientOptions(query.requestURL);

            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = query.method;
     
            // 经纬度要注意，不要弄错了
            request.AddParameter("location", $"{query.lon},{query.lat}");
            request.AddParameter("key", query.key);
            request.AddParameter("lang", "zh");

            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<GridWeather>(response.Content);
        }
    }
}
