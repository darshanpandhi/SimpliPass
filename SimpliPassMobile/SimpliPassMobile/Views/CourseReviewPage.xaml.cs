using System;
using System.Collections.Generic;
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
            PostReview();
        }

        private void PostReview()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(CID.Text);
            Console.WriteLine(Name.Text);
            Console.WriteLine(Dept.Text);
            Console.WriteLine(SelectedDiff);
            Console.WriteLine(Instr.Text);
            Console.WriteLine(SelectedRating);
            Console.WriteLine("-------------------------");
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
