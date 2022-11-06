using Punjab_Ornaments.services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Punjab_Ornaments.viewmodels
{
    public class HomePageViewModel:BaseViewModel
    {
        #region Constructor
        public HomePageViewModel()
        {
            ShowLatestRateAsync();
            //UnsubscribeMessaagingCenter();
            //SubscribeMessagingCenter();
        }

        #endregion

        #region Command
        public ICommand EditRateCommand => new Command(EditRateAsync);
        #endregion

        #region Method
        private async void ShowLatestRateAsync()
        {
            var metalrate = await Databaseservices.Database.GetMetalRateAsync();
            int latestvalue = metalrate.Count;
            if (latestvalue > 0)
            {
                GoldRate = metalrate[latestvalue-1].GoldRate.ToString();
                SilverRate = metalrate[latestvalue-1].SilverRate.ToString();
            }
            else
            {
                var route = $"{nameof(views.Popup.UpdateRatePopup)}";
                await Shell.Current.GoToAsync(route);
            }
        }
        private async void EditRateAsync(object obj)
        {
            var route = $"{nameof(views.Popup.UpdateRatePopup)}";
            await Shell.Current.GoToAsync(route);
        }

        public void RefreshName()
        {
            ShowLatestRateAsync();
        }
        void UnsubscribeMessaagingCenter()
        {
        }
        void SubscribeMessagingCenter()
        {
        }
        #endregion
        #region Properties
        private string _goldrate;
        public string GoldRate
        {
            get
            {
                return _goldrate;
            }
            set
            {
                _goldrate = value;
                OnPropertyChanged();
            }
        }
        private string _silverrate;
        public string SilverRate
        {
            get
            {
                return _silverrate;
            }
            set
            {
                _silverrate = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
