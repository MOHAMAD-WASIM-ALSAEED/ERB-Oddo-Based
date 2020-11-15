using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace oddo.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string MessageMainAttachmentId { get; set; }
        public string Name { get; set; }
        public string CompleteName { get; set; }
        public string Active { get; set; }
        public double? CompanyId { get; set; }
        public double? ParentId { get; set; }
        public double? ManagerId { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
        [NotMapped]
        public int parentcount { get; set; }
        [NotMapped]
        public int RouteLength { get; set; }
    }
}
