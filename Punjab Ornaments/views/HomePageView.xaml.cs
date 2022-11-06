using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punjab_Ornaments.viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Punjab_Ornaments.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage
    {
        public HomePageView()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as HomePageViewModel;
            //vm.refresh();
        }
    }
}