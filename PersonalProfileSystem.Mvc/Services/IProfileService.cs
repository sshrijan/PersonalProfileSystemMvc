using PersonalProfileSystem.Mvc.ViewModels;

namespace PersonalProfileSystem.Mvc.Services
{
    public interface IProfileService
    {
        Task AddContact(AddContactViewModel model);

        Task AddAddress(AddAddressViewModel model);

        Task AddSkill(AddSkillViewModel model);

        Task AddEducation(AddEducationViewModel model);
        Task<(bool Success, string Message)> DeleteAddressAsync(int userId, int addressId);
        Task<(bool Success, string Message)> DeleteSkillAsync(int userId, int skillId);
        Task<(bool Success, string Message)> DeleteEducationAsync(int userId, int educationId);
    }
}
