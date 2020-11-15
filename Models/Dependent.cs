using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.Models
{
    public class Dependent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Bdate { get; set; }
        public double? EmployeeDependantId { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
        [NotMapped]
        public string Type { set; get; }


    }
}
