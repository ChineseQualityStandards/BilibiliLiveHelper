using BilibiliLiveHelper.Core.Mvvm;
using BilibiliLiveHelper.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewFViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion


        #region 属性

        public DelegateCommand<string> DelegateCommand { get; set; }

        #endregion

        #region 函数

        public ViewFViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
            _regionManager = regionManager;
           
            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
        }

        private void DelegateMethod(string command)
        {
            switch (command)
            {
                case "Exit":
                    Application.Current.Shutdown();
                    break;
                default:
                    MessageBox.Show("Test");
                    break;
            }
            //throw new NotImplementedException();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion
    }
}
