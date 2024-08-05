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

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewCViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IGridWeatherService _weatherService;

        #endregion


        #region 属性

        public DelegateCommand<string> DelegateCommand { get; set; }

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


        #endregion

        #region 函数

        public ViewCViewModel(IRegionManager regionManager, IGridWeatherService weatherService) :
            base(regionManager)
        {
            _weatherService = weatherService;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

        }

        private void DelegateMethod(string command)
        {
            switch (command)
            {
                case "update_weather":
                    Weather = _weatherService.GetGridWeatherAsync(new QueryParameters()).Result;
                    MessageBox.Show("");
                    break;
                default:
                    break;
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion
    }
}
