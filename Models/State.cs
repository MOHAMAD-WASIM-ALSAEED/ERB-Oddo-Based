using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.Models
{
    public class State
    {
        public int Id { get; set; }
        public double? CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }


    }
}
