using SimpliPassMobile.Models;
using SimpliPassMobile.ViewModels;
using Xamarin.Forms;

namespace SimpliPassMobile.Views
{
    public partial class DepartmentPage : ContentPage
    {
        public DepartmentPage()
        {
            InitializeComponent();
            BindingContext = new DepartmentViewModel();
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var temp = e.Item as DepartmentModel;
            await Navigation.PushAsync(new CoursePage(temp.Name));
        }
    }
}