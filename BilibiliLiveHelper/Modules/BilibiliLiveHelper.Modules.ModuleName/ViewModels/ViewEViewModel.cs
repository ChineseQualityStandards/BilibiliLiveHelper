using BilibiliLiveHelper.Core;
using BilibiliLiveHelper.Core.Mvvm;
using BilibiliLiveHelper.Modules.ModuleName.Views;
using BilibiliLiveHelper.Services.Interfaces;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Unity.Injection;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewEViewModel : RegionViewModelBase
    {
        #region 字段

        
        private readonly IRegionManager _regionManager;

        #endregion


        #region 属性

        private bool IsCheck;

        public bool ToggleButton_Check
        {
            get { return IsCheck; }
            set 
            { 
                SetProperty(ref IsCheck,value);
                SolidColorBrush brush = IsCheck ? Brushes.Teal : Brushes.Transparent;
                SetBackground(brush);
            }
        }
        



        #endregion

        #region 函数

        public ViewEViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
            _regionManager = regionManager;
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        private void SetBackground(SolidColorBrush brush)
        {
            ((ViewA)_regionManager.Regions[RegionNames.ContentRegion].Views.FirstOrDefault()).Border.Background = brush;
            
        }
        
        #endregion
    }
}
