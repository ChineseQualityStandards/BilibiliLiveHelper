using BilibiliLiveHelper.Core.Models.RestClient;
using BilibiliLiveHelper.Services.Interfaces.Genericity;
using Newtonsoft.Json;
using RestSharp;

namespace BilibiliLiveHelper.Services.Genericity
{
    /// <summary>
    /// RestClient泛用类
    /// </summary>
    public class RestClientService : IRestClientService
    {
        public T Get<T>(RequestParameterModels rpms) where T : class 
        {
            var options = new RestClientOptions(rpms.RequestURL);

            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = rpms.Method;

            foreach ( var item in rpms.paras)
            {
                request.AddParameter(item.Key, item.Value);
            }

            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<T> GetAsync<T>(RequestParameterModels rpms) where T : class
        {
            var options = new RestClientOptions(rpms.RequestURL);

            var client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = rpms.Method;

            foreach (var item in rpms.paras)
            {
                request.AddParameter(item.Key, item.Value);
            }

            RestResponse response = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
