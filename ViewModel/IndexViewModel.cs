using oddo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.ViewModel
{
    public class IndexViewModel
    {
        public Employee employee { get; set; }
        public List<TagValue> tags { get; set; }
        public Jobs Job { get; set; }
    }
}
