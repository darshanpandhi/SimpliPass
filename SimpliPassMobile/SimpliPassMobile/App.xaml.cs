using SimpliPassMobile.Views;
using Xamarin.Forms;

namespace SimpliPassMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            if (!SimpliPassHttpConnection.Connect())
            {
                MainPage = new NoInternetPage();    // Http Connection was unsuccessful
                return;
            }
            MainPage = new HomePage();  // Http Connection successful, proceed to homepage
        }

        protected override void OnSleep()
        {
            SimpliPassHttpConnection.Disconnect();
        }

        protected override void OnResume()
        {
            if (!SimpliPassHttpConnection.Connect())
            {
                MainPage = new NoInternetPage();    // Http Connection was unsuccessful
                return;
            }
            MainPage = new HomePage();  // Http Connection successful, proceed to homepage
        }
    }
}