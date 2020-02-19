using System;
using System.Collections.ObjectModel;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    public class DepartmentViewModel
    {
        public ObservableCollection<DepartmentModel> DeptList { get; set; }

        public DepartmentViewModel()
        {
            DeptList = new ObservableCollection<DepartmentModel>();

            DeptList.Add(new DepartmentModel { Name = "Computer Science" });
            DeptList.Add(new DepartmentModel { Name = "Mathematics" });
        }
    }
}
