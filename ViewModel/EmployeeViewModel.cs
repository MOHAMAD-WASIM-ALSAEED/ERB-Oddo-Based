using oddo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.ViewModel
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public Jobs Job { get; set; }
        public List<TagValue> Tags { get; set; }
        public Department Department { get; set; }
         public Employee Maneger { get; set; }
         public Employee Coach { get; set; }
         public ResPartner TimeOff { get; set; }
        public ResPartner RelatedUser { get; set; }
        public string CountryName { get; set; }
        public List<Employee> EmployeeTree { get; set; }
        public List<Employee> BreadCrumbsEmployees { get; set; }
        public List<Dependent> EmployeeDependents { get; set; }
        public List<Employee> EmployeeWithSameManeger { get; set; }
        public ResourceCalendar ResourceCalendar { get; set; }
        public Resources Timezone { get; set; }
    }
}
