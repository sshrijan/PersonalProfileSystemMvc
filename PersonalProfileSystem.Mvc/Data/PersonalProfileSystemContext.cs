using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonalProfileSystem.Mvc.Models;

namespace PersonalProfileSystem.Mvc.Data;

public partial class PersonalProfileSystemContext : DbContext
{
    public PersonalProfileSystemContext()
    {
    }

    public PersonalProfileSystemContext(DbContextOptions<PersonalProfileSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<EmploymentHistory> EmploymentHistories { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<PersonInfo> PersonInfos { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Social> Socials { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<UsedTechnology> UsedTechnologies { get; set; }

    public virtual DbSet<UserAchievement> UserAchievements { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<UserCertificate> UserCertificates { get; set; }

    public virtual DbSet<UserEducation> UserEducations { get; set; }

    public virtual DbSet<UserHobby> UserHobbies { get; set; }

    public virtual DbSet<UserLanguage> UserLanguages { get; set; }

    public virtual DbSet<UserProject> UserProjects { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    public virtual DbSet<UserSocial> UserSocials { get; set; }

    public virtual DbSet<VwPersonAchievement> VwPersonAchievements { get; set; }

    public virtual DbSet<VwPersonAddress> VwPersonAddresses { get; set; }

    public virtual DbSet<VwPersonCertificate> VwPersonCertificates { get; set; }

    public virtual DbSet<VwPersonContact> VwPersonContacts { get; set; }

    public virtual DbSet<VwPersonEducation> VwPersonEducations { get; set; }

    public virtual DbSet<VwPersonEmploymentHistory> VwPersonEmploymentHistories { get; set; }

    public virtual DbSet<VwPersonHobbie> VwPersonHobbies { get; set; }

    public virtual DbSet<VwPersonLanguage> VwPersonLanguages { get; set; }

    public virtual DbSet<VwPersonProject> VwPersonProjects { get; set; }

    public virtual DbSet<VwPersonSkill> VwPersonSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK_achievements");

            entity.Property(e => e.AchievementId).HasColumnName("achievementId");
            entity.Property(e => e.AchievementDate).HasColumnName("achievementDate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DistrictCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtCity");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provinceState");
            entity.Property(e => e.Tole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tole");
            entity.Property(e => e.Ward).HasColumnName("ward");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PK_certificate");

            entity.Property(e => e.CertificateId).HasColumnName("certificateId");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("certificateType");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__company___AD54599009DC6D8D");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("companyName");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.SalaryId).HasColumnName("salaryId");
        });

        modelBuilder.Entity<CompanyAddress>(entity =>
        {
            entity.ToTable("CompanyAddress");

            entity.Property(e => e.CompanyAddressId).HasColumnName("companyAddressId");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DistrictCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtCity");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.IsHeadOffice).HasColumnName("isHeadOffice");
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provinceState");

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyAddresses)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyAddress_Company");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_contact");

            entity.Property(e => e.ContactId).HasColumnName("contactId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacts_PersonInfos");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK_education");

            entity.Property(e => e.EducationId).HasColumnName("educationId");
            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("degree");
            entity.Property(e => e.Field)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("field");
            entity.Property(e => e.InstitutionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("institutionName");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<EmploymentHistory>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CompanyId }).HasName("PK_EmploymentHistory_1");

            entity.ToTable("EmploymentHistory");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())", "DF__Employmen__creat__041093DD")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__Employmen__isDel__031C6FA4")
                .HasColumnName("isActive");
            entity.Property(e => e.IsCurrentlyWorking).HasColumnName("isCurrentlyWorking");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("jobTitle");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
            entity.Property(e => e.YearsOfExperience).HasColumnName("yearsOfExperience");

            entity.HasOne(d => d.Company).WithMany(p => p.EmploymentHistories)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmploymentHistory_Company");

            entity.HasOne(d => d.User).WithMany(p => p.EmploymentHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmploymentHistory_PersonInfos");
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.HasKey(e => e.HobbyId).HasName("PK_hobbies");

            entity.Property(e => e.HobbyId).HasColumnName("hobbyId");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.HobbyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hobbyName");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK_languages");

            entity.Property(e => e.LanguageId).HasColumnName("languageId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.LanguageName)
                .HasMaxLength(50)
                .HasColumnName("languageName");
        });

        modelBuilder.Entity<PersonInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_basicInfo");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middleName");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK_projects");

            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.SkillId).HasColumnName("skillId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .HasColumnName("skillName");
        });

        modelBuilder.Entity<Social>(entity =>
        {
            entity.HasKey(e => e.SocialId).HasName("PK_social");

            entity.ToTable("Social");

            entity.Property(e => e.SocialId).HasColumnName("socialId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.PlatformName)
                .HasMaxLength(50)
                .HasColumnName("platformName");
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.TechnologyId).HasName("PK_TechnologyUsed");

            entity.ToTable("Technology");

            entity.Property(e => e.TechnologyId).HasColumnName("technologyId");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.TechnologyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsedTechnology>(entity =>
        {
            entity.HasKey(e => new { e.ProjectId, e.TechnologyId });

            entity.ToTable("UsedTechnology");

            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.TechnologyId).HasColumnName("technologyId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF_UsedTechnology_isActive")
                .HasColumnName("isActive");

            entity.HasOne(d => d.Project).WithMany(p => p.UsedTechnologies)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsedTechnology_Projects");

            entity.HasOne(d => d.Technology).WithMany(p => p.UsedTechnologies)
                .HasForeignKey(d => d.TechnologyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsedTechnology_Technology");
        });

        modelBuilder.Entity<UserAchievement>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AchievementId }).HasName("PK_userAchievements");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.AchievementId).HasColumnName("achievementId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");

            entity.HasOne(d => d.Achievement).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAchievements_Achievements");

            entity.HasOne(d => d.User).WithMany(p => p.UserAchievements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userAchievements_basicInfos");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AddressId });

            entity.ToTable("userAddress");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF_userAddress_isActive")
                .HasColumnName("isActive");

            entity.HasOne(d => d.Address).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userAddress_Address");

            entity.HasOne(d => d.User).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userAddress_PersonInfos");
        });

        modelBuilder.Entity<UserCertificate>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CertificateId }).HasName("PK_userCertificates");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CertificateId).HasColumnName("certificateId");
            entity.Property(e => e.CertificateImage)
                .HasColumnType("image")
                .HasColumnName("certificateImage");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__UserCerti__isDel__7D63964E")
                .HasColumnName("isActive");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("issuedBy");
            entity.Property(e => e.IssuedDate).HasColumnName("issuedDate");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Certificate).WithMany(p => p.UserCertificates)
                .HasForeignKey(d => d.CertificateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userCertificates_certificates");

            entity.HasOne(d => d.User).WithMany(p => p.UserCertificates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userCertificates_basicInfos");
        });

        modelBuilder.Entity<UserEducation>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.EducationId }).HasName("PK_userEducations");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.EducationId).HasColumnName("educationId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())", "DF__UserEduca__creat__02284B6B")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.CurrentlyStudying).HasColumnName("currentlyStudying");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__UserEduca__isDel__01342732")
                .HasColumnName("isActive");
            entity.Property(e => e.PassedYear).HasColumnName("passedYear");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Education).WithMany(p => p.UserEducations)
                .HasForeignKey(d => d.EducationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userEducations_educations1");

            entity.HasOne(d => d.User).WithMany(p => p.UserEducations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userEducations_basicInfos1");
        });

        modelBuilder.Entity<UserHobby>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.HobbyId }).HasName("PK_userHobbies");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.HobbyId).HasColumnName("hobbyId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF_UserHobbies_isActive")
                .HasColumnName("isActive");

            entity.HasOne(d => d.Hobby).WithMany(p => p.UserHobbies)
                .HasForeignKey(d => d.HobbyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userHobbies_hobbies");

            entity.HasOne(d => d.User).WithMany(p => p.UserHobbies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userHobbies_basicInfos");
        });

        modelBuilder.Entity<UserLanguage>(entity =>
        {
            entity.HasKey(e => new { e.LanguageId, e.UserId }).HasName("PK_userLanguage");

            entity.ToTable("UserLanguage");

            entity.Property(e => e.LanguageId).HasColumnName("languageId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__UserLangu__isDel__7B7B4DDC")
                .HasColumnName("isActive");
            entity.Property(e => e.ProficiencyLevel)
                .HasMaxLength(50)
                .HasColumnName("proficiencyLevel");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Language).WithMany(p => p.UserLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userLanguage_languages");

            entity.HasOne(d => d.LanguageNavigation).WithMany(p => p.UserLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userLanguage_basicInfos");
        });

        modelBuilder.Entity<UserProject>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ProjectId }).HasName("PK_userProjects");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__UserProje__isDel__7F4BDEC0")
                .HasColumnName("isActive");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Project).WithMany(p => p.UserProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userProjects_projects1");

            entity.HasOne(d => d.User).WithMany(p => p.UserProjects)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userProjects_basicInfos2");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => new { e.SkillId, e.UserId }).HasName("PK_userSkill");

            entity.ToTable("UserSkill");

            entity.Property(e => e.SkillId).HasColumnName("skillId");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__UserSkill__isDel__7993056A")
                .HasColumnName("isActive");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skillLevel");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
            entity.Property(e => e.YearsOfExperience).HasColumnName("yearsOfExperience");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userSkill_Skills");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userSkill_basicInfos");
        });

        modelBuilder.Entity<UserSocial>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.SocialId }).HasName("PK_userSocial");

            entity.ToTable("UserSocial");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.SocialId).HasColumnName("socialId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeletedBy).HasColumnName("deletedBy");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("deletedDate");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true, "DF__UserSocia__isDel__77AABCF8")
                .HasColumnName("isActive");
            entity.Property(e => e.PlatformUrl)
                .IsUnicode(false)
                .HasColumnName("platformUrl");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Social).WithMany(p => p.UserSocials)
                .HasForeignKey(d => d.SocialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userSocial_social");

            entity.HasOne(d => d.User).WithMany(p => p.UserSocials)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_userSocial_basicInfos");
        });

        modelBuilder.Entity<VwPersonAchievement>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonAchievement");

            entity.Property(e => e.AchievementDate).HasColumnName("achievementDate");
            entity.Property(e => e.AchievementId).HasColumnName("achievementId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<VwPersonAddress>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonAddress");

            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DistrictCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtCity");
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provinceState");
            entity.Property(e => e.Tole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tole");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Ward).HasColumnName("ward");
        });

        modelBuilder.Entity<VwPersonCertificate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonCertificate");

            entity.Property(e => e.CertificateId).HasColumnName("certificateId");
            entity.Property(e => e.CertificateImage)
                .HasColumnType("image")
                .HasColumnName("certificateImage");
            entity.Property(e => e.CertificateType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("certificateType");
            entity.Property(e => e.IssuedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("issuedBy");
            entity.Property(e => e.IssuedDate).HasColumnName("issuedDate");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<VwPersonContact>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonContact");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PlatformName)
                .HasMaxLength(50)
                .HasColumnName("platformName");
            entity.Property(e => e.PlatformUrl)
                .IsUnicode(false)
                .HasColumnName("platformUrl");
            entity.Property(e => e.SocialId).HasColumnName("socialId");
        });

        modelBuilder.Entity<VwPersonEducation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonEducation");

            entity.Property(e => e.CurrentlyStudying).HasColumnName("currentlyStudying");
            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("degree");
            entity.Property(e => e.EducationId).HasColumnName("educationId");
            entity.Property(e => e.Field)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("field");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.InstitutionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("institutionName");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.PassedYear).HasColumnName("passedYear");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<VwPersonEmploymentHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonEmploymentHistory");

            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.DistrictCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("districtCity");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IsCurrentlyWorking).HasColumnName("isCurrentlyWorking");
            entity.Property(e => e.IsHeadOffice).HasColumnName("isHeadOffice");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("jobTitle");
            entity.Property(e => e.ProvinceState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provinceState");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.YearsOfExperience).HasColumnName("yearsOfExperience");
        });

        modelBuilder.Entity<VwPersonHobbie>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonHobbie");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.HobbyId).HasColumnName("hobbyId");
            entity.Property(e => e.HobbyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("hobbyName");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<VwPersonLanguage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonLanguage");

            entity.Property(e => e.LanguageId).HasColumnName("languageId");
            entity.Property(e => e.LanguageName)
                .HasMaxLength(50)
                .HasColumnName("languageName");
            entity.Property(e => e.ProficiencyLevel)
                .HasMaxLength(50)
                .HasColumnName("proficiencyLevel");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<VwPersonProject>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonProject");

            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Technology)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TechnologyId).HasColumnName("technologyId");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<VwPersonSkill>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonSkill");

            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.SkillId).HasColumnName("skillId");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skillLevel");
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .HasColumnName("skillName");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.YearsOfExperience).HasColumnName("yearsOfExperience");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
