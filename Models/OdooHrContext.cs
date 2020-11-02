using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace oddo.Models
{
    public partial class odooHrContext : DbContext
    {
        public odooHrContext()
        {
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=89.189.232.108\\projects;Database=OdooHr;User Id=tfssqladmin;Password=P@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(255);

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompleteName)
                    .HasColumnName("complete_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasColumnName("message_main_attachment_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });
            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dependent");

                entity.Property(e => e.Bdate)
                    .HasColumnName("bdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.EmployeeDependantId).HasColumnName("employee_dependant_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(255);

                entity.Property(e => e.AdditionalNote)
                    .HasColumnName("additional_note")
                    .HasMaxLength(255);

                entity.Property(e => e.AddressHomeId).HasColumnName("address_home_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.BankAccountId)
                    .HasColumnName("bank_account_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Barcode).HasColumnName("barcode");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.Certificate)
                    .HasColumnName("certificate")
                    .HasMaxLength(255);

                entity.Property(e => e.Children).HasColumnName("children");

                entity.Property(e => e.CoachId).HasColumnName("coach_id");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.ContractWarning)
                    .HasColumnName("contract_warning")
                    .HasMaxLength(255);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryOfBirth)
                    .HasColumnName("country_of_birth")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartureDescription)
                    .HasColumnName("departure_description")
                    .HasMaxLength(255);

                entity.Property(e => e.DepartureReason)
                    .HasColumnName("departure_reason")
                    .HasMaxLength(255);

                entity.Property(e => e.EmailSent)
                    .HasColumnName("email_sent")
                    .HasMaxLength(255);

                entity.Property(e => e.EmergencyContact)
                    .HasColumnName("emergency_contact")
                    .HasMaxLength(255);

                entity.Property(e => e.EmergencyPhone)
                    .HasColumnName("emergency_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpenseManagerId)
                    .HasColumnName("expense_manager_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(255);

                entity.Property(e => e.HrPresenceStateDisplay)
                    .HasColumnName("hr_presence_state_display")
                    .HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdentificationId).HasColumnName("identification_id");

                entity.Property(e => e.IpConnected)
                    .HasColumnName("ip_connected")
                    .HasMaxLength(255);

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasMaxLength(255);

                entity.Property(e => e.KmHomeWork).HasColumnName("km_home_work");

                entity.Property(e => e.LastAttendanceId).HasColumnName("last_attendance_id");

                entity.Property(e => e.LastCheckIn)
                    .HasColumnName("last_check_in")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastCheckOut)
                    .HasColumnName("last_check_out")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeaveManagerId).HasColumnName("leave_manager_id");

                entity.Property(e => e.ManuallySetPresent)
                    .HasColumnName("manually_set_present")
                    .HasMaxLength(255);

                entity.Property(e => e.Marital)
                    .HasColumnName("marital")
                    .HasMaxLength(255);

                entity.Property(e => e.MedicExam)
                    .HasColumnName("medic_exam")
                    .HasMaxLength(255);

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasColumnName("message_main_attachment_id")
                    .HasMaxLength(255);

                entity.Property(e => e.MobilePhone).HasColumnName("mobile_phone");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PassportId)
                    .HasColumnName("passport_id")
                    .HasMaxLength(255);

                entity.Property(e => e.PermitNo)
                    .HasColumnName("permit_no")
                    .HasMaxLength(255);

                entity.Property(e => e.Pin).HasColumnName("pin");

                entity.Property(e => e.PlaceOfBirth)
                    .HasColumnName("place_of_birth")
                    .HasMaxLength(255);

                entity.Property(e => e.RegistrationNumber)
                    .HasColumnName("registration_number")
                    .HasMaxLength(255);

                entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");

                entity.Property(e => e.ResourceId).HasColumnName("resource_id");

                entity.Property(e => e.Sinid)
                    .HasColumnName("sinid")
                    .HasMaxLength(255);

                entity.Property(e => e.SpouseBirthdate)
                    .HasColumnName("spouse_birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpouseCompleteName)
                    .HasColumnName("spouse_complete_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Ssnid)
                    .HasColumnName("ssnid")
                    .HasMaxLength(255);

                entity.Property(e => e.StudyField)
                    .HasColumnName("study_field")
                    .HasMaxLength(255);

                entity.Property(e => e.StudySchool)
                    .HasColumnName("study_school")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Vehicle)
                    .HasColumnName("vehicle")
                    .HasMaxLength(255);

                entity.Property(e => e.VisaExpire)
                    .HasColumnName("visa_expire")
                    .HasMaxLength(255);

                entity.Property(e => e.VisaNo)
                    .HasColumnName("visa_no")
                    .HasMaxLength(255);

                entity.Property(e => e.WorkEmail)
                    .HasColumnName("work_email")
                    .HasMaxLength(255);

                entity.Property(e => e.WorkLocation)
                    .HasColumnName("work_location")
                    .HasMaxLength(255);

                entity.Property(e => e.WorkPhone)
                    .HasColumnName("work_phone")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");

                entity.Property(e => e.XStudioFieldXeed7Filename)
                    .HasColumnName("x_studio_field_XEED7_filename")
                    .HasMaxLength(255);

                entity.Property(e => e.XStudioIdCardCopyFilename)
                    .HasColumnName("x_studio_id_card_copy_filename")
                    .HasMaxLength(255);

                entity.Property(e => e.XStudioIdentityCardFilename)
                    .HasColumnName("x_studio_identity_card_filename")
                    .HasMaxLength(255);

                entity.Property(e => e.XStudioMedicalInsurance1Filename)
                    .HasColumnName("x_studio_medical_insurance_1_filename")
                    .HasMaxLength(255);

                entity.Property(e => e.XStudioUploadFileFilename)
                    .HasColumnName("x_studio_upload_file_filename")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("jobs");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.ExpectedEmployees).HasColumnName("expected_employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasColumnName("message_main_attachment_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NoOfEmployee).HasColumnName("no_of_employee");

                entity.Property(e => e.NoOfHiredEmployee).HasColumnName("no_of_hired_employee");

                entity.Property(e => e.NoOfRecruitment).HasColumnName("no_of_recruitment");

                entity.Property(e => e.Requirements)
                    .HasColumnName("requirements")
                    .HasMaxLength(255);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<ResPartner>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(255);

                entity.Property(e => e.AdditionalInfo)
                    .HasColumnName("additional_info")
                    .HasMaxLength(255);

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(255);

                entity.Property(e => e.CalendarLastNotifAck)
                    .HasColumnName("calendar_last_notif_ack")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(255);

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255);

                entity.Property(e => e.CommercialCompanyName)
                    .HasColumnName("commercial_company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.CommercialPartnerId).HasColumnName("commercial_partner_id");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ContactAddressComplete)
                    .HasColumnName("contact_address_complete")
                    .HasMaxLength(255);

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.CreditLimit).HasColumnName("credit_limit");

                entity.Property(e => e.CustomerRank).HasColumnName("customer_rank");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(255);

                entity.Property(e => e.DebitLimit).HasColumnName("debit_limit");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("display_name")
                    .HasMaxLength(255);

                entity.Property(e => e.DuplicateHave)
                    .HasColumnName("duplicate_have")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.EmailNormalized)
                    .HasColumnName("email_normalized")
                    .HasMaxLength(255);

                entity.Property(e => e.Employee)
                    .HasColumnName("employee")
                    .HasMaxLength(255);

                entity.Property(e => e.Function)
                    .HasColumnName("function")
                    .HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IndustryId)
                    .HasColumnName("industry_id")
                    .HasMaxLength(255);

                entity.Property(e => e.InvoiceWarn)
                    .HasColumnName("invoice_warn")
                    .HasMaxLength(255);

                entity.Property(e => e.InvoiceWarnMsg)
                    .HasColumnName("invoice_warn_msg")
                    .HasMaxLength(255);

                entity.Property(e => e.IsCompany)
                    .HasColumnName("is_company")
                    .HasMaxLength(255);

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasMaxLength(255);

                entity.Property(e => e.LastTimeEntriesChecked)
                    .HasColumnName("last_time_entries_checked")
                    .HasMaxLength(255);

                entity.Property(e => e.MessageBounce).HasColumnName("message_bounce");

                entity.Property(e => e.MessageMainAttachmentId)
                    .HasColumnName("message_main_attachment_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.OnlinePartnerBankAccount)
                    .HasColumnName("online_partner_bank_account")
                    .HasMaxLength(255);

                entity.Property(e => e.OnlinePartnerVendorName)
                    .HasColumnName("online_partner_vendor_name")
                    .HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");

                entity.Property(e => e.PartnerLatitude).HasColumnName("partner_latitude");

                entity.Property(e => e.PartnerLongitude).HasColumnName("partner_longitude");

                entity.Property(e => e.PartnerShare)
                    .HasColumnName("partner_share")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneSanitized)
                    .HasColumnName("phone_sanitized")
                    .HasMaxLength(255);

                entity.Property(e => e.PickingWarn)
                    .HasColumnName("picking_warn")
                    .HasMaxLength(255);

                entity.Property(e => e.PickingWarnMsg)
                    .HasColumnName("picking_warn_msg")
                    .HasMaxLength(255);

                entity.Property(e => e.PurchaseWarn)
                    .HasColumnName("purchase_warn")
                    .HasMaxLength(255);

                entity.Property(e => e.PurchaseWarnMsg)
                    .HasColumnName("purchase_warn_msg")
                    .HasMaxLength(255);

                entity.Property(e => e.Ref)
                    .HasColumnName("ref")
                    .HasMaxLength(255);

                entity.Property(e => e.SaleWarn)
                    .HasColumnName("sale_warn")
                    .HasMaxLength(255);

                entity.Property(e => e.SaleWarnMsg)
                    .HasColumnName("sale_warn_msg")
                    .HasMaxLength(255);

                entity.Property(e => e.SignupExpiration)
                    .HasColumnName("signup_expiration")
                    .HasColumnType("datetime");

                entity.Property(e => e.SignupToken)
                    .HasColumnName("signup_token")
                    .HasMaxLength(255);

                entity.Property(e => e.SignupType)
                    .HasColumnName("signup_type")
                    .HasMaxLength(255);

                entity.Property(e => e.StateId)
                    .HasColumnName("state_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(255);

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasMaxLength(255);

                entity.Property(e => e.SupplierRank).HasColumnName("supplier_rank");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(255);

                entity.Property(e => e.Tz)
                    .HasColumnName("tz")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Vat)
                    .HasColumnName("vat")
                    .HasMaxLength(255);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");

                entity.Property(e => e.XArabicName)
                    .HasColumnName("x_arabic_name")
                    .HasMaxLength(255);

                entity.Property(e => e.XCode)
                    .HasColumnName("x_code")
                    .HasMaxLength(255);

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ResourceCalendar>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.FullTimeRequiredHours).HasColumnName("full_time_required_hours");

                entity.Property(e => e.HoursPerDay).HasColumnName("hours_per_day");

                entity.Property(e => e.HoursPerWeek).HasColumnName("hours_per_week");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.TwoWeeksCalendar)
                    .HasColumnName("two_weeks_calendar")
                    .HasMaxLength(255);

                entity.Property(e => e.Tz)
                    .HasColumnName("tz")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<TagValue>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Column1).HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e._1).HasMaxLength(255);

                entity.Property(e => e._2).HasMaxLength(255);

                entity.Property(e => e._3).HasMaxLength(255);

                entity.Property(e => e._4).HasMaxLength(255);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");
            });
 modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActionId)
                    .HasColumnName("action_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(255);

                entity.Property(e => e.AliasId)
                    .HasColumnName("alias_id")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(255);

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.NotificationType)
                    .HasColumnName("notification_type")
                    .HasMaxLength(255);

                entity.Property(e => e.OdoobotState)
                    .HasColumnName("odoobot_state")
                    .HasMaxLength(255);

                entity.Property(e => e.OutOfOfficeMessage)
                    .HasColumnName("out_of_office_message")
                    .HasMaxLength(255);

                entity.Property(e => e.PartnerId)
                    .HasColumnName("partner_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.SaleTeamId)
                    .HasColumnName("sale_team_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Share)
                    .HasColumnName("share")
                    .HasMaxLength(255);

                entity.Property(e => e.Signature)
                    .HasColumnName("signature")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetSalesDone)
                    .HasColumnName("target_sales_done")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetSalesInvoiced)
                    .HasColumnName("target_sales_invoiced")
                    .HasMaxLength(255);

                entity.Property(e => e.TargetSalesWon)
                    .HasColumnName("target_sales_won")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid)
                    .HasColumnName("write_uid")
                    .HasMaxLength(255);
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddressFormat)
                    .HasColumnName("address_format")
                    .HasMaxLength(255);

                entity.Property(e => e.AddressViewId)
                    .HasColumnName("address_view_id")
                    .HasMaxLength(255);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NamePosition)
                    .HasColumnName("name_position")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneCode).HasColumnName("phone_code");

                entity.Property(e => e.VatLabel)
                    .HasColumnName("vat_label")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUid).HasColumnName("create_uid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.WriteDate)
                    .HasColumnName("write_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.WriteUid).HasColumnName("write_uid");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
