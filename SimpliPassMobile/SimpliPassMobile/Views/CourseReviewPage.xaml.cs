using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpliPassMobile.ViewModels;
using Xamarin.Forms;

namespace SimpliPassMobile.Views
{
    public partial class CourseReviewPage : ContentPage
    {
        private string SelectedDiff;
        private string SelectedRating;


        public CourseReviewPage()
        {
            InitializeComponent();
            SetupPickers();
        }

        private void OnClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CrsCode.Text) && !string.IsNullOrWhiteSpace(CrsNum.Text) && !string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(Dept.Text) && !string.IsNullOrWhiteSpace(SelectedDiff) && !string.IsNullOrWhiteSpace(Instr.Text) && !string.IsNullOrWhiteSpace(SelectedRating))
            {
                var fullCourseID = CrsCode.Text + " " + CrsNum.Text;
                Boolean found = false;
                HttpClient client = new HttpClient();
                var content = new StringContent("", Encoding.UTF8, "applicaion/json");
                var response = client.GetStringAsync(Constants.API_BASE_URL + Constants.COURSE).Result;
                List<object> courseList = JsonConvert.DeserializeObject<List<object>>(response);

                foreach (var crs in courseList)
                {
                    var id = JObject.Parse(crs.ToString())["id"].ToObject<string>();

                    if (id.ToUpper() == fullCourseID.ToUpper())
                    {
                        found = true;
                    }
                }

                if (!found) // New Course
                {
                    client.PostAsync(Constants.API_BASE_URL + Constants.COURSE + Constants.NEW + fullCourseID + "/" + Name.Text + "/" + Dept.Text + "/" + SelectedDiff + "/" + Instr.Text + "/" + SelectedRating, content);
                }
                else // Existing Course
                {
                    client.PutAsync(Constants.API_BASE_URL + Constants.COURSE + fullCourseID + Constants.UPDATE + SelectedDiff + "/" + Instr.Text + "/" + SelectedRating, content);
                }

                DisplayAlert("Success!", "Review submitted.", "Ok");
            }
            else
            {
                DisplayAlert("Error!", "Some fields are empty. Please fill out all the fields.", "Ok");
            }
        }

        private void DiffPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDiff = DiffPicker.Items[DiffPicker.SelectedIndex];
        }

        private void RatingPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRating = RatingPicker.Items[RatingPicker.SelectedIndex];
        }

        private void SetupPickers()
        {
            List<string> list = new List<string>();

            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.Add("6");
            list.Add("7");
            list.Add("8");
            list.Add("9");
            list.Add("10");

            DiffPicker.ItemsSource = list;
            RatingPicker.ItemsSource = list;
        }
    }
}
