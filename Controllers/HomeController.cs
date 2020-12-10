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
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace oddo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly odooHrContext _hRContext;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, odooHrContext odooHrContext, IWebHostEnvironment env)
        {
            _hRContext = odooHrContext;
            _env = env;
            _logger = logger;
        }
        [ResponseCache(NoStore = true)]
        public IActionResult Index(int id)
        {
           var _employees = new List<IndexViewModel>();
            foreach (var item in _hRContext.Employee.ToList<Employee>())
            {
                var Tags = _hRContext.Tags.Where(x => x.EmpId == item.Id).Select(x => x.CategoryId).ToList<double?>();
                var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();
                var Jobs = _hRContext.Jobs.FirstOrDefault(x => x.Id == item.JobId) ?? new Jobs();
                var image = _hRContext.Image.FirstOrDefault(x => x.EmployeeId == item.Id) ?? new image();
                _employees.Add(new IndexViewModel { employee = item, tags = TagVAlues, Job = Jobs, employeeImage = "data:image/png;base64," + image.ImageCode });
            }
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
            var EmployeepartnerId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.LeaveManagerId) ?? new User();
            var timeoff = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerId.PartnerId) ?? new ResPartner();
            var EmployeepartnerRelatedId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.UserId) ?? new User();
            var RelatedUser = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerRelatedId.PartnerId) ?? new ResPartner();
            var Country = _hRContext.Country.FirstOrDefault(m => m.Id == Employee.CountryId) ?? new Country();
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

            while (employeeLoop?.ParentId != null)
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
                Departmente = department,
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
                List<Employee> EmployeeWithSameManeger = new List<Employee>();
                var Employees = _hRContext.Employee.ToList<Employee>();
                var resPartners = _hRContext.ResPartner.ToList<ResPartner>();
                var Employee = _hRContext.Employee.FirstOrDefault(s => s.Id == id) ?? new Employee();
                var employeeLoop = _hRContext.Employee.FirstOrDefault(s => s.Id == id);
                var dependant = _hRContext.Dependent.Where(x => x.EmployeeDependantId == id).ToList<Dependent>();
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
                var EmployeepartnerId = _hRContext.User.FirstOrDefault(m => m.Id == Employee.LeaveManagerId) ?? new User();
                var Tags = _hRContext.Tags.Where(x => x.EmpId == id).Select(x => x.CategoryId).ToList<double?>();
                var TagVAlues = _hRContext.TagValue.Where(x => Tags.Contains(x.Id)).ToList<TagValue>();

                EmployeeViewModel employeeViewModel = new EmployeeViewModel
                {
                    Employee = Employee,
                    Departmente = _hRContext.Department.Where(x => x.Id == Employee.DepartmentId).FirstOrDefault(),
                    Job = _hRContext.Jobs.FirstOrDefault(x => x.Id == Employee.JobId) ?? new Jobs(),
                    Coach = _hRContext.Employee.FirstOrDefault(m => m.Id == Employee.CoachId) ?? new Employee(),
                    TimeOff = _hRContext.ResPartner.FirstOrDefault(m => m.Id.ToString() == EmployeepartnerId.PartnerId) ?? new ResPartner(),
                    RelatedUser = _hRContext.ResPartner.FirstOrDefault(m => m.Id == Employee.UserId) ?? new ResPartner(),
                    ResourceCalendar = _hRContext.ResourceCalendar.FirstOrDefault(x => x.Id == Employee.ResourceCalendarId) ?? new ResourceCalendar(),
                    Timezone = _hRContext.Resources.FirstOrDefault(x => x.Id == Employee.ResourceId) ?? new Resources(),
                    Address = _hRContext.ResPartner.FirstOrDefault(m => m.Id == Employee.UserId) ?? new ResPartner(),
                    Expense = _hRContext.ResPartner.FirstOrDefault(m => m.Id == Employee.UserId) ?? new ResPartner(),
                    EmployeeTree = employeesTree,
                    EmployeeDependents = dependant,
                    EmployeeWithSameManeger = EmployeeWithSameManeger,
                    Tags = _hRContext.TagValue.ToList<TagValue>(),
                    Departments = _hRContext.Department.ToList<Department>(),
                    Jobss = _hRContext.Jobs.ToList<Jobs>(),
                    Manegers = Employees,
                    Addresses = resPartners,
                    Coachs = Employees,
                    TimeOffs = resPartners,
                    Expenses = resPartners,
                    ResourceCalendars = _hRContext.ResourceCalendar.ToList<ResourceCalendar>(),
                    Timezones = _hRContext.Resources.ToList<Resources>(),
                    Countries = _hRContext.Country.ToList<Country>(),
                    RelatedUsers = resPartners,
                    ImageEncoded = "data:image/png;base64," + image.ImageCode,
                    TagIds = TagVAlues.Select(x => x.Id).ToList<int>().ToArray(),
                    EmployeeResume = new Resume(),
                    EmployeeSkill = new Skill(),
                    EmployeeResumes = new List<Resume>(),
                    EmployeeSkills= new List<Skill>(),
                };
                return View(employeeViewModel);
            }
            else
            {
                var Employees = _hRContext.Employee.ToList<Employee>();
                var resPartners = _hRContext.ResPartner.ToList<ResPartner>();
                EmployeeViewModel employeeViewModel = new EmployeeViewModel
                {

                    Employee = new Employee(),
                    Tags = _hRContext.TagValue.ToList<TagValue>(),
                    Departments = _hRContext.Department.ToList<Department>(),
                    Jobss = _hRContext.Jobs.ToList<Jobs>(),
                    Manegers = Employees,
                    Addresses = resPartners,
                    Coachs = Employees,
                    TimeOffs = resPartners,
                    Expenses = resPartners,
                    ResourceCalendars = _hRContext.ResourceCalendar.ToList<ResourceCalendar>(),
                    Timezones = _hRContext.Resources.ToList<Resources>(),
                    Countries = _hRContext.Country.ToList<Country>(),
                    RelatedUsers = resPartners,
                    EmployeeDependents = new List<Dependent>(),
                    EmployeeResume = new Resume(),
                    EmployeeSkill = new Skill(),
                    EmployeeResumes = _hRContext.Resumes.ToList(),
                    EmployeeSkills = new List<Skill>(),
                    EmployeeResumesTypes = _hRContext.ResumeLineTypes.ToList(),

                };

                return View(employeeViewModel);
            }
        }


        [HttpPost]
        public IActionResult CreateEmployee(EmployeeViewModel FormData)
        {
            double? userid = null;
            int idforroute;
            if (FormData.RelatedUser != null)
            {
                userid = Convert.ToDouble(_hRContext.User.Where(x => x.Id == FormData.RelatedUser.Id).Select(x => x.Id).FirstOrDefault());
            }
            if (FormData.Employee.Id == 0)
            {
                var employee = new Employee
                {
                    XStudioIdentityCardFilename = AddFiles(FormData.IdentityCard),
                    XStudioMedicalInsurance1Filename = AddFiles(FormData.MedicalInsurance),
                    XStudioUploadFileFilename = AddFiles(FormData.Documents),
                    XStudioFieldXeed7Filename = AddFiles(FormData.Warningsdeductions),
                    Name = FormData.Employee.Name,
                    UserId = userid,
                    CountryId = FormData.Employee.CountryId,
                    JobTitle=FormData.Employee.JobTitle,
                    Gender = FormData.Employee.Gender,
                    Marital = FormData.Employee.Marital,
                    SpouseCompleteName = FormData.Employee.SpouseCompleteName,
                    SpouseBirthdate = FormData.Employee.SpouseBirthdate,
                    PlaceOfBirth = FormData.Employee.PlaceOfBirth,
                    CountryOfBirth = FormData.Employee.CountryOfBirth,
                    Birthday = FormData.Employee.Birthday,
                    IdentificationId = FormData.Employee.IdentificationId,
                    PassportId = FormData.Employee.PassportId,
                    PermitNo = FormData.Employee.PermitNo,
                    VisaNo = FormData.Employee.VisaNo,
                    VisaExpire = FormData.Employee.VisaExpire,
                    Certificate = FormData.Employee.Certificate,
                    StudyField = FormData.Employee.StudyField,
                    StudySchool = FormData.Employee.StudySchool,
                    EmergencyContact = FormData.Employee.EmergencyContact,
                    EmergencyPhone = FormData.Employee.EmergencyPhone,
                    KmHomeWork = FormData.Employee.KmHomeWork,
                    Barcode = FormData.Employee.Barcode,
                    Pin = FormData.Employee.Pin,
                    DepartmentId = FormData.Departmente?.Id,
                    JobId = FormData.Job?.Id,
                    CompanyId = 1,
                    AddressId = FormData.Address?.Id,
                    WorkPhone = FormData.Employee.WorkPhone,
                    WorkLocation = FormData.Employee.WorkLocation,
                    ResourceId = FormData.Timezone?.Id,
                    ResourceCalendarId = FormData.ResourceCalendar?.Id,
                    ParentId = FormData.Employee.ParentId,
                    CoachId = FormData.Employee.CoachId,
                    CreateDate = DateTime.Now,
                    WriteDate = DateTime.Now,
                    LeaveManagerId = FormData.TimeOff?.Id,
                    ExpenseManagerId = FormData.Expense?.Id,
                    XSpouseBirthdate = FormData.Employee.XSpouseBirthdate,
                    XSpouseCompleteName = FormData.Employee.XSpouseCompleteName
                };

                var emp = employee;

                _hRContext.Employee.Add(employee);
                _hRContext.SaveChanges();
                idforroute = employee.Id;
                var dependents = JsonSerializer.Deserialize<List<Dependent>>(FormData.Dependants);
                foreach (var item in dependents ?? new List<Dependent>())
                {
                    item.EmployeeDependantId = employee.Id;
                    _hRContext.Dependent.Add(item);
                }

                foreach (var item in FormData.TagIds ?? new int[0])
                {
                    _hRContext.Tags.Add(new Tags { EmpId = employee.Id, CategoryId = item });
                }
                if (FormData.ImageEncoded != null)
                {
                    var image = new image { ImageCode = FormData.ImageEncoded.Split(",")[1], EmployeeId = Convert.ToInt32(employee.Id) };
                    _hRContext.Image.Add(image);
                }

                _hRContext.SaveChanges();
            }
            else
            {
                var OldInformationEmployee = _hRContext.Employee.Where(x => x.Id == FormData.Employee.Id).FirstOrDefault();


                string identitycard, warning, document, medical;
                if (FormData.IdentityCard != null)
                {
                    DeleteFiles(OldInformationEmployee.XStudioIdentityCardFilename);
                    identitycard = AddFiles(FormData.IdentityCard);
                    
                }
                else
                {
                    if (String.IsNullOrEmpty(FormData.Employee.XStudioIdentityCardFilename))
                    {
                        identitycard = null;
                    }
                    else
                    {
                        identitycard = OldInformationEmployee.XStudioIdentityCardFilename;
                    }

                }
                if (FormData.Warningsdeductions != null)
                {
                    DeleteFiles(OldInformationEmployee.XStudioFieldXeed7Filename);
                    warning = AddFiles(FormData.Warningsdeductions);

                }
                else
                {
                    if (String.IsNullOrEmpty(FormData.Employee.XStudioFieldXeed7Filename))
                    {
                        warning = null;
                    }
                    else
                    {
                        warning = OldInformationEmployee.XStudioFieldXeed7Filename;
                    }

                }
                if (FormData.Documents != null)
                {
                    DeleteFiles(OldInformationEmployee.XStudioUploadFileFilename);
                    document = AddFiles(FormData.Documents);

                }
                else
                {
                    if (String.IsNullOrEmpty(FormData.Employee.XStudioUploadFileFilename))
                    {
                        document = null;
                    }
                    else
                    {
                        document = OldInformationEmployee.XStudioUploadFileFilename;
                    }

                }
                if (FormData.MedicalInsurance != null)
                {
                    DeleteFiles(OldInformationEmployee.XStudioMedicalInsurance1Filename);
                    medical = AddFiles(FormData.MedicalInsurance);

                }
                else
                {
                    if (String.IsNullOrEmpty(FormData.Employee.XStudioMedicalInsurance1Filename))
                    {
                        medical = null;
                    }
                    else
                    {
                        medical = OldInformationEmployee.XStudioMedicalInsurance1Filename;
                    }

                }

                var Updatedemployee = new Employee
                {
                    Id = FormData.Employee.Id,
                    Name = FormData.Employee.Name,
                    UserId = userid,
                    CountryId = FormData.Employee.CountryId,
                    JobTitle = FormData.Employee.JobTitle,
                    Gender = FormData.Employee.Gender,
                    Marital = FormData.Employee.Marital,
                    SpouseCompleteName = FormData.Employee.SpouseCompleteName,
                    SpouseBirthdate = FormData.Employee.SpouseBirthdate,
                    PlaceOfBirth = FormData.Employee.PlaceOfBirth,
                    CountryOfBirth = FormData.Employee.CountryOfBirth,
                    Birthday = FormData.Employee.Birthday,
                    IdentificationId = FormData.Employee.IdentificationId,
                    PassportId = FormData.Employee.PassportId,
                    PermitNo = FormData.Employee.PermitNo,
                    VisaNo = FormData.Employee.VisaNo,
                    VisaExpire = FormData.Employee.VisaExpire,
                    Certificate = FormData.Employee.Certificate,
                    StudyField = FormData.Employee.StudyField,
                    StudySchool = FormData.Employee.StudySchool,
                    EmergencyContact = FormData.Employee.EmergencyContact,
                    EmergencyPhone = FormData.Employee.EmergencyPhone,
                    KmHomeWork = FormData.Employee.KmHomeWork,
                    Barcode = FormData.Employee.Barcode,
                    Pin = FormData.Employee.Pin,
                    DepartmentId = FormData.Departmente?.Id,
                    JobId = FormData.Job?.Id,
                    CompanyId = 1,
                    AddressId = FormData.Address?.Id,
                    WorkPhone = FormData.Employee.WorkPhone,
                    WorkLocation = FormData.Employee.WorkLocation,
                    ResourceId = FormData.Timezone?.Id,
                    ResourceCalendarId = FormData.ResourceCalendar?.Id,
                    ParentId = FormData.Employee.ParentId,
                    CoachId = FormData.Employee.CoachId,
                    CreateDate = DateTime.Now,
                    WriteDate = DateTime.Now,
                    LeaveManagerId = FormData.TimeOff?.Id,
                    ExpenseManagerId = FormData.Expense?.Id,
                    XSpouseBirthdate = FormData.Employee.XSpouseBirthdate,
                    XSpouseCompleteName = FormData.Employee.XSpouseCompleteName,
                    XStudioMedicalInsurance1Filename=medical,
                   XStudioIdentityCardFilename=identitycard,
                   XStudioFieldXeed7Filename=warning,
                   XStudioUploadFileFilename=document
                };
                var old = _hRContext.Employee.FirstOrDefault(x => x.Id == FormData.Employee.Id);
                _hRContext.Entry(old).State = EntityState.Detached;
                _hRContext.Attach(Updatedemployee);
                _hRContext.Entry(Updatedemployee).State = EntityState.Modified;
                idforroute = Updatedemployee.Id;
                var dependents = JsonSerializer.Deserialize<List<Dependent>>(FormData.Dependants);
                foreach (var item in dependents)
                {
                    if (item.Id == 0)
                    {
                        item.EmployeeDependantId = Updatedemployee.Id;
                        _hRContext.Dependent.Add(item);
                    }
                    else
                    {
                        var child = _hRContext.Dependent.FirstOrDefault(x => x.Id == item.Id);
                        child.Name = item.Name;
                        child.Bdate = item.Bdate;
                        _hRContext.Dependent.Update(child);
                    }
                }
                var OldImage = _hRContext.Image.FirstOrDefault(x => x.EmployeeId == Updatedemployee.Id) ?? new image();
                if (OldImage.Id != 0)
                {
                    if (FormData.ImageEncoded != null)
                    {
                        OldImage.ImageCode = FormData.ImageEncoded.Split(",")[1];
                        _hRContext.Image.Update(OldImage);
                    }
                    else
                    {
                        _hRContext.Image.Remove(OldImage);

                    }
                }
                else
                {
                    if (FormData.ImageEncoded != null)
                    {
                        var image = new image { ImageCode = FormData.ImageEncoded.Split(",")[1], EmployeeId = Convert.ToInt32(Updatedemployee.Id) };
                        _hRContext.Image.Add(image);
                    }
                }

                var Tags = _hRContext.Tags.Where(x => x.EmpId == FormData.Employee.Id).ToList<Tags>();
                foreach (var item in Tags ?? new List<Tags>())
                {
                    _hRContext.Tags.Remove(item);
                }

                foreach (var item in FormData.TagIds ?? new int[0])
                {
                    _hRContext.Tags.Add(new Tags { EmpId = Updatedemployee.Id, CategoryId = item });
                }

                _hRContext.SaveChanges();
            }

            return RedirectToAction(nameof(Details), new { id = idforroute });
        }

        public string AddFiles(IFormFile file)
        {
            int count = 1;
            if (file != null)
            {

                //Set Key Name
                string FileName = file.FileName.Split(".")[0];
                string FileExtension = file.FileName.Split(".")[1];

                //Get url To Save
                string SavePath = Path.Combine(_env.WebRootPath + "/Files", FileName + "." + FileExtension);
                string NewFileName = FileName + "." + FileExtension;
                while (System.IO.File.Exists(SavePath))
                {
                    NewFileName = string.Format("{0}({1})", FileName, count++);
                    SavePath = Path.Combine(_env.WebRootPath + "/Files", NewFileName + "." + FileExtension);
                    NewFileName += "." + FileExtension;
                }

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {

                    file.CopyTo(stream);
                }
                return NewFileName;
            }
            return null;
        }
        public void DeleteFiles(string file)
        {
            if (file != null)
            {
                try
                {
                    var SavePath = Path.Combine(_env.WebRootPath, "/Files", file);
                    System.IO.File.Delete(SavePath);
                }
                catch (Exception)
                {

                }

            }
        }
        public IActionResult DeleteEmployee(int id)
        {
            var deletedEmployee = _hRContext.Employee.Where(x => x.Id == id).FirstOrDefault() ?? new Employee() ;

            DeleteFiles(deletedEmployee.XStudioFieldXeed7Filename);
            DeleteFiles(deletedEmployee.XStudioIdentityCardFilename);
            DeleteFiles(deletedEmployee.XStudioMedicalInsurance1Filename);
            DeleteFiles(deletedEmployee.XStudioUploadFileFilename);
            var oldimage = _hRContext.Image.FirstOrDefault(x => x.EmployeeId == id);
            if (oldimage != null)
            {
            _hRContext.Image.Remove(oldimage);
            }

            var olddependant = _hRContext.Dependent.Where(x => x.EmployeeDependantId == id).ToList();
            foreach (var item in olddependant?? new List<Dependent>())
            {
                _hRContext.Remove(item);
            }
            _hRContext.Employee.Remove(deletedEmployee);
            _hRContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
