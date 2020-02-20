using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    public class DepartmentViewModel
    {
        public ObservableCollection<DepartmentModel> DeptList { get; set; }
        private List<string> deptList;

        public DepartmentViewModel()
        {
            DeptList = new ObservableCollection<DepartmentModel>();
            Setup();
        }

        private void Setup()
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(Constants.API_BASE_URL + Constants.COURSE + Constants.DEPARTMENTS_LIST).Result;
            deptList = JsonConvert.DeserializeObject<List<string>>(response);

            foreach (string dept in deptList)
            {
                DeptList.Add(new DepartmentModel { Name = dept });
            }
        }
    }
}