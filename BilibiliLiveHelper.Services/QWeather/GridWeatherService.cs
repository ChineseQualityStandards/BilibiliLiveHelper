using BilibiliLiveHelper.Core.Models.QWeather;
using BilibiliLiveHelper.Services.Interfaces.QWeather;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

namespace BilibiliLiveHelper.Services.QWeather
{
    public class GridWeatherService : IGridWeatherService
    {
        public async Task<City> GetCityAsync(QueryParameters parameters)
        {
            string configure = "https://geoapi.qweather.com";
            RestClient client = new RestClient(configure);
            RestRequest request = new RestRequest();
            request.Method = Method.Get;

            request.AddBody("v2/city/lookup?");

            request.AddParameter("location", "广州");
            request.AddParameter("key", "855caff676ca48fda442297eedca302a");
            request.AddParameter("adm", "guangzhou");
            request.AddParameter("range", "cn");
            //request.AddParameter("number", "10");
            request.AddParameter("lang", "zh");

            //"https://geoapi.qweather.com/v2/city/lookup?location=广州&key=855caff676ca48fda442297eedca302a&adm=guangzhou&range=cn&number=20&lang=zh"

            RestResponse response = await client.ExecuteGetAsync(request);

            MessageBox.Show(response.Content);

            return JsonSerializer.Deserialize<City>(response.Content);
            
            
            
           
            
            //throw new NotImplementedException();
        }

        public async Task<GridWeather> GetGridWeatherAsync(QueryParameters parameters)
        {
            var options = new RestClientOptions("https://devapi.qweather.com/v7/grid-weather/now?");
            
            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = Method.Get;
            //request.AddBody("");
            request.AddParameter("location", "113.28064,23.12518");
            request.AddParameter("key", "855caff676ca48fda442297eedca302a");
            request.AddParameter("lang", "zh");


            /*var request =
            new RestRequest
            ("/v7/grid-weather/now?location=113.28064,23.12518&key=855caff676ca48fda442297eedca302a&lang=zh", Method.Get);
            */


            RestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);




            return JsonSerializer.Deserialize<GridWeather>(response.Content);
            //throw new NotImplementedException();
        }
    }
}
