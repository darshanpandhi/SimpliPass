using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using SimpliPassMobile.Models;
using SimpliPassMobile.ViewModels;
using Xamarin.Forms;

namespace SimpliPassMobile.Views
{
    public partial class DepartmentPage : ContentPage
    {
        private List<string> deptList;

        public DepartmentPage()
        {
            InitializeComponent();
            getDepartments();
            BindingContext = new DepartmentViewModel(deptList);
        }

        private void getDepartments()
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(Constants.API_BASE_URL + Constants.COURSE + Constants.DEPARTMENTS_LIST).Result;
            deptList = JsonConvert.DeserializeObject<List<string>>(response);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var temp = e.Item as DepartmentModel;
            await Navigation.PushAsync(new CoursePage(temp.Name));
        }
    }
}