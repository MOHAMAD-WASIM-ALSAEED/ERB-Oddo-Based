using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oddo.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AddressFormat { get; set; }
        public string AddressViewId { get; set; }
        public double? CurrencyId { get; set; }
        public double? PhoneCode { get; set; }
        public string NamePosition { get; set; }
        public string VatLabel { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }


    }
}
