using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SimpliPassMobile.Views
{
    public partial class CourseDetailsPage : ContentPage
    {
        public CourseDetailsPage(string Name)
        {
            InitializeComponent();
            CurrCourse.Text = Name;
        }
    }
}
