using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.Models
{
    public class Resources
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public double? CompanyId { get; set; }
        public string ResourceType { get; set; }
        public double? UserId { get; set; }
        public double? TimeEfficiency { get; set; }
        public double? CalendarId { get; set; }
        public string Tz { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }



    }
}
