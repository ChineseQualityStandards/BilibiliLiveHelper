﻿using BilibiliLiveHelper.Core.Mvvm;
using BilibiliLiveHelper.Services.Interfaces;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewBViewModel : RegionViewModelBase
    {

        #region 字段

        #endregion


        #region 属性

        #endregion

        #region 函数

        public ViewBViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
            
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion
    }
}
