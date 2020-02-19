using System;
using System.Collections.Generic;
using SimpliPassMobile.ViewModels;
using Xamarin.Forms;

namespace SimpliPassMobile.Views
{
    public partial class CourseDetailsPage : ContentPage
    {
        public CourseDetailsPage(string Id, string Name, string Department, double Difficulty, int DifficultyCount, Dictionary<string, double> SectionRatings)
        {
            InitializeComponent();

            CurrID.Text = Id + " - " + Name;
            CurrDept.Text = "Department of " + Department;
            CurrDiff.Text = "Difficulty Level " + Difficulty.ToString();
            CurrDiffCount.Text = "Based on " + DifficultyCount + " reviews";

            BindingContext = new CourseDetailsViewModel(SectionRatings);
        }
    }
}
