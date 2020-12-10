using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string SkillId { get; set; }
        public string SkillLevelId { get; set; }
        public string SkillTypeId { get; set; }
        public string CreateUid { get; set; }
        public string CreateDate { get; set; }
        public string WriteUid { get; set; }
        public string WriteDate { get; set; }
    }
}
