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
        public event PropertyChangedEventHandler PropertyChanged;

        public HomePageViewModel()
        {
            PageChangedCommand = new Command(HandlePageChanged);
        }
        
        public ICommand PageChangedCommand { get; private set; }

        /// <summary>
        /// Hanles the changing of tabs in the tabbedPage
        /// </summary>
        /// <param name="e"> Index of the tab selected </param>
        void HandlePageChanged(object e)
        {
            if (e.GetType() != typeof(int))
            {
                return; // e is not int, no need to handle
            }

            int tabIndex = (int)e;  // get the index of tab selected

            switch(tabIndex)
            {
                case 0:
                    new DepartmentListViewModel();
                    break;
                case 1:
                    new CourseReviewViewModel();
                    break;
                case 2:
                    new CourseRecommendationsViewModel();
                    break;
            }
        }
    }
}
