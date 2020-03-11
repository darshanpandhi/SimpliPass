using SimpliPassMobile.Views;
using Xamarin.Forms;

namespace SimpliPassMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var homePage = new NavigationPage(new DepartmentPage());
            var courseReviewPage = new NavigationPage(new CourseReviewPage());
            var courseRecommendationsPage = new NavigationPage(new CourseRecommendationsPage());
            var aboutPage = new NavigationPage(new AboutPage());

            homePage.Title = "Home";
            courseReviewPage.Title = "Course Review";
            courseRecommendationsPage.Title = "Recommendations";
            aboutPage.Title = "About";

            MainPage = new TabbedPage
            {
                Children = {
                    homePage,
                    courseReviewPage,
                    courseRecommendationsPage,
                    aboutPage
                }
            };
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