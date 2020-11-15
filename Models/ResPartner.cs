using System;
using System.Collections.Generic;

namespace oddo.Models
{
    public partial class ResPartner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string DisplayName { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public double? ParentId { get; set; }
        public string Ref { get; set; }
        public string Lang { get; set; }
        public string Tz { get; set; }
        public string UserId { get; set; }
        public string Vat { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public double? CreditLimit { get; set; }
        public string Active { get; set; }
        public string Employee { get; set; }
        public string Function { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
        public double? PartnerLatitude { get; set; }
        public double? PartnerLongitude { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string IsCompany { get; set; }
        public string IndustryId { get; set; }
        public double? Color { get; set; }
        public string PartnerShare { get; set; }
        public double? CommercialPartnerId { get; set; }
        public string CommercialCompanyName { get; set; }
        public string CompanyName { get; set; }
        public double? CreateUid { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
        public string MessageMainAttachmentId { get; set; }
        public string EmailNormalized { get; set; }
        public double? MessageBounce { get; set; }
        public string ContactAddressComplete { get; set; }
        public string SignupToken { get; set; }
        public string SignupType { get; set; }
        public DateTime? SignupExpiration { get; set; }
        public DateTime? CalendarLastNotifAck { get; set; }
        public double? PartnerGid { get; set; }
        public string AdditionalInfo { get; set; }
        public string TeamId { get; set; }
        public string PhoneSanitized { get; set; }
        public string PickingWarn { get; set; }
        public string PickingWarnMsg { get; set; }
        public double? DebitLimit { get; set; }
        public string LastTimeEntriesChecked { get; set; }
        public string InvoiceWarn { get; set; }
        public string InvoiceWarnMsg { get; set; }
        public double? SupplierRank { get; set; }
        public double? CustomerRank { get; set; }
        public string OnlinePartnerVendorName { get; set; }
        public string OnlinePartnerBankAccount { get; set; }
        public string DuplicateHave { get; set; }
        public string XCode { get; set; }
        public string XArabicName { get; set; }
        public string SaleWarn { get; set; }
        public string SaleWarnMsg { get; set; }
        public string Barcode { get; set; }
        public string PurchaseWarn { get; set; }
        public string PurchaseWarnMsg { get; set; }
    }
}
