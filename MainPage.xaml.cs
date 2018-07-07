using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        string translatedNumber { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        void OnTranslate (object sender, EventArgs e){
            translatedNumber = Core.PhoneTranslator.ToNumber(txtPhoneNumber.Text);
            if (!String.IsNullOrWhiteSpace(translatedNumber)){
                btnCall.IsEnabled = true;
                btnCall.Text = "Call " + translatedNumber;
            }
            else{
                btnCall.IsEnabled = false;
                btnCall.Text = "Call";
            }
        }

        async void OnCall (object sender, EventArgs e){
            if(await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + translatedNumber + "?",
                "Yes",
                "No")){
                var dialer = DependencyService.Get<iDialer>();
                if(dialer != null){
                    App.PhoneNumbers.Add(new PhoneNumber(){ ID = App.PhoneNumbers.Count, Number = translatedNumber });
                    btnHistory.IsEnabled = true;
                    //dialer.Dial(translatedNumber);
                }
            }   
        }

        async void OnCallHistory (object sender, EventArgs e){
            await Navigation.PushAsync(new CallHistoryPage());
        }
    }
}
