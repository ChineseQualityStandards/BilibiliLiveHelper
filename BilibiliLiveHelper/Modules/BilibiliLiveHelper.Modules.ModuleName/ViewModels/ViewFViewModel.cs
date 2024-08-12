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

        private string encryptedString;

        public string EncryptedString
        {
            get { return encryptedString; }
            set { SetProperty(ref encryptedString,value); }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { SetProperty(ref location,value); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message,value); }
        }


        #endregion

        #region 函数

        public ViewFViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
            _regionManager = regionManager;
           
            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
            

            Configurer.GetWeatherKey();
            EncryptedString = Configurer.EncryptedString;

            Configurer.GetLocation();
            Location = Configurer.Location;
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
                        Message = " 隐藏了密钥";
                    }
                    else
                    {
                        IsLocked = "Unlocked";
                        EncryptedString = Configurer.WeatherKey;
                        Message = "显示了密钥";
                        
                    }
                    CanBeModified = !CanBeModified;
                    break;
                case "SetLocation":
                    Configurer.SetLocation(Location);
                    Message = "已更新默认城市";
                    break;
                case "SetWeatherKey":
                    Configurer.SetWeatherKey(EncryptedString);
                    Message = "已更新用户密钥";
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
