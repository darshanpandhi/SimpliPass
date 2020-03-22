using SimpliPassMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpliPassMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartmentListView : ContentPage
    {
        public DepartmentListView()
        {
            InitializeComponent();
        }

        private async void OnDepartmentSelected(object sender, ItemTappedEventArgs e)
        {
            ContentPage courseListPage = new DepartmentView();
            courseListPage.BindingContext = ((DepartmentListViewModel)BindingContext).GetContextedDeptVM(e.Item);
            await Navigation.PushAsync(courseListPage);
        }
    }
}