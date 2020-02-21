using SimpliPassMobile.Models;
using SimpliPassMobile.ViewModels;
using Xamarin.Forms;

namespace SimpliPassMobile.Views
{
    public partial class CoursePage : ContentPage
    {
        public CoursePage(string Name)
        {
            InitializeComponent();
            CurrDept.Text = "Department of " + Name;
            BindingContext = new CourseViewModel(Name);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var temp = e.Item as CourseModel;
            await Navigation.PushAsync(new CourseDetailsPage(temp.Id, temp.Name, temp.Department, temp.Difficulty, temp.DifficultyCount, temp.SectionRatings));
        }
    }
}