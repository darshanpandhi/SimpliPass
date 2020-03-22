using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    /// <summary>
    /// ViewModel for Department List page
    /// </summary>
    class DepartmentListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DepartmentModel> DepartmentList { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> deptList;

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

        public string LogoPath { get { return Constants.LOGO_PATH; } }

        public DepartmentListViewModel()
        {
            DepartmentList = new ObservableCollection<DepartmentModel>();
            SelectText = "Select a Department";
            GenerateDepartmentList();
        }

        /// <summary>
        /// Method that requests the list of all available departments
        /// </summary>
        public void GenerateDepartmentList()
        {
            DepartmentList = new ObservableCollection<DepartmentModel>();
            var json_response = SimpliPassHttpConnection.GetResource(Constants.COURSE + Constants.DEPARTMENTS_LIST);
            deptList = JsonConvert.DeserializeObject<List<string>>(json_response);

            foreach (string dept in deptList)
            {
                DepartmentList.Add(new DepartmentModel { Name = dept });
            }
        }

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
        }

        /// <summary>
        /// Gets an appropriate ViewModel with correct data based on selected Department
        /// </summary>
        /// <param name="e"> DepartmentModel object </param>
        /// <returns>Requested ViewModel if e is DepartmentModel, null otherwise</returns>
        public DepartmentViewModel GetContextedDeptVM(object e)
        {
            if (!(e is DepartmentModel))
            {
                return null;
            }
            string dept_name = (e as DepartmentModel)?.Name;
            return new DepartmentViewModel(dept_name);
        }
    }
}