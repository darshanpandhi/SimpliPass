using System;
using System.Collections.Generic;
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
            BindingContext = new CourseViewModel();
            CurrDept.Text = Name;
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var temp = e.Item as CourseModel;
            await Navigation.PushAsync(new CourseDetailsPage(temp.Name));
        }
    }
}
