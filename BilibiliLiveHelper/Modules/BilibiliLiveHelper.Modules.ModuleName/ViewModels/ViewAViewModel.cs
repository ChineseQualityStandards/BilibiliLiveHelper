using BilibiliLiveHelper.Core;
using BilibiliLiveHelper.Core.Mvvm;
using BilibiliLiveHelper.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Windows;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;
        
        #endregion


        #region 属性

        private string borderColor = "Transparent";
        public string BorderColor
        {
            get { return borderColor; }
            set { SetProperty(ref borderColor, value); }
        }

        private int itemIndex = -1;
        

        public int ItemIndex
        {
            get 
            {
                return itemIndex; 
            }
            set 
            { 
                SetProperty(ref itemIndex,value);
                int move = (itemIndex-2) * 80;
                BubbleMargin = $"{move.ToString()},0,0,0";
                DelegateMethod(itemIndex.ToString());
            }
        }

        private string bubbleMargin = "-160,0,0,0";

        public string BubbleMargin
        {
            get { return bubbleMargin; }
            set { SetProperty(ref bubbleMargin, value); }
        }


        DelegateCommand<string> DelegateCommand { get; set; }

        #endregion

        #region 函数

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            _regionManager = regionManager;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
        }

        private void DelegateMethod(string command)
        {
            switch (command)
            {
                case "0":
                    _regionManager.RequestNavigate(RegionNames.ViewRegion, RegionNames.ViewB);
                    break;
                case "1":
                    _regionManager.RequestNavigate(RegionNames.ViewRegion, RegionNames.ViewC);
                    break;
                case "2":
                    _regionManager.RequestNavigate(RegionNames.ViewRegion, RegionNames.ViewD);
                    break;
                case "3":
                    _regionManager.RequestNavigate(RegionNames.ViewRegion, RegionNames.ViewE);
                    break;
                case "4":
                    _regionManager.RequestNavigate(RegionNames.ViewRegion, RegionNames.ViewF);
                    break;
                default:
                    //MessageBox.Show(command);
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
