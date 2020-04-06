using SimpliPassMobile.ViewModels;
using SimpliPassMobile.Views;
using Xamarin.Forms;

namespace SimpliPassMobile
{
    public partial class App : Application
    {
        ISimpliPassHttpConnection httpConnection;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            httpConnection = new SimpliPassHttpConnection();
            if (!httpConnection.Connect())
            {
                MainPage = new NoInternetPage();    // Http Connection was unsuccessful
                return;
            }
            MainPage = new HomePage
            {
                BindingContext = new HomePageViewModel(httpConnection)
            };  // Http Connection successful, proceed to homepage
        }

        protected override void OnSleep()
        {
            httpConnection.Disconnect();
        }

        protected override void OnResume()
        {
            if (!httpConnection.Connect())
            {
                MainPage = new NoInternetPage();    // Http Connection was unsuccessful
                return;
            }
            MainPage = new HomePage();  // Http Connection successful, proceed to homepage
        }
    }
}