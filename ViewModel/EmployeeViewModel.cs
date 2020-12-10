using Microsoft.AspNetCore.Http;
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
        public List<Jobs> Jobss { get; set; }
        public List<TagValue> Tags { get; set; }
        public int[] TagIds { get; set; }
        public Department Departmente { get; set; }
        public List<Department> Departments { get; set; }
        public Employee Maneger { get; set; }
        public List<Employee> Manegers { get; set; }
         public Employee Coach { get; set; }
         public List<Employee> Coachs { get; set; }
         public ResPartner TimeOff { get; set; }
        public ResPartner RelatedUser { get; set; }
        public List<ResPartner> RelatedUsers { get; set; }
        public string CountryName { get; set; }
        public List<Country> Countries { get; set; }
        public List<Employee> EmployeeTree { get; set; }
        public List<Employee> BreadCrumbsEmployees { get; set; }
        public List<Dependent> EmployeeDependents { get; set; }
        public List<Employee> EmployeeWithSameManeger { get; set; }
        public ResourceCalendar ResourceCalendar { get; set; }
        public List<ResourceCalendar> ResourceCalendars { get; set; }
        public Resources Timezone { get; set; }
        public List<Resources> Timezones { get; set; }
        public string employeeImage { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string ImageEncoded { get; set; }
        public ResPartner Address { get; set; }
        public List<ResPartner> Addresses { get; set; }

        public List<ResPartner> Expenses { get; set; }
        public ResPartner Expense { get; set; }
        public List<ResPartner> TimeOffs { get; set; }
        public string Dependants { get; set; }

        public IFormFile IdentityCard { get; set; }
        public IFormFile MedicalInsurance { get; set; }
        public IFormFile Documents { get; set; }
        public IFormFile Warningsdeductions { get; set; }
        public Resume EmployeeResume { get; set; }
        public List<Resume> EmployeeResumes { get; set; }
        public List<ResumeLineType> EmployeeResumesTypes { get; set; }
        public List<Skill> EmployeeSkills { get; set; }
        public Skill EmployeeSkill { get; set; }

    }
}
