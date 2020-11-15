using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace oddo.Models
{
    public partial class odooHrContext : DbContext
    {
        private IConfiguration _configuration;
       
        public odooHrContext(DbContextOptions<odooHrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<ResPartner> ResPartner { get; set; }
        public virtual DbSet<ResourceCalendar> ResourceCalendar { get; set; }
        public virtual DbSet<TagValue> TagValue { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
          public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Dependent> Dependent { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<image> Image { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressFormat)
                    .HasMaxLength(255)
                    .HasColumnName("address_format");

                entity.Property(e => e.AddressViewId)
                    .HasMaxLength(255)
                    .HasColumnName("address_view_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NamePosition)
                    .HasMaxLength(255)
                    .HasColumnName("name_position");

                entity.Property(e => e.PhoneCode).HasColumnName("phone_code");

                entity.Property(e => e.VatLabel)
                    .HasMaxLength(255)
                    .HasColumnName("vat_label");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(255)
                    .HasColumnName("active");

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .HasColumnName("color");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompleteName)
                    .HasMaxLength(255)
                    .HasColumnName("complete_name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasMaxLength(255)
                    .HasColumnName("message_main_attachment_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.ToTable("dependent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bdate)
                    .HasColumnType("datetime")
                    .HasColumnName("bdate");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.EmployeeDependantId).HasColumnName("employee_dependant_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(255)
                    .HasColumnName("active");

                entity.Property(e => e.AdditionalNote)
                    .HasMaxLength(255)
                    .HasColumnName("additional_note");

                entity.Property(e => e.AddressHomeId)
                    .HasMaxLength(255)
                    .HasColumnName("address_home_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BankAccountId)
                    .HasMaxLength(255)
                    .HasColumnName("bank_account_id");

                entity.Property(e => e.Barcode).HasColumnName("barcode");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Certificate)
                    .HasMaxLength(255)
                    .HasColumnName("certificate");

                entity.Property(e => e.Children).HasColumnName("children");

                entity.Property(e => e.CoachId).HasColumnName("coach_id");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.ContractWarning)
                    .HasMaxLength(255)
                    .HasColumnName("contract_warning");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryOfBirth).HasColumnName("country_of_birth");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartureDescription)
                    .HasMaxLength(255)
                    .HasColumnName("departure_description");

                entity.Property(e => e.DepartureReason)
                    .HasMaxLength(255)
                    .HasColumnName("departure_reason");

                entity.Property(e => e.EmailSent)
                    .HasMaxLength(255)
                    .HasColumnName("email_sent");

                entity.Property(e => e.EmergencyContact)
                    .HasMaxLength(255)
                    .HasColumnName("emergency_contact");

                entity.Property(e => e.EmergencyPhone)
                    .HasMaxLength(255)
                    .HasColumnName("emergency_phone");

                entity.Property(e => e.ExpenseManagerId).HasColumnName("expense_manager_id");

                entity.Property(e => e.Gender)
                    .HasMaxLength(255)
                    .HasColumnName("gender");

                entity.Property(e => e.HrPresenceStateDisplay)
                    .HasMaxLength(255)
                    .HasColumnName("hr_presence_state_display");

                entity.Property(e => e.IdentificationId).HasColumnName("identification_id");

                entity.Property(e => e.IpConnected)
                    .HasMaxLength(255)
                    .HasColumnName("ip_connected");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .HasColumnName("job_title");

                entity.Property(e => e.KmHomeWork).HasColumnName("km_home_work");

                entity.Property(e => e.LastAttendanceId).HasColumnName("last_attendance_id");

                entity.Property(e => e.LastCheckIn)
                    .HasColumnType("datetime")
                    .HasColumnName("last_check_in");

                entity.Property(e => e.LastCheckOut)
                    .HasColumnType("datetime")
                    .HasColumnName("last_check_out");

                entity.Property(e => e.LeaveManagerId).HasColumnName("leave_manager_id");

                entity.Property(e => e.ManuallySetPresent)
                    .HasMaxLength(255)
                    .HasColumnName("manually_set_present");

                entity.Property(e => e.Marital)
                    .HasMaxLength(255)
                    .HasColumnName("marital");

                entity.Property(e => e.MedicExam)
                    .HasMaxLength(255)
                    .HasColumnName("medic_exam");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasMaxLength(255)
                    .HasColumnName("message_main_attachment_id");

                entity.Property(e => e.MobilePhone).HasColumnName("mobile_phone");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PassportId)
                    .HasMaxLength(255)
                    .HasColumnName("passport_id");

                entity.Property(e => e.PermitNo)
                    .HasMaxLength(255)
                    .HasColumnName("permit_no");

                entity.Property(e => e.Pin).HasColumnName("pin");

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(255)
                    .HasColumnName("place_of_birth");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(255)
                    .HasColumnName("registration_number");

                entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");

                entity.Property(e => e.ResourceId).HasColumnName("resource_id");

                entity.Property(e => e.Sinid)
                    .HasMaxLength(255)
                    .HasColumnName("sinid");

                entity.Property(e => e.SpouseBirthdate)
                    .HasColumnType("datetime")
                    .HasColumnName("spouse_birthdate");

                entity.Property(e => e.SpouseCompleteName)
                    .HasMaxLength(255)
                    .HasColumnName("spouse_complete_name");

                entity.Property(e => e.Ssnid)
                    .HasMaxLength(255)
                    .HasColumnName("ssnid");

                entity.Property(e => e.StudyField)
                    .HasMaxLength(255)
                    .HasColumnName("study_field");

                entity.Property(e => e.StudySchool)
                    .HasMaxLength(255)
                    .HasColumnName("study_school");

                entity.Property(e => e.TimesheetCost).HasColumnName("timesheet_cost");

                entity.Property(e => e.TimesheetManagerId)
                    .HasMaxLength(255)
                    .HasColumnName("timesheet_manager_id");

                entity.Property(e => e.TimesheetValidated)
                    .HasMaxLength(255)
                    .HasColumnName("timesheet_validated");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Vehicle)
                    .HasMaxLength(255)
                    .HasColumnName("vehicle");

                entity.Property(e => e.VisaExpire)
                    .HasMaxLength(255)
                    .HasColumnName("visa_expire");

                entity.Property(e => e.VisaNo)
                    .HasMaxLength(255)
                    .HasColumnName("visa_no");

                entity.Property(e => e.WorkEmail)
                    .HasMaxLength(255)
                    .HasColumnName("work_email");

                entity.Property(e => e.WorkLocation)
                    .HasMaxLength(255)
                    .HasColumnName("work_location");

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(255)
                    .HasColumnName("work_phone");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");

                entity.Property(e => e.XSpouseBirthdate)
                    .HasMaxLength(255)
                    .HasColumnName("x_spouse_birthdate");

                entity.Property(e => e.XSpouseCompleteName)
                    .HasMaxLength(255)
                    .HasColumnName("x_spouse_complete_name");

                entity.Property(e => e.XStudioFieldXeed7Filename)
                    .HasMaxLength(255)
                    .HasColumnName("x_studio_field_XEED7_filename");

                entity.Property(e => e.XStudioIdCardCopyFilename)
                    .HasMaxLength(255)
                    .HasColumnName("x_studio_id_card_copy_filename");

                entity.Property(e => e.XStudioIdentityCardFilename)
                    .HasMaxLength(255)
                    .HasColumnName("x_studio_identity_card_filename");

                entity.Property(e => e.XStudioMedicalInsurance1Filename)
                    .HasMaxLength(255)
                    .HasColumnName("x_studio_medical_insurance_1_filename");

                entity.Property(e => e.XStudioUploadFileFilename)
                    .HasMaxLength(255)
                    .HasColumnName("x_studio_upload_file_filename");
            });

            modelBuilder.Entity<image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.ImageCode)
                    .IsUnicode(false)
                    .HasColumnName("image_code");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(255)
                    .HasColumnName("department_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ExpectedEmployees).HasColumnName("expected_employees");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasMaxLength(255)
                    .HasColumnName("message_main_attachment_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NoOfEmployee).HasColumnName("no_of_employee");

                entity.Property(e => e.NoOfHiredEmployee)
                    .HasMaxLength(255)
                    .HasColumnName("no_of_hired_employee");

                entity.Property(e => e.NoOfRecruitment).HasColumnName("no_of_recruitment");

                entity.Property(e => e.Requirements)
                    .HasMaxLength(255)
                    .HasColumnName("requirements");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<ResPartner>(entity =>
            {
                entity.ToTable("ResPartner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(255)
                    .HasColumnName("active");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(255)
                    .HasColumnName("additional_info");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(255)
                    .HasColumnName("barcode");

                entity.Property(e => e.CalendarLastNotifAck)
                    .HasColumnType("datetime")
                    .HasColumnName("calendar_last_notif_ack");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");

                entity.Property(e => e.CommercialCompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("commercial_company_name");

                entity.Property(e => e.CommercialPartnerId).HasColumnName("commercial_partner_id");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(255)
                    .HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactAddressComplete)
                    .HasMaxLength(255)
                    .HasColumnName("contact_address_complete");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(255)
                    .HasColumnName("country_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.CreditLimit).HasColumnName("credit_limit");

                entity.Property(e => e.CustomerRank).HasColumnName("customer_rank");

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .HasColumnName("date");

                entity.Property(e => e.DebitLimit).HasColumnName("debit_limit");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("display_name");

                entity.Property(e => e.DuplicateHave)
                    .HasMaxLength(255)
                    .HasColumnName("duplicate_have");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EmailNormalized)
                    .HasMaxLength(255)
                    .HasColumnName("email_normalized");

                entity.Property(e => e.Employee)
                    .HasMaxLength(255)
                    .HasColumnName("employee");

                entity.Property(e => e.Function)
                    .HasMaxLength(255)
                    .HasColumnName("function");

                entity.Property(e => e.IndustryId)
                    .HasMaxLength(255)
                    .HasColumnName("industry_id");

                entity.Property(e => e.InvoiceWarn)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_warn");

                entity.Property(e => e.InvoiceWarnMsg)
                    .HasMaxLength(255)
                    .HasColumnName("invoice_warn_msg");

                entity.Property(e => e.IsCompany)
                    .HasMaxLength(255)
                    .HasColumnName("is_company");

                entity.Property(e => e.Lang)
                    .HasMaxLength(255)
                    .HasColumnName("lang");

                entity.Property(e => e.LastTimeEntriesChecked)
                    .HasMaxLength(255)
                    .HasColumnName("last_time_entries_checked");

                entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasMaxLength(255)
                    .HasColumnName("message_main_attachment_id");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(255)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.OnlinePartnerBankAccount)
                    .HasMaxLength(255)
                    .HasColumnName("online_partner_bank_account");

                entity.Property(e => e.OnlinePartnerVendorName)
                    .HasMaxLength(255)
                    .HasColumnName("online_partner_vendor_name");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");

                entity.Property(e => e.PartnerLatitude).HasColumnName("partner_latitude");

                entity.Property(e => e.PartnerLongitude).HasColumnName("partner_longitude");

                entity.Property(e => e.PartnerShare)
                    .HasMaxLength(255)
                    .HasColumnName("partner_share");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.PhoneSanitized)
                    .HasMaxLength(255)
                    .HasColumnName("phone_sanitized");

                entity.Property(e => e.PickingWarn)
                    .HasMaxLength(255)
                    .HasColumnName("picking_warn");

                entity.Property(e => e.PickingWarnMsg)
                    .HasMaxLength(255)
                    .HasColumnName("picking_warn_msg");

                entity.Property(e => e.PurchaseWarn)
                    .HasMaxLength(255)
                    .HasColumnName("purchase_warn");

                entity.Property(e => e.PurchaseWarnMsg)
                    .HasMaxLength(255)
                    .HasColumnName("purchase_warn_msg");

                entity.Property(e => e.Ref)
                    .HasMaxLength(255)
                    .HasColumnName("ref");

                entity.Property(e => e.SaleWarn)
                    .HasMaxLength(255)
                    .HasColumnName("sale_warn");

                entity.Property(e => e.SaleWarnMsg)
                    .HasMaxLength(255)
                    .HasColumnName("sale_warn_msg");

                entity.Property(e => e.SignupExpiration)
                    .HasColumnType("datetime")
                    .HasColumnName("signup_expiration");

                entity.Property(e => e.SignupToken)
                    .HasMaxLength(255)
                    .HasColumnName("signup_token");

                entity.Property(e => e.SignupType)
                    .HasMaxLength(255)
                    .HasColumnName("signup_type");

                entity.Property(e => e.StateId)
                    .HasMaxLength(255)
                    .HasColumnName("state_id");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Street2)
                    .HasMaxLength(255)
                    .HasColumnName("street2");

                entity.Property(e => e.SupplierRank).HasColumnName("supplier_rank");

                entity.Property(e => e.TeamId)
                    .HasMaxLength(255)
                    .HasColumnName("team_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.Tz)
                    .HasMaxLength(255)
                    .HasColumnName("tz");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");

                entity.Property(e => e.Vat)
                    .HasMaxLength(255)
                    .HasColumnName("vat");

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .HasColumnName("website");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");

                entity.Property(e => e.XArabicName)
                    .HasMaxLength(255)
                    .HasColumnName("x_arabic_name");

                entity.Property(e => e.XCode)
                    .HasMaxLength(255)
                    .HasColumnName("x_code");

                entity.Property(e => e.Zip)
                    .HasMaxLength(255)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Resources>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(255)
                    .HasColumnName("active");

                entity.Property(e => e.CalendarId).HasColumnName("calendar_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.ResourceType)
                    .HasMaxLength(255)
                    .HasColumnName("resource_type");

                entity.Property(e => e.TimeEfficiency).HasColumnName("time_efficiency");

                entity.Property(e => e.Tz)
                    .HasMaxLength(255)
                    .HasColumnName("tz");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<ResourceCalendar>(entity =>
            {
                entity.ToTable("ResourceCalendar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.FullTimeRequiredHours).HasColumnName("full_time_required_hours");

                entity.Property(e => e.HoursPerDay).HasColumnName("hours_per_day");

                entity.Property(e => e.HoursPerWeek).HasColumnName("hours_per_week");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.TwoWeeksCalendar)
                    .HasMaxLength(255)
                    .HasColumnName("two_weeks_calendar");

                entity.Property(e => e.Tz)
                    .HasMaxLength(255)
                    .HasColumnName("tz");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");
            });

            modelBuilder.Entity<TagValue>(entity =>
            {
                entity.ToTable("TagValue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Column1).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e._1).HasMaxLength(255);

                entity.Property(e => e._2).HasMaxLength(255);

                entity.Property(e => e._3).HasMaxLength(255);

                entity.Property(e => e._4).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.ActionId)
                    .HasMaxLength(255)
                    .HasColumnName("action_id");

                entity.Property(e => e.Active)
                    .HasMaxLength(255)
                    .HasColumnName("active");

                entity.Property(e => e.AliasId)
                    .HasMaxLength(255)
                    .HasColumnName("alias_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.Login)
                    .HasMaxLength(255)
                    .HasColumnName("login");

                entity.Property(e => e.NotificationType)
                    .HasMaxLength(255)
                    .HasColumnName("notification_type");

                entity.Property(e => e.OdoobotState)
                    .HasMaxLength(255)
                    .HasColumnName("odoobot_state");

                entity.Property(e => e.OutOfOfficeMessage)
                    .HasMaxLength(255)
                    .HasColumnName("out_of_office_message");

                entity.Property(e => e.PartnerId)
                    .HasMaxLength(255)
                    .HasColumnName("partner_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.SaleTeamId)
                    .HasMaxLength(255)
                    .HasColumnName("sale_team_id");

                entity.Property(e => e.Share)
                    .HasMaxLength(255)
                    .HasColumnName("share");

                entity.Property(e => e.Signature)
                    .HasMaxLength(255)
                    .HasColumnName("signature");

                entity.Property(e => e.TargetSalesDone)
                    .HasMaxLength(255)
                    .HasColumnName("target_sales_done");

                entity.Property(e => e.TargetSalesInvoiced)
                    .HasMaxLength(255)
                    .HasColumnName("target_sales_invoiced");

                entity.Property(e => e.TargetSalesWon)
                    .HasMaxLength(255)
                    .HasColumnName("target_sales_won");

                entity.Property(e => e.WriteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("write_date");

                entity.Property(e => e.WriteUid)
                    .HasMaxLength(255)
                    .HasColumnName("write_uid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
