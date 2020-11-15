using System;
using System.Collections.Generic;

namespace oddo.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Active { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double? CompanyId { get; set; }
        public string PartnerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Signature { get; set; }
        public string ActionId { get; set; }
        public string Share { get; set; }
        public double? CreateUid { get; set; }
        public string WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
        public string AliasId { get; set; }
        public string NotificationType { get; set; }
        public string OutOfOfficeMessage { get; set; }
        public string SaleTeamId { get; set; }
        public string TargetSalesWon { get; set; }
        public string OdoobotState { get; set; }
        public string TargetSalesDone { get; set; }
        public string TargetSalesInvoiced { get; set; }
    }
}
