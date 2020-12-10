using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.Models
{
    public class Resume
    {

        public int Id { get; set; }
        public double? EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Description { get; set; }
        public double? LineTypeId { get; set; }
        public string DisplayType { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
    }
}
