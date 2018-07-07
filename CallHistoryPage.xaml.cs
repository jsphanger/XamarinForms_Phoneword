using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace Phoneword
{
    public partial class CallHistoryPage : ContentPage
    {
        public CallHistoryPage()
        {
            InitializeComponent();
        }

        public void OnDelete(object sender, EventArgs e){
            var mi = ((MenuItem)sender);

            if(mi.CommandParameter != null)
            {
                App.PhoneNumbers.Remove(App.PhoneNumbers.Where(x => x.ID == Convert.ToInt32(mi.CommandParameter)).FirstOrDefault());
                lstPhoneNumbers.ItemsSource = null;
                lstPhoneNumbers.ItemsSource = App.PhoneNumbers;
            }
        }
    }
}
