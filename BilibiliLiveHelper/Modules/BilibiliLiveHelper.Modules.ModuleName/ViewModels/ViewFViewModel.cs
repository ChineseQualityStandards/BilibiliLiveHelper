using BilibiliLiveHelper.Core;
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
using System.Windows.Controls;

namespace BilibiliLiveHelper.Modules.ModuleName.ViewModels
{
    public class ViewFViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion


        #region 属性

        public DelegateCommand<string> DelegateCommand { get; set; }
        public DelegateCommand<PasswordBox> KeyCommand { get; set; }

        private string isLocked = "Lock";

        public string IsLocked
        {
            get { return isLocked; }
            set { SetProperty(ref isLocked,value); }
        }

        private bool canBeModified = false;

        public bool CanBeModified
        {
            get { return canBeModified; }
            set { SetProperty(ref canBeModified,value); }
        }

        private string encryptedString = Configurer.EncryptedString;

        public string EncryptedString
        {
            get { return encryptedString; }
            set { SetProperty(ref encryptedString,value); }
        }


        private string weatherKey;

        public string WeatherKey
        {
            get { return weatherKey; }
            set { SetProperty(ref weatherKey, value); }
        }


        #endregion

        #region 函数

        public ViewFViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
            _regionManager = regionManager;
           
            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
            KeyCommand = new DelegateCommand<PasswordBox>(DelegateMethod);

            Configurer.GetWeatherKey();
            WeatherKey = Configurer.WeatherKey;
        }

        private void DelegateMethod(string command)
        {
            switch (command)
            {
                case "Exit":
                    Application.Current.Shutdown();
                    break;
                case "IsLocked":
                    if (CanBeModified)
                    {
                        IsLocked = "Lock";
                        EncryptedString = Configurer.EncryptedString;
                    }
                    else
                    {
                        IsLocked = "Unlocked";
                        EncryptedString = WeatherKey;
                        
                    }
                    CanBeModified = !CanBeModified;
                    break;
                case "SetWeatherKey":
                    WeatherKey = EncryptedString;
                    Configurer.SetWeatherKey(EncryptedString);
                    break;
                default:
                    MessageBox.Show("Test");
                    break;
            }
            //throw new NotImplementedException();
        }

        private void DelegateMethod(PasswordBox box)
        {
            try
            {
                Configurer.SetWeatherKey(box.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion
    }
}
