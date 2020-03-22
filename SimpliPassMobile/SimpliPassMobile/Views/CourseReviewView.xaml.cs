using SimpliPassMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpliPassMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseReviewView : ContentPage
    {
        public CourseReviewView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<CourseReviewViewModel>(this, "SUCCESS", async(sender) =>
            {
                await DisplayAlert("Success!", "Review submitted.", "OK");
            });
            MessagingCenter.Subscribe<CourseReviewViewModel>(this, "FAILURE", async(sender) =>
            {
                await DisplayAlert("Error!", "Some fields are empty. Please fill out all the fields.", "OK");
            });
        }
    }
}