using PersonalProfileSystem.Mvc.ViewModels;

namespace PersonalProfileSystem.Mvc.Services
{
    public interface IProfileService
    {
        Task AddContact(AddContactViewModel model);

        Task AddAddress(AddAddressViewModel model);

        Task AddSkill(AddSkillViewModel model);

        Task AddEducation(AddEducationViewModel model);
    }
}
