using BilibiliLiveHelper.Core.Models.QWeather;
using BilibiliLiveHelper.Core.Mvvm;
using BilibiliLiveHelper.Services.Interfaces;
using BilibiliLiveHelper.Services.Interfaces.QWeather;
using Prism.Commands;
using Prism.Regions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewCViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IGridWeatherService _weatherService;

        private readonly IMatchServices _matchServices;

        #endregion


        #region 属性

        private QueryParameters query = new QueryParameters();

        public QueryParameters Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
        }


        public DelegateCommand<string> DelegateCommand { get; set; }


        private Style imageStyle;

        public Style ImageStyle
        {
            get { return imageStyle; }
            set { SetProperty(ref imageStyle, value); }
        }


        private City city = new City();

        public City City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }



        private GridWeather weather = new GridWeather();

        public GridWeather Weather
        {
            get { return weather; }
            set { SetProperty(ref weather, value); }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        private string cityName;

        public string CityName
        {
            get { return cityName; }
            set { SetProperty(ref cityName, value); }
        }

        private string adm1;

        public string Adm1
        {
            get { return adm1; }
            set { SetProperty(ref adm1,value); }
        }

        private string adm2;

        public string Adm2
        {
            get { return adm2; }
            set { SetProperty(ref adm2, value); }
        }

        private string lat;

        public string Lat
        {
            get { return lat; }
            set { SetProperty(ref lat, value); }
        }

        private string lon;

        public string Lon
        {
            get { return lon; }
            set { SetProperty(ref lon, value); }
        }

        private string updateTime;

        public string UpdateTime
        {
            get { return updateTime; }
            set { SetProperty(ref updateTime, value); }
        }

        private string weatherText;

        public string WeatherText
        {
            get { return weatherText; }
            set { SetProperty(ref weatherText,value); }
        }


        private string weatherIcon;

        public string WeatherIcon
        {
            get { return weatherIcon; }
            set { SetProperty(ref weatherIcon, value); }
        }


        private string temperature;

        public string Temperature
        {
            get { return temperature; }
            set { SetProperty(ref temperature, value); }
        }

        private string windScale;

        public string WindScale
        {
            get { return windScale; }
            set { SetProperty(ref windScale, value); }
        }


        private string windDir;

        public string WindDir
        {
            get { return windDir; }
            set { SetProperty(ref windDir, value); }
        }

        private string humidity;

        public string Humidity
        {
            get { return humidity; }
            set { SetProperty(ref humidity, value); }
        }


        #endregion

        #region 函数

        public ViewCViewModel(IRegionManager regionManager, IGridWeatherService weatherService, IMatchServices matchServices) :
            base(regionManager)
        {
            _weatherService = weatherService;

            _matchServices = matchServices;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

            DelegateMethod("update_weather");

        }

        private void DelegateMethod(string command)
        {
            try
            {
                switch (command)
                {
                    case "update_weather":
                        City = _weatherService.GetCity();
                        Weather = _weatherService.GetGridWeather();
                        UpdateData();
                        ImageStyle = Application.Current.Resources["SunnyFill"] as Style;
                        break;
                    case "GetWeatherByCityName":
                        Query.requestURL = "https://geoapi.qweather.com/v2/city/lookup?";
                        Query.method = Method.Get;
                        // 自己申请
                        Query.key = "";
                        Query.location = Location;
                        City = _weatherService.GetCity(Query);
                        if (City.code.Equals("401"))
                        {
                            UpdateTime = City.code;
                            break;
                        }
                        Query.requestURL = "https://devapi.qweather.com/v7/grid-weather/now?";
                        var _location = City.location.FirstOrDefault(o => o.name.Equals(Location));
                        if (_location == null)
                        {
                            UpdateTime = "找不到该城市";
                            break;
                        }
                        Query.cityName = _location.name;
                        Query.lat = _location.lat;
                        Query.lon = _location.lon;
                        Query.adm1 = _location.adm1;
                        Query.adm2 = _location.adm2;
                        //Weather = _weatherService.GetGridWeather();
                        Weather = _weatherService.GetGridWeather(Query);
                        UpdateData();
                        ImageStyle = Application.Current.Resources[WeatherIcon] as Style;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                UpdateTime = ex.Message;
            }
        }

        public void UpdateData()
        {
            if (Weather.code.Equals("200"))
            {
                CityName = Query.cityName;
                Adm1 = Query.adm1;
                Adm2 = Query.adm2;
                UpdateTime = Weather.updateTime;
                WeatherText = Weather.now.text;
                WeatherIcon = WeatherCondition.GetWeatherCondition(Weather.now.icon);
                Temperature = Weather.now.temp;
                WindScale = Weather.now.windScale;
                WindDir = Weather.now.windDir;
                Humidity = Weather.now.humidity;
            }
            else
            {
                UpdateTime = $"Code:{Weather.code}";
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion
    }
}
