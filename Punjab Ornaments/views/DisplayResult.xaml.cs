using Punjab_Ornaments.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Punjab_Ornaments.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayResult : ContentPage
    {
        private Calculatemortgageview mortgagedata;

        public DisplayResult()
        {
            InitializeComponent();
        }

        public DisplayResult(Calculatemortgageview mortgagedata)
        {
            this.mortgagedata = mortgagedata;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}