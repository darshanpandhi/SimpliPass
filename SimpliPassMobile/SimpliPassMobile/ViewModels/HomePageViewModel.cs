using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel of Home Page
    /// </summary>
    class HomePageViewModel : INotifyPropertyChanged
    {
        public ISimpliPassHttpConnection CurrHttpConnection;

        public event PropertyChangedEventHandler PropertyChanged;

        public DepartmentListViewModel AttachedDepartmentListVM { get; set; }

        public CourseReviewViewModel AttachedCourseReviewVM { get; set; }
        public CourseRecommendationsViewModel AttachedRecommendationVM { get; set; }


        public string HomePageTitle => "Home";
        
        public string ReviewPageTitle => "Review a course";

        public string RecommendationsPageTitle => "Course Recommendations";

        public string AboutPageTitle => "About Us";

        public HomePageViewModel(ISimpliPassHttpConnection argHttpConnection)
        {
            PageChangedCommand = new Command(HandlePageChanged);
            CurrHttpConnection = argHttpConnection;
            AttachedDepartmentListVM = new DepartmentListViewModel(CurrHttpConnection);
            AttachedRecommendationVM = new CourseRecommendationsViewModel(CurrHttpConnection);
            AttachedCourseReviewVM = new CourseReviewViewModel(CurrHttpConnection);
        }
        
        public ICommand PageChangedCommand { get; private set; }

        /// <summary>
        /// Hanles the changing of tabs in the tabbedPage
        /// </summary>
        /// <param name="e"> Index of the tab selected </param>
        void HandlePageChanged(object e)
        {
            if (e.GetType() != typeof(NavigationPage))
            {
                return; // e is not a ContentPage, no need to handle
            }

            NavigationPage selectedPage = (NavigationPage)e;

            if(selectedPage.Title.Equals(HomePageTitle))
            {
                AttachedDepartmentListVM.GenerateDepartmentList();
                selectedPage.BindingContext = AttachedDepartmentListVM;
                selectedPage.Title = HomePageTitle; // Binding context changed, need to reset the title

            }
            else if(selectedPage.Title.Equals(ReviewPageTitle))
            {
                selectedPage.BindingContext = AttachedCourseReviewVM;
                selectedPage.Title = ReviewPageTitle; //Binding context changed, need to reset the title
            }
            else if (selectedPage.Title.Equals(RecommendationsPageTitle))
            {
                AttachedRecommendationVM.GenerateRecommendationsList();
                selectedPage.BindingContext = AttachedRecommendationVM;
                selectedPage.Title = RecommendationsPageTitle; //Binding context changed, need to reset the title
            }
        }
    }
}
