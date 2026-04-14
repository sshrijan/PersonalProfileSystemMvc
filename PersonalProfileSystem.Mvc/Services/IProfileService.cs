using PersonalProfileSystem.Mvc.ViewModels;

namespace PersonalProfileSystem.Mvc.Services
{
    public interface IProfileService
    {
        // Add operations
        Task AddAddress(AddressViewModel model);
        Task AddSkill(SkillViewModel model);
        Task AddEducation(EducationViewModel model);
        Task AddContact(ContactViewModel model);

        // Update operations (using same ViewModels
        //Task<bool> UpdateProfileAsync(ProfileViewModel model);

        Task<bool> UpdateEducationAsync(EducationViewModel model);
        Task<bool> UpdateSkillAsync(SkillViewModel model);
        Task<bool> UpdateAddressAsync(AddressViewModel model);
        Task<bool> UpdateContactAsync(ContactViewModel model);



        Task<(bool Success, string Message)> DeleteAddressAsync(int userId, int addressId);
        Task<(bool Success, string Message)> DeleteSkillAsync(int userId, int skillId);
        Task<(bool Success, string Message)> DeleteEducationAsync(int userId, int educationId);
    }
}
