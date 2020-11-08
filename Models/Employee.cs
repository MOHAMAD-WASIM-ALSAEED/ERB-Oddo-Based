using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace oddo.Models
{
    public partial class Employee
    {
        public double? Id { get; set; }
        public string Name { get; set; }
        public double? UserId { get; set; }
        public string Active { get; set; }
        public string AddressHomeId { get; set; }
        public double? CountryId { get; set; }
        public string Gender { get; set; }
        public string Marital { get; set; }
        public string SpouseCompleteName { get; set; }
        public DateTime? SpouseBirthdate { get; set; }
        public double? Children { get; set; }
        public string PlaceOfBirth { get; set; }
        public double? CountryOfBirth { get; set; }
        public DateTime? Birthday { get; set; }
        public string Ssnid { get; set; }
        public string Sinid { get; set; }
        public double? IdentificationId { get; set; }
        public string PassportId { get; set; }
        public string BankAccountId { get; set; }
        public string PermitNo { get; set; }
        public string VisaNo { get; set; }
        public string VisaExpire { get; set; }
        public string AdditionalNote { get; set; }
        public string Certificate { get; set; }
        public string StudyField { get; set; }
        public string StudySchool { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public double? KmHomeWork { get; set; }
        public string Notes { get; set; }
        public double? Color { get; set; }
        public double? Barcode { get; set; }
        public double? Pin { get; set; }
        public string DepartureReason { get; set; }
        public string DepartureDescription { get; set; }
        public string MessageMainAttachmentId { get; set; }
        public double? DepartmentId { get; set; }
        public double? JobId { get; set; }
        public string JobTitle { get; set; }
        public double? CompanyId { get; set; }
        public double? AddressId { get; set; }
        public string WorkPhone { get; set; }
        public double? MobilePhone { get; set; }
        public string WorkEmail { get; set; }
        public string WorkLocation { get; set; }
        public double? ResourceId { get; set; }
        public double? ResourceCalendarId { get; set; }
        public double? ParentId { get; set; }
        public double? CoachId { get; set; }
        public double? CreateUid { get; set; }
        public DateTime? CreateDate { get; set; }
        public double? WriteUid { get; set; }
        public DateTime? WriteDate { get; set; }
        public string MedicExam { get; set; }
        public string Vehicle { get; set; }
        public double? ContractId { get; set; }
        public string ContractWarning { get; set; }
        public double? LeaveManagerId { get; set; }
        public string RegistrationNumber { get; set; }
        public double? LastAttendanceId { get; set; }
        public DateTime? LastCheckIn { get; set; }
        public DateTime? LastCheckOut { get; set; }
        public double? ExpenseManagerId { get; set; }
        public string EmailSent { get; set; }
        public string IpConnected { get; set; }
        public string ManuallySetPresent { get; set; }
        public string HrPresenceStateDisplay { get; set; }
        public string XStudioIdentityCardFilename { get; set; }
        public string XStudioUploadFileFilename { get; set; }
        public string XStudioFieldXeed7Filename { get; set; }
        public string XStudioIdCardCopyFilename { get; set; }
        public string XStudioMedicalInsurance1Filename { get; set; }
        public double? TimesheetCost { get; set; }
        public string TimesheetValidated { get; set; }
        public string TimesheetManagerId { get; set; }
        public string XSpouseCompleteName { get; set; }
        public string XSpouseBirthdate { get; set; }
        [NotMapped]
        public Jobs Job { get; set; }
    }
}
