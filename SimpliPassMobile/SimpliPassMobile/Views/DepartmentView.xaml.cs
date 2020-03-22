using SimpliPassMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpliPassMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartmentView : ContentPage
    {
        public DepartmentView()
        {
            InitializeComponent();
        }

        private async void OnCourseSelected(object sender, ItemTappedEventArgs e)
        {
            ContentPage courseDetailsPage = new CourseDetailsView();
            courseDetailsPage.BindingContext = ((DepartmentViewModel)BindingContext).GetContextedCourseVM(e.Item);
            await Navigation.PushAsync(courseDetailsPage);
        }
    }
}