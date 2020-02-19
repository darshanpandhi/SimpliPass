using System;
using System.Collections.ObjectModel;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    public class CourseViewModel
    {

        public ObservableCollection<CourseModel> CourseList { get; set; }

        public CourseViewModel()
        {
            CourseList = new ObservableCollection<CourseModel>();

            CourseList.Add(new CourseModel { Name = "Course 1" });
            CourseList.Add(new CourseModel { Name = "Course 2" });
        }
    }
}
