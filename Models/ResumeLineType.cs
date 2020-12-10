using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace oddo.Models
{
    public partial class ResumeLineType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sequence { get; set; }
        public string CreateUid { get; set; }
        public string CreateDate { get; set; }
        public string WriteUid { get; set; }
        public string WriteDate { get; set; }
        [NotMapped]
        public int childcount { get; set; }
    }
}
