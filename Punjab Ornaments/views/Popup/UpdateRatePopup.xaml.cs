using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Rg.Plugins.Popup.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Punjab_Ornaments.services;

namespace Punjab_Ornaments.views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateRatePopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        private List<models.MetalRate> metalRates;
        int latestvalue;
        #region Constructor
        public UpdateRatePopup()
        {
            InitializeComponent();
            ShowpreviousDataviaDBAsync();
            //ShowpreviousData();

        }

        private void ShowpreviousData()
        {
            MessagingCenter.Subscribe<object, string[]>(this, "rateadded", (Sender,metal) =>
            {
                goldvaluelabel.Text = metal[0].ToString();
                silvervaluelabel.Text = metal[1].ToString();
            });
        }
        private async void ShowpreviousDataviaDBAsync()
        {
            metalRates = await Databaseservices.Database.GetMetalRateAsync();
            latestvalue = metalRates.Count;
            if (latestvalue > 0)
            {
                goldvaluelabel.Text = metalRates[latestvalue -1].GoldRate.ToString();
                silvervaluelabel.Text = metalRates[latestvalue - 1].SilverRate.ToString();
            }
            else
            {
                goldvaluelabel.Text = "";
                silvervaluelabel.Text = "";
            }
        }

        #endregion
        private async void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
        private async void Done_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if((goldvaluelabel.Text != metalRates[latestvalue - 1].GoldRate.ToString()) || (silvervaluelabel.Text != metalRates[latestvalue - 1].SilverRate.ToString()))
                {
                    models.MetalRate rate = new models.MetalRate()
                    {
                      GoldRate = Int32.Parse(goldvaluelabel.Text),
                      SilverRate = Int32.Parse(silvervaluelabel.Text),
                    };
                    await Databaseservices.Database.AddMetalRateAsync(rate);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}