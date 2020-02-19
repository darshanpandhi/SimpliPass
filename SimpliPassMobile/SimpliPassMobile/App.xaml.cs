using System;
using SimpliPassMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpliPassMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DepartmentPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
