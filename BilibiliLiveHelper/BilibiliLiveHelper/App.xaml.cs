using BilibiliLiveHelper.Modules.ModuleName;
using BilibiliLiveHelper.Services;
using BilibiliLiveHelper.Services.Interfaces;
using BilibiliLiveHelper.Services.Interfaces.QWeather;
using BilibiliLiveHelper.Services.QWeather;
using BilibiliLiveHelper.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace BilibiliLiveHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IGridWeatherService,GridWeatherService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
