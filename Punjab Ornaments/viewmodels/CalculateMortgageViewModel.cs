using Punjab_Ornaments.viewmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Punjab_Ornaments.viewmodels
{
    public class CalculateMortgageViewModel:BaseViewModel
    {
        #region Command
        public ICommand CalculateMortgageCommand => new Command(CalculateMortgageAsync);

        #endregion

        #region Property

        private DateTime _startdate = DateTime.Now;
        public DateTime Startdate
        {
            get
            {
               return _startdate;
            }
            set
            {
                _startdate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _enddate = DateTime.Now;
        public DateTime Enddate
        {
            get
            {
                return _enddate;
            }
            set
            {
                _enddate = value;
                OnPropertyChanged();
            }
        }

        private int _mortgageamount;
        public int MortgageAmount
        {
            get
            {
                return _mortgageamount;
            }
            set
            {
                _mortgageamount = value;
                OnPropertyChanged();
            }
        }

        private int _mortgagerate = 3;
        public int MortgageRate
        {
            get
            {
                return _mortgagerate;
            }
            set
            {
                _mortgageamount = value;
                OnPropertyChanged();
            }
        }

        private int _mortgagevalidity = 0;
        public int MortgageValidity
        {
            get
            {
                return _mortgagevalidity;
            }
            set 
            {
                _mortgagevalidity = value;
                OnPropertyChanged();
            }

        }

        #endregion

        #region Method
        private async void CalculateMortgageAsync(object obj)
        {
            TimeSpan DayDifference = Enddate - Startdate;
            int IntrestAmount = 0, TotalAmount;
            if (DayDifference.Days > 0)
            {
                int Totaldays = (DayDifference.Days <= 30)? 30: DayDifference.Days;

                if (MortgageValidity > 0 && (MortgageValidity*30) < Totaldays)
                {
                    int NewAmount = MortgageAmount;
                    while(Totaldays > 30)
                    {
                        IntrestAmount = IntrestAmount + (NewAmount * MortgageRate/100);
                        NewAmount = NewAmount + IntrestAmount;
                        Totaldays = Totaldays - 30;
                    }

                    IntrestAmount = IntrestAmount + (NewAmount* Totaldays * MortgageRate / 3000);
                }
                else
                {
                    IntrestAmount = (MortgageAmount * Totaldays * MortgageRate) / 3000;
                }

                TotalAmount = MortgageAmount + IntrestAmount;
                string Head = "Payable Amount " + TotalAmount.ToString();
                string Body = "Total days = " + Totaldays.ToString() + "\n"
                            + "Amount = " + MortgageAmount.ToString() + "\n"
                            + "Intrest Amount = " + IntrestAmount.ToString() +"\n"
                            + "Total Amount =" + TotalAmount.ToString();

                await Application.Current.MainPage.DisplayAlert(Head, Body, "Okay");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "End Date must be greater then Start date", "okay");
            }
        }

        #endregion
    }
}
