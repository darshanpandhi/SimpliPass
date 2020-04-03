using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel for Course review page
    /// </summary>
    class CourseReviewViewModel
    {
        private readonly ISimpliPassHttpConnection CurrHttpConnection;

        public List<int> PickerLevels => Enumerable.Range(1, 10).ToList(); // Picker levels - from 1 to 10
        
        public string CourseDeptCode { get; set; }

        public string CourseNum { get; set; }

        public string Department { get; set; }

        public string CourseName { get; set; }

        public int DifficultyLevel { get; set; }

        public string Instructor { get; set; }

        public int InstructorRating { get; set; }

        public ICommand SubmitReviewCommand => new Command(HandleReviewSubmission);

        public CourseReviewViewModel(ISimpliPassHttpConnection argHttpConnection)
        {
            DifficultyLevel = -2;   // setting the intial picker values negative to display the placeholder
            InstructorRating = -2;
            CurrHttpConnection = argHttpConnection;
        }

        /// <summary>
        /// Method reposible for handling the review submission
        /// </summary>
        public void HandleReviewSubmission()
        {
            bool wasSuccess = false;
            if (!string.IsNullOrWhiteSpace(CourseDeptCode) && !string.IsNullOrWhiteSpace(CourseNum) && !string.IsNullOrWhiteSpace(CourseName) && !string.IsNullOrWhiteSpace(Department) && !string.IsNullOrWhiteSpace(Instructor) && DifficultyLevel <= 10 && DifficultyLevel > 0 && InstructorRating <= 10 && InstructorRating > 0)
            {
                var fullCourseID = CourseDeptCode + " " + CourseNum;
                bool found = false;
                var content = new StringContent("", Encoding.UTF8, "application/json");
                var response =  CurrHttpConnection.GetResource(Constants.COURSE);
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
                    wasSuccess =  CurrHttpConnection.PostResource(Constants.COURSE + Constants.NEW + fullCourseID + "/" + CourseName + "/" + Department + "/" + DifficultyLevel + "/" + Instructor + "/" + InstructorRating, content);
                }
                else // Existing Course
                {
                    wasSuccess =  CurrHttpConnection.PutResource(Constants.COURSE + fullCourseID + Constants.UPDATE + DifficultyLevel + "/" + Instructor + "/" + InstructorRating, content);
                }
            }

            if(wasSuccess)
            {
                MessagingCenter.Send(this, "SUCCESS");  // Messaging the Subscriber UI that review was added successfully
            }
            else
            {
                MessagingCenter.Send(this, "FAILURE"); // Messaging the Subscriber UI that review could not be added
            }
        }
    }
}
