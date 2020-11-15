using System;
using System.Collections.Generic;

namespace oddo.Models
{
    public partial class Jobs
    {
        public int Id { get; set; }
        public string MessageMainAttachmentId { get; set; }
        public string Name { get; set; }
        public double? ExpectedEmployees { get; set; }
        public double? NoOfEmployee { get; set; }
        public double? NoOfRecruitment { get; set; }
        public string NoOfHiredEmployee { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string DepartmentId { get; set; }
        public double? CompanyId { get; set; }
        public string State { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
    }
}
