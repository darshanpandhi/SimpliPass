using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    public class CourseDetailsViewModel
    {
        public ObservableCollection<CourseDetailsModel> SectionRatings { get; set; }

        public CourseDetailsViewModel(Dictionary<string, double> secRatings)
        {
            SectionRatings = new ObservableCollection<CourseDetailsModel>();

            foreach (var rating in secRatings)
            {
                SectionRatings.Add(new CourseDetailsModel { Name = rating.Key, Rating = rating.Value });
            }
        }
    }
}