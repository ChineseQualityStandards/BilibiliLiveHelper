using BilibiliLiveHelper.Core;
using BilibiliLiveHelper.Modules.ModuleName.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows.Controls;

namespace BilibiliLiveHelper.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, RegionNames.ViewA);
            _regionManager.RequestNavigate(RegionNames.ViewRegion,RegionNames.ViewB);
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();
            containerRegistry.RegisterForNavigation<ViewD>();
            containerRegistry.RegisterForNavigation<ViewE>();
            containerRegistry.RegisterForNavigation<ViewF>();
            containerRegistry.RegisterForNavigation<ViewG>();
            
        }
    }
}