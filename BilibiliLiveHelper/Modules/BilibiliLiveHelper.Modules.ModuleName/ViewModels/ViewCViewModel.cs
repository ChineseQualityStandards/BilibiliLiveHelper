using BilibiliLiveHelper.Core;
using BilibiliLiveHelper.Core.Models.QWeather;
using BilibiliLiveHelper.Core.Models.RestClient;
using BilibiliLiveHelper.Core.Mvvm;
using BilibiliLiveHelper.Services.Interfaces.Genericity;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewCViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRestClientService _restClientService;

        #endregion


        #region 属性

        private RequestParameterModels locationRequest;
        /// <summary>
        /// 查询地区请求
        /// </summary>
        public RequestParameterModels LocationRequest
        {
            get { return locationRequest; }
            set { SetProperty(ref locationRequest, value); }
        }

        private RequestParameterModels weatherRequest;
        /// <summary>
        /// 查询天气请求
        /// </summary>
        public RequestParameterModels WeatherRequest
        {
            get { return weatherRequest; }
            set { SetProperty(ref weatherRequest, value); }
        }



        public DelegateCommand<string> DelegateCommand { get; set; }


        private Style imageStyle;
        /// <summary>
        /// 天气图标样式
        /// </summary>
        public Style ImageStyle
        {
            get { return imageStyle; }
            set { SetProperty(ref imageStyle, value); }
        }


        private City city = new City();
        /// <summary>
        /// 地区信息
        /// </summary>
        public City City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }    


        private GridWeather weather = new GridWeather();
        /// <summary>
        /// 天气信息
        /// </summary>
        public GridWeather Weather
        {
            get { return weather; }
            set { SetProperty(ref weather, value); }
        }

        private string location;
        /// <summary>
        /// 地区名
        /// </summary>
        public string Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        private string cityName;
        /// <summary>
        /// 城市名
        /// </summary>
        public string CityName
        {
            get { return cityName; }
            set { SetProperty(ref cityName, value); }
        }

        private string adm1;
        /// <summary>
        /// 所属行政区域
        /// </summary>
        public string Adm1
        {
            get { return adm1; }
            set { SetProperty(ref adm1,value); }
        }

        private string adm2;
        /// <summary>
        /// 上级行政区域
        /// </summary>
        public string Adm2
        {
            get { return adm2; }
            set { SetProperty(ref adm2, value); }
        }

        private string updateTime;
        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateTime
        {
            get { return updateTime; }
            set { SetProperty(ref updateTime, value); }
        }

        private string weatherText;
        /// <summary>
        /// 天气描述
        /// </summary>
        public string WeatherText
        {
            get { return weatherText; }
            set { SetProperty(ref weatherText,value); }
        }


        private string weatherIcon;
        /// <summary>
        /// 天气图标编号
        /// </summary>
        public string WeatherIcon
        {
            get { return weatherIcon; }
            set { SetProperty(ref weatherIcon, value); }
        }


        private string temperature;
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature
        {
            get { return temperature; }
            set { SetProperty(ref temperature, value); }
        }

        private string windScale;
        /// <summary>
        /// 风力等级
        /// </summary>
        public string WindScale
        {
            get { return windScale; }
            set { SetProperty(ref windScale, value); }
        }


        private string windDir;
        /// <summary>
        /// 风向
        /// </summary>
        public string WindDir
        {
            get { return windDir; }
            set { SetProperty(ref windDir, value); }
        }

        private string humidity;
        /// <summary>
        ///  湿度
        /// </summary>
        public string Humidity
        {
            get { return humidity; }
            set { SetProperty(ref humidity, value); }
        }


        #endregion

        #region 函数

        public ViewCViewModel(IRegionManager regionManager, IRestClientService restClientService) :
            base(regionManager)
        {
            _restClientService = restClientService;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);


            // 创建地区请求对象
            LocationRequest = new RequestParameterModels() { Flag = true };
            // 创建天气请求对象
            WeatherRequest = new RequestParameterModels() { Flag = false };
            // 读取配置文件
            Configurer.ReLoadSetting();

            DelegateMethod("loading");

        }

        private async void DelegateMethod(string command)
        {
            try
            {
                switch (command)
                {
                    case "loading":
                        UpdateTime = "天气查询中……";
                        LocationRequest.Flag = true;
                        CityName = Configurer.Location;
                        UpdateRequest();
                        City = await _restClientService.GetAsync<City>(LocationRequest);
                        if (City.code != "200")
                            throw new DataException($"CityCode:{City.code}");
                        WeatherRequest.Flag = true;
                        UpdateRequest();
                        Weather = await _restClientService.GetAsync<GridWeather>(WeatherRequest);
                        if (Weather.code != "200")
                            throw new DataException($"WeatherCode:{Weather.code}");
                        UpdateData();
                        break;
                    case "GetWeatherByCityName":
                        UpdateTime = "天气查询中……";
                        LocationRequest.Flag = true;
                        CityName = Location;
                        UpdateRequest();
                        City = await _restClientService.GetAsync<City>(LocationRequest);
                        if (City.code != "200")
                            throw new DataException($"CityCode:{City.code}");
                        WeatherRequest.Flag = true;
                        UpdateRequest();
                        Weather = await _restClientService.GetAsync<GridWeather>(WeatherRequest);
                        if (Weather.code != "200")
                            throw new DataException($"WeatherCode:{Weather.code}");
                        UpdateData();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                UpdateTime = "DelegateMethod - " + ex.Message;
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData()
        {
            try
            {
                var c = City.location.FirstOrDefault(o => o.name.Equals(CityName));
                if (c != null)
                {
                    CityName = c.name;
                    Adm1 = c.adm1;
                    Adm2 = c.adm2;
                    UpdateTime = Weather.updateTime;
                    WeatherText = Weather.now.text;
                    WeatherIcon = WeatherCondition.GetWeatherCondition(Weather.now.icon);
                    Temperature = Weather.now.temp;
                    WindScale = Weather.now.windScale;
                    WindDir = Weather.now.windDir;
                    Humidity = Weather.now.humidity;
                    // 更新图标样式
                    ImageStyle = Application.Current.Resources[WeatherIcon] as Style;
                }
            }
            catch (Exception ex)
            {
                UpdateTime = "UpdateData - " + ex.Message;
            }
        }

        /// <summary>
        /// 更新请求内容
        /// </summary>
        public void UpdateRequest()
        {
            try
            {
                if (LocationRequest.Flag)
                {
                    // 获取请求地址
                    LocationRequest.RequestURL = Configurer.LocationRequestUrl;
                    LocationRequest.paras.Clear();
                    LocationRequest.paras.Add("location", CityName);
                    LocationRequest.paras.Add("key",Configurer.WeatherKey);
                    //LocationRequest.paras.Add("adm", "guangzhou");
                    LocationRequest.paras.Add("range", "cn");
                    LocationRequest.paras.Add("lang", "zh");
                    LocationRequest.Flag = false;
                }
                if (WeatherRequest.Flag)
                {
                    // 获取请求地址
                    WeatherRequest.RequestURL = Configurer.WeatherRequestUrl;
                    WeatherRequest.paras.Clear();
                    var _location = City.location.FirstOrDefault(o => o.name.Equals(CityName));
                    if(_location == null)
                        throw new ArgumentNullException("找不到城市");
                    WeatherRequest.paras.Add("location",$"{City.location.FirstOrDefault().lon},{City.location.FirstOrDefault().lat}");
                    WeatherRequest.paras.Add ("key",Configurer.WeatherKey);
                    WeatherRequest.paras.Add("lang", "zh");
                    WeatherRequest.Flag = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("UpdateRequest - " + ex.Message);
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion
    }
}
