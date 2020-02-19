using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpliPassMobile.Models;

namespace SimpliPassMobile.ViewModels
{
    public class DepartmentViewModel
    {
        public ObservableCollection<DepartmentModel> DeptList { get; set; }

        public DepartmentViewModel(List<string> deptList)
        {
            DeptList = new ObservableCollection<DepartmentModel>();

            foreach (string dept in deptList)
            {
                DeptList.Add(new DepartmentModel { Name = dept });
            }
        }
    }
}
