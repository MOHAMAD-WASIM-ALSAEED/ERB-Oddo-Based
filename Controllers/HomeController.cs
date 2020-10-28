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

namespace oddo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly odooHrContext _hRContext;
        private readonly List<IndexViewModel> _employees;

        public HomeController(ILogger<HomeController> logger)
        {
            _hRContext = new odooHrContext();
            _employees = new List<IndexViewModel>();
            foreach (var item in _hRContext.Employee.ToList<Employee>())
            {
                var Tags = _hRContext.Tags.Where(x => x.EmpId == item.Id).Select(x => x.CategoryId).ToList<double?>();
                var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();
                _employees.Add(new IndexViewModel { employee = item, tags = TagVAlues });
            }
            _logger = logger;
        }

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
            string BreadCrumbsIds = "";
            var Employee = _hRContext.Employee.FirstOrDefault(s => s.Id == id) ?? new Employee();
            BreadCrumbsIds = HttpContext.Session.GetString("Employee");
            BreadCrumbsIds += "-" + id.ToString();
            HttpContext.Session.SetString("Employee", BreadCrumbsIds);
            if (BreadCrumbsIds.Split("-").Length > 1) { 
            foreach (var item in BreadCrumbsIds.Split("-"))
            {
                EmployeeBreadCrumbs.Add(_hRContext.Employee.Where(x => x.Id.ToString() == item).FirstOrDefault());
            }
            }
            var Tags = _hRContext.Tags.Where(x => x.EmpId == Employee.Id).Select(x => x.CategoryId).ToList<double?>();
            var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();
            var department = _hRContext.Department.Where(x => x.Id == Employee.DepartmentId).FirstOrDefault();
            var EmployeeManeger = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.ParentId) ?? new Employee();
            var EmployeeCoach = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.CoachId) ?? new Employee();
            var EmployeepartnerId = _hRContext.User.FirstOrDefault(m => m.Id ==Employee.LeaveManagerId.ToString()) ?? new User();
            var timeoff = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerId.PartnerId) ?? new ResPartner();
            var EmployeepartnerRelatedId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.UserId.ToString()) ?? new User();
            var RelatedUser = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerRelatedId.PartnerId) ?? new ResPartner();
            var Country = _hRContext.Country.FirstOrDefault(m => m.Id == Employee.CountryId);
            var employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == id);
            while (employeeLoop.ParentId != null)
            {
                var parentid = employeeLoop.ParentId;
                employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == parentid);
                employeesTree.Add(employeeLoop);

            }
            employeesTree.Reverse();
            employeesTree.Add(Employee);
          
            EmployeeViewModel employeeViewModel2 = new EmployeeViewModel { Employee = Employee, Tags = TagVAlues, Department = department, Maneger = EmployeeManeger, Coach = EmployeeCoach, TimeOff = timeoff,RelatedUser=RelatedUser,CountryName=Country.Name,EmployeeTree=employeesTree,BreadCrumbsEmployees= EmployeeBreadCrumbs };
                 return View(employeeViewModel2);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
