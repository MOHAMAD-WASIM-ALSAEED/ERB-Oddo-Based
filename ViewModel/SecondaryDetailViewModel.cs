using oddo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.ViewModel
{
    public class SecondaryDetailViewModel
    {
        public ResPartner User { get; set; }
        public List<Employee> BreadCrumbsEmployees { get; set; }

    }
}
