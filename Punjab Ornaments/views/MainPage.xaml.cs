using Punjab_Ornaments.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Punjab_Ornaments
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CalculateTotalamount();
        }

        private void CalculateTotalamount()
        {
        //    
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Mortgagemodel mortgagedata = new Mortgagemodel()
            {
                StartDate = startdatepicker.Date,
                EndDate = enddatepicker.Date,
                IntrestRate = int.Parse(intrestrate.Text),
                Validity = int.Parse(validity.Text),
                PrincipalAmount = int.Parse(principalamount.Text),
                IntrestAmount = int.Parse(intrestrate.Text) * (enddatepicker.Date - startdatepicker.Date).Days * int.Parse(principalamount.Text)/3000,
        };
            //Navigation.PushAsync(new views.DisplayResult(mortgagedata));



    }
}
}
