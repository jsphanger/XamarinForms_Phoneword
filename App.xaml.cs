using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {
        public static IList<PhoneNumber> PhoneNumbers { get; set; }

        public App()
        {
            InitializeComponent();

            PhoneNumbers = new List<PhoneNumber>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public class PhoneNumber{
        public int ID { get; set; }
        public string Number { get; set; }
    }
}
