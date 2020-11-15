using System;
using System.Collections.Generic;

namespace oddo.Models
{
    public partial class ResourceCalendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? CompanyId { get; set; }
        public double? HoursPerDay { get; set; }
        public string Tz { get; set; }
        public string TwoWeeksCalendar { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
        public double? HoursPerWeek { get; set; }
        public double? FullTimeRequiredHours { get; set; }
    }
}
