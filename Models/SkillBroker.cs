using System;
using System.Collections.Generic;

#nullable disable

namespace oddo.Models
{
    public partial class SkillBroker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SkillTypeId { get; set; }
        public string CreateUid { get; set; }
        public string CreateDate { get; set; }
        public string WriteUid { get; set; }
        public string WriteDate { get; set; }
    }
}
