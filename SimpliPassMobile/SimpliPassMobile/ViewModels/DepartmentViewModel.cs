using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel for Department page
    /// </summary>
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        private readonly ISimpliPassHttpConnection CurrHttpConnection;

        public ObservableCollection<CourseModel> CourseList { get; set; }
        private List<object> courseList;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DepartmentName { get; set; }

        public string DepartmentDisplayName => $"Department of {DepartmentName}";

        public string selectText = string.Empty;

        public string SelectText
        {
            get => selectText;
            set
            {
                selectText = value;
                OnPropertyChanged(nameof(SelectText));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
        }

        public DepartmentViewModel(string argDepartmentName, ISimpliPassHttpConnection argHttpConnection)
        {
            CourseList = new ObservableCollection<CourseModel>();
            SelectText = "Select a Course";
            DepartmentName = argDepartmentName;
            OnPropertyChanged(DepartmentDisplayName);
            CurrHttpConnection = argHttpConnection;
        }

        /// <summary>
        /// Method which requests list of courses for the selected department
        /// </summary>
        public void GenerateCourseList()
        {
            CourseList = new ObservableCollection<CourseModel>();
            var json_response = CurrHttpConnection.GetResource(Constants.COURSE + Constants.DEPARTMENT_COURSES + DepartmentName);
            if (json_response == null)
            {
                return;
            }

            courseList = JsonConvert.DeserializeObject<List<object>>(json_response);

            foreach (var crs in courseList)
            {
                var id = JObject.Parse(crs.ToString())["id"]?.ToObject<string>();
                var name = JObject.Parse(crs.ToString())["name"]?.ToObject<string>();
                var dept = JObject.Parse(crs.ToString())["department"]?.ToObject<string>();
                var diff = JObject.Parse(crs.ToString())["difficulty"]?.ToObject<double>();
                var diffCount = JObject.Parse(crs.ToString())["difficultyCount"]?.ToObject<int>();
                var secRatings = JObject.Parse(crs.ToString())["sectionRatings"]?.ToObject<Dictionary<string, Dictionary<string, double>>>();

                if (id == null || name == null || dept == null || diff == null || diffCount == null || secRatings == null)
                    continue;
                CourseList.Add(new CourseModel { Id = id, Name = name, Department = dept, Difficulty = (double)diff, DifficultyCount = (int)diffCount, SectionRatings = secRatings });
            }
        }

        /// <summary>
        /// Gets an appropriate ViewModel with correct data based on selected Course
        /// </summary>
        /// <param name="e"> CourseModel object </param>
        /// <returns>Requested ViewModel if e is CourseModel, null otherwise</returns>
        public CourseDetailsViewModel GetContextedCourseVM(object e)
        {
            if (!(e is CourseModel))
            {
                return null;
            }
            CourseDetailsViewModel contextedCourseVM = new CourseDetailsViewModel((CourseModel)e);
            contextedCourseVM.ExtractSectionRatings();
            return contextedCourseVM;
        }
    }
}
