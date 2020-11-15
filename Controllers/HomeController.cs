using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oddo.Models;
using oddo.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Microsoft.Extensions.DependencyInjection;

namespace oddo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly odooHrContext _hRContext;
        private readonly odooHrContext _hRContextTemp;
        private readonly List<IndexViewModel> _employees;

        public HomeController(ILogger<HomeController> logger, odooHrContext odooHrContext, odooHrContext odooHrContextTemp)
        {
            _hRContext = odooHrContext;
            _hRContextTemp = odooHrContextTemp;
            _employees = new List<IndexViewModel>();
            foreach (var item in _hRContext.Employee.ToList<Employee>())
            {
                var Tags = _hRContext.Tags.Where(x => x.EmpId == item.Id).Select(x => x.CategoryId).ToList<double?>();
                var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();
                var Jobs = _hRContext.Jobs.FirstOrDefault(x => x.Id == item.JobId) ?? new Jobs();
                var image = _hRContext.Image.FirstOrDefault(x => x.EmployeeId == item.Id) ?? new image();
                _employees.Add(new IndexViewModel { employee = item, tags = TagVAlues, Job = Jobs, employeeImage = "data:image/png;base64," + image.ImageCode });
            }
            _logger = logger;
        }
        [ResponseCache(NoStore = true)]
        public IActionResult Index(int id)
        {
            HttpContext.Session.SetString("Employee", "");
            var department = _hRContext.Department.ToList<Department>();
            foreach (var item in department)
            {
                item.RouteLength = item.CompleteName.Split("/").Length;
                foreach (var ParentDepartment in department)
                {
                    if (ParentDepartment.ParentId == item.Id)
                    {
                        item.parentcount++;
                    }
                }


            }
            ViewBag.Department = department.OrderBy(x => x.Name).ToList<Department>();
            List<IndexViewModel> employees;
            if (id == 0)
            {
                employees = _employees.OrderBy(x => x.employee.Name).ToList<IndexViewModel>();
                return View(employees);
            }

            employees = _employees.Where(x => x.employee.DepartmentId == id).OrderBy(x => x.employee.Name).ToList<IndexViewModel>();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            List<Employee> employeesTree = new List<Employee>();
            List<Employee> EmployeeBreadCrumbs = new List<Employee>();
            List<Employee> EmployeeWithSameManeger = new List<Employee>();
            string BreadCrumbsIds = "";
            var Employee = _hRContext.Employee.FirstOrDefault(s => s.Id == id) ?? new Employee();
            BreadCrumbsIds = HttpContext.Session.GetString("Employee");
            BreadCrumbsIds += "-" + id.ToString();
            HttpContext.Session.SetString("Employee", BreadCrumbsIds);
            if (BreadCrumbsIds.Split("-").Length > 1)
            {
                foreach (var item in BreadCrumbsIds.Split("-"))
                {
                    if (EmployeeBreadCrumbs.Where(x => x.Id == Convert.ToDouble(item)).Count() > 0)
                    {
                        var index = EmployeeBreadCrumbs.IndexOf(EmployeeBreadCrumbs.Where(x => x.Id == Convert.ToDouble(item)).FirstOrDefault());
                        EmployeeBreadCrumbs.RemoveRange(index + 1, EmployeeBreadCrumbs.Count - index - 1);
                        continue;

                    }
                    if (!(item is null) && item != "")
                    {
                        EmployeeBreadCrumbs.Add(_hRContext.Employee.Where(x => x.Id.ToString() == item).FirstOrDefault());
                    }
                }
            }
            var Tags = _hRContext.Tags.Where(x => x.EmpId == Employee.Id).Select(x => x.CategoryId).ToList<double?>();
            var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();
            var department = _hRContext.Department.Where(x => x.Id == Employee.DepartmentId).FirstOrDefault();
            var EmployeeManeger = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.ParentId) ?? new Employee();
            var EmployeeCoach = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.CoachId) ?? new Employee();
            var EmployeepartnerId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.LeaveManagerId.ToString()) ?? new User();
            var timeoff = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerId.PartnerId) ?? new ResPartner();
            var EmployeepartnerRelatedId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.UserId.ToString()) ?? new User();
            var RelatedUser = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerRelatedId.PartnerId) ?? new ResPartner();
            var Country = _hRContext.Country.FirstOrDefault(m => m.Id == Employee.CountryId);
            var employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == id);
            var dependant = _hRContext.Dependent.Where(x => x.EmployeeDependantId == id).ToList<Dependent>();
            var Jobs = _hRContext.Jobs.FirstOrDefault(x => x.Id == Employee.JobId) ?? new Jobs();
            var resourcesCalender = _hRContext.ResourceCalendar.FirstOrDefault(x => x.Id == Employee.ResourceCalendarId) ?? new ResourceCalendar();
            var resources = _hRContext.Resources.FirstOrDefault(x => x.Id == Employee.ResourceId) ?? new Resources();
            var image = _hRContext.Image.FirstOrDefault(x => x.EmployeeId == Employee.Id) ?? new image();

            foreach (var item in dependant)
            {
                var birthday = item.Bdate;
                var daycount = ((DateAndTime.Now - birthday.Value).TotalDays);
                if (daycount < 730)
                {
                    item.Type = "Baby";
                }
                else if (daycount >= 730 && daycount < 4380)
                {
                    item.Type = "Child";
                }
                else
                {
                    item.Type = "Adult";
                }
            }

            while (employeeLoop.ParentId != null)
            {
                var parentid = employeeLoop.ParentId;
                employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == parentid);
                employeesTree.Add(employeeLoop);
            }
            foreach (var item in _hRContext.Employee.ToList<Employee>())
            {
                if (item.ParentId == id) EmployeeWithSameManeger.Add(item);
            }
            employeesTree.Reverse();
            employeesTree.Add(Employee);
            foreach (var item in employeesTree)
            {
                item.Job = _hRContext.Jobs.FirstOrDefault(x => x.Id == item.JobId) ?? new Jobs();
            }

            foreach (var item in EmployeeWithSameManeger)
            {
                item.Job = _hRContext.Jobs.FirstOrDefault(x => x.Id == item.JobId) ?? new Jobs();
            }
            EmployeeViewModel employeeViewModel = new EmployeeViewModel
            {
                Employee = Employee,
                Tags = TagVAlues,
                Department = department,
                Maneger = EmployeeManeger,
                Coach = EmployeeCoach,
                TimeOff = timeoff,
                RelatedUser = RelatedUser,
                CountryName = Country.Name,
                EmployeeTree = employeesTree,
                BreadCrumbsEmployees = EmployeeBreadCrumbs,
                EmployeeDependents = dependant,
                EmployeeWithSameManeger = EmployeeWithSameManeger,
                Job = Jobs,
                Timezone = resources,
                ResourceCalendar
            = resourcesCalender,
                employeeImage = "data:image/png;base64," + image.ImageCode
            };
            return View(employeeViewModel);
        }

        public IActionResult SecondaryDetail(int id)
        {
            List<Employee> EmployeeBreadCrumbs = new List<Employee>();
            var crumbsid = HttpContext.Session.GetString("Employee");
            if (crumbsid != null)
            {
                foreach (var item in crumbsid.Split("-"))
                {
                    if (EmployeeBreadCrumbs.Where(x => x.Id == Convert.ToDouble(item)).Count() > 0) { continue; }
                    if (!(item is null) && item != "")
                    {
                        EmployeeBreadCrumbs.Add(_hRContext.Employee.Where(x => x.Id.ToString() == item).FirstOrDefault());
                    }
                }
            }

            var Partner = _hRContext.ResPartner.FirstOrDefault(x => x.Id == id) ?? new ResPartner();
            var Data = new SecondaryDetailViewModel { User = Partner, BreadCrumbsEmployees = EmployeeBreadCrumbs };
            return View(Data);
        }
        [HttpGet]
        public IActionResult CreateEmployee(int id = 0)
        {
            if (id != 0)
            {
                List<Employee> employeesTree = new List<Employee>();
                List<Employee> EmployeeBreadCrumbs = new List<Employee>();
                List<Employee> EmployeeWithSameManeger = new List<Employee>();
                string BreadCrumbsIds = "";
                var Employee = _hRContext.Employee.FirstOrDefault(s => s.Id == id) ?? new Employee();
                BreadCrumbsIds = HttpContext.Session.GetString("Employee");
                BreadCrumbsIds += "-" + id.ToString();
                HttpContext.Session.SetString("Employee", BreadCrumbsIds);
                if (BreadCrumbsIds.Split("-").Length > 1)
                {
                    foreach (var item in BreadCrumbsIds.Split("-"))
                    {
                        if (EmployeeBreadCrumbs.Where(x => x.Id == Convert.ToDouble(item)).Count() > 0)
                        {
                            var index = EmployeeBreadCrumbs.IndexOf(EmployeeBreadCrumbs.Where(x => x.Id == Convert.ToDouble(item)).FirstOrDefault());
                            EmployeeBreadCrumbs.RemoveRange(index + 1, EmployeeBreadCrumbs.Count - index - 1);
                            continue;

                        }
                        if (!(item is null) && item != "")
                        {
                            EmployeeBreadCrumbs.Add(_hRContext.Employee.Where(x => x.Id.ToString() == item).FirstOrDefault());
                        }
                    }
                }
                var Tags = _hRContext.Tags.Where(x => x.EmpId == Employee.Id).Select(x => x.CategoryId).ToList<double?>();
                var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();
                var department = _hRContext.Department.Where(x => x.Id == Employee.DepartmentId).FirstOrDefault();
                var EmployeeManeger = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.ParentId) ?? new Employee();
                var EmployeeCoach = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.CoachId) ?? new Employee();
                var EmployeepartnerId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.LeaveManagerId.ToString()) ?? new User();
                var timeoff = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerId.PartnerId) ?? new ResPartner();
                var EmployeepartnerRelatedId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.UserId.ToString()) ?? new User();
                var RelatedUser = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerRelatedId.PartnerId) ?? new ResPartner();
                var Country = _hRContext.Country.FirstOrDefault(m => m.Id == Employee.CountryId);
                var employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == id);
                var dependant = _hRContext.Dependent.Where(x => x.EmployeeDependantId == id).ToList<Dependent>();
                var Jobs = _hRContext.Jobs.FirstOrDefault(x => x.Id == Employee.JobId) ?? new Jobs();
                var resourcesCalender = _hRContext.ResourceCalendar.FirstOrDefault(x => x.Id == Employee.ResourceCalendarId) ?? new ResourceCalendar();
                var resources = _hRContext.Resources.FirstOrDefault(x => x.Id == Employee.ResourceId) ?? new Resources();
                var image = _hRContext.Image.FirstOrDefault(x => x.EmployeeId == Employee.Id) ?? new image();

                foreach (var item in dependant)
                {
                    var birthday = item.Bdate;
                    var daycount = ((DateAndTime.Now - birthday.Value).TotalDays);
                    if (daycount < 730)
                    {
                        item.Type = "Baby";
                    }
                    else if (daycount >= 730 && daycount < 4380)
                    {
                        item.Type = "Child";
                    }
                    else
                    {
                        item.Type = "Adult";
                    }
                }

                while (employeeLoop.ParentId != null)
                {
                    var parentid = employeeLoop.ParentId;
                    employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == parentid);
                    employeesTree.Add(employeeLoop);
                }
                foreach (var item in _hRContext.Employee.ToList<Employee>())
                {
                    if (item.ParentId == id) EmployeeWithSameManeger.Add(item);
                }
                employeesTree.Reverse();
                employeesTree.Add(Employee);
                foreach (var item in employeesTree)
                {
                    item.Job = _hRContext.Jobs.FirstOrDefault(x => x.Id == item.JobId) ?? new Jobs();
                }

                foreach (var item in EmployeeWithSameManeger)
                {
                    item.Job = _hRContext.Jobs.FirstOrDefault(x => x.Id == item.JobId) ?? new Jobs();
                }
                EmployeeViewModel employeeViewModel = new EmployeeViewModel
                {
                    Employee = Employee,
                    Tags = TagVAlues,
                    Department = department,
                    Maneger = EmployeeManeger,
                    Coach = EmployeeCoach,
                    TimeOff = timeoff,
                    RelatedUser = RelatedUser,
                    CountryName = Country.Name,
                    EmployeeTree = employeesTree,
                    BreadCrumbsEmployees = EmployeeBreadCrumbs,
                    EmployeeDependents = dependant,
                    EmployeeWithSameManeger = EmployeeWithSameManeger,
                    Job = Jobs,
                    Timezone = resources,
                    ResourceCalendar
                = resourcesCalender,
                    employeeImage = "data:image/png;base64," + image.ImageCode
                };
                return View(employeeViewModel);
            }
            else
            {
                var Employees = _hRContext.Employee.ToList<Employee>();
                var resPartners = _hRContext.ResPartner.ToList<ResPartner>();
                EmployeeViewModel employeeViewModel = new EmployeeViewModel
                {

                    Tags = _hRContext.TagValue.ToList<TagValue>(),
                    Departments = _hRContext.Department.ToList<Department>(),
                    Jobs = _hRContext.Jobs.ToList<Jobs>(),
                    Manegers = Employees,
                    Addresses = resPartners,
                    Coachs = Employees,
                    TimeOffs = resPartners,
                    Expenses = resPartners,
                    ResourceCalendars = _hRContext.ResourceCalendar.ToList<ResourceCalendar>(),
                    Timezones = _hRContext.Resources.ToList<Resources>(),
                    Countries = _hRContext.Country.ToList<Country>(),
                    RelatedUsers = resPartners,



                };

                return View(employeeViewModel);
            }
        }

        [HttpPost]
        public void SaveChildren([FromBody] children[] Children)
        {

            
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeViewModel FormData)
        {
            var employee = new Employee {
                Name = FormData.Employee.Name,
                UserId =Convert.ToDouble( _hRContext.User.Where(x => x.Id == FormData.RelatedUser.Id.Value.ToString()).Select(x => x.Id).FirstOrDefault()),
                AddressHomeId=FormData.Employee.AddressHomeId,
                CountryId= FormData.Employee.CountryId,
                Gender= FormData.Employee.Gender,
                Marital= FormData.Employee.Marital,
                SpouseCompleteName= FormData.Employee.SpouseCompleteName,
                SpouseBirthdate= FormData.Employee.SpouseBirthdate,
                PlaceOfBirth= FormData.Employee.PlaceOfBirth,
                CountryOfBirth= FormData.Employee.CountryOfBirth,
                Birthday= FormData.Employee.Birthday,
                IdentificationId= FormData.Employee.IdentificationId,
                PassportId= FormData.Employee.PassportId,
                PermitNo= FormData.Employee.PermitNo,
                VisaNo= FormData.Employee.VisaNo,
                VisaExpire= FormData.Employee.VisaExpire,
                Certificate= FormData.Employee.Certificate,
                StudyField= FormData.Employee.StudyField,
                StudySchool= FormData.Employee.StudySchool,
                EmergencyContact= FormData.Employee.EmergencyContact,
                EmergencyPhone= FormData.Employee.EmergencyPhone,
                KmHomeWork= FormData.Employee.KmHomeWork,
                Barcode= FormData.Employee.Barcode,
                Pin= FormData.Employee.Pin,
                DepartmentId= FormData.Department.Id,
                JobId= FormData.Employee.Job.Id,
                JobTitle= FormData.Employee.JobTitle,
                CompanyId=1,
                AddressId= FormData.Address.Id,
                WorkPhone= FormData.Employee.WorkPhone,
                WorkLocation= FormData.Employee.WorkLocation,
                ResourceId= FormData.Timezone.Id,
                ResourceCalendarId= FormData.ResourceCalendar.Id,
                ParentId= FormData.Employee.ParentId,
                CoachId= FormData.Employee.CoachId,
                CreateDate=DateTime.Now,
                WriteDate=DateTime.Now,
                LeaveManagerId= FormData.TimeOff.Id,
                ExpenseManagerId= FormData.Expense.Id,
                XSpouseBirthdate= FormData.Employee.XSpouseBirthdate,
                XSpouseCompleteName= FormData.Employee.XSpouseCompleteName
            };
            _hRContext.Employee.Add(employee);
            _hRContext.SaveChanges();
            var image = new image { ImageCode = FormData.ImageEncoded,EmployeeId=Convert.ToInt32(employee.Id.Value) };
            

            return View();
        }
    }
}
