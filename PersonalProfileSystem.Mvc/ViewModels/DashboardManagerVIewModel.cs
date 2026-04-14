namespace PersonalProfileSystem.Mvc.ViewModels
{
    public class ProfileViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
    public class AddressViewModel
    {
        // For Add: Id will be 0, For Update: Id will have value
        public int AddressId { get; set; }  // 0 means new, >0 means update

        public int UserId { get; set; }
        public string Tole { get; set; }
        public int Ward { get; set; }
        public string DistrictCity { get; set; }
        public string ProvinceState { get; set; }
        public string Country { get; set; }

        // For UI feedback
        public bool IsUpdate => AddressId > 0;
    }

    public class SkillViewModel
    {
        public int SkillId { get; set; }  // 0 means new, >0 means update
        public int UserId { get; set; }
        public string SkillName { get; set; }
        public string SkillLevel { get; set; }
        public int YearsOfExperience { get; set; }

        public bool IsUpdate => SkillId > 0;
    }

    public class EducationViewModel
    {
        public int EducationId { get; set; }  // 0 means new, >0 means update
        public int UserId { get; set; }
        public string Degree { get; set; }
        public string Field { get; set; }
        public string InstitutionName { get; set; }
        public string Location { get; set; }
        public bool CurrentlyStudying { get; set; }
        public string? Grade { get; set; }
        public int? PassedYear { get; set; }

        public bool IsUpdate => EducationId > 0;
    }

    public class ContactViewModel
    {
        public int ContactId { get; set; }  // 0 means new, >0 means update
        public int UserId { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

    }
}
