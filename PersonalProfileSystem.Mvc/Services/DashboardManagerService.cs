using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace PersonalProfileSystem.Mvc.Services
{
    public class DashboardManagerService : IProfileService
    {
        private readonly PersonalProfileSystemContext _context;

        public DashboardManagerService(PersonalProfileSystemContext context)
        {
            _context = context;
        }

        public async Task AddContact(AddContactViewModel model)
        {
            var contact = new Contact
            {
                UserId = model.UserId,
                Email = model.Email,
                Phone = model.Phone
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task AddAddress(AddAddressViewModel model)
        {
            try
            {
                if (_context == null)
                    throw new Exception("DbContext is null");

                if (model == null)
                    throw new Exception("Model is null");

                if (model.UserId == 0)
                    throw new ArgumentException("UserId cannot be 0");

                var existingAddress = await _context.Addresses
                    .FirstOrDefaultAsync(a =>
                        a.Tole == model.Tole &&
                        a.Ward == model.Ward);

                if (existingAddress == null)
                {
                    var newAddress = new Address
                    {
                        Tole = model.Tole,
                        Ward = model.Ward,
                        DistrictCity = model.DistrictCity,
                        ProvinceState = model.ProvinceState,
                        Country = model.Country
                    };

                    _context.Addresses.Add(newAddress);
                    var saveResult = await _context.SaveChangesAsync();

                    if (saveResult > 0)
                    {
                        var userAddress = new UserAddress
                        {
                            UserId = model.UserId,
                            AddressId = newAddress.AddressId,
                            IsActive = true
                        };

                        _context.UserAddresses.Add(userAddress);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    var existingUserAddress = await _context.UserAddresses
                        .FirstOrDefaultAsync(ua =>
                            ua.UserId == model.UserId &&
                            ua.AddressId == existingAddress.AddressId);

                    if (existingUserAddress == null)
                    {
                        var userAddress = new UserAddress
                        {
                            UserId = model.UserId,
                            AddressId = existingAddress.AddressId,
                            IsActive = true
                        };

                        _context.UserAddresses.Add(userAddress);
                        await _context.SaveChangesAsync();
                    }
                    else if (!existingUserAddress.IsActive)
                    {
                        // Reactivate the soft-deleted record
                        existingUserAddress.IsActive = true;
                        existingUserAddress.DeletedDate = null;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task AddSkill(AddSkillViewModel model)
        {
            if (model.UserId == 0) throw new ArgumentException("UserId cannot be 0");

            var skill = await _context.Skills
                .FirstOrDefaultAsync(s => s.SkillName == model.SkillName);

            if (skill == null)
            {
                skill = new Skill { SkillName = model.SkillName };
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();
            }

            var existingUserSkill = await _context.UserSkills
                .FirstOrDefaultAsync(us => us.UserId == model.UserId && us.SkillId == skill.SkillId);

            if (existingUserSkill != null)
            {
                if (!existingUserSkill.IsActive)
                {
                    // Reactivate and update
                    existingUserSkill.IsActive = true;
                    existingUserSkill.SkillLevel = model.SkillLevel;
                    existingUserSkill.YearsOfExperience = model.YearsOfExperience;
                    existingUserSkill.DeletedDate = null;
                    existingUserSkill.UpdatedDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                return;
            }

            var userSkill = new UserSkill
            {
                UserId = model.UserId,
                SkillId = skill.SkillId,
                SkillLevel = model.SkillLevel,
                YearsOfExperience = model.YearsOfExperience,
                IsActive = true,
            };

            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();
        }

        public async Task AddEducation(AddEducationViewModel model)
        {
            if (model.UserId == 0) throw new ArgumentException("UserId cannot be 0");

            var education = await _context.Educations.FirstOrDefaultAsync(e =>
                e.InstitutionName == model.InstitutionName &&
                e.Degree == model.Degree &&
                e.Field == model.Field &&
                e.Location == model.Location);

            if (education == null)
            {
                education = new Education
                {
                    Degree = model.Degree,
                    Field = model.Field,
                    InstitutionName = model.InstitutionName,
                    Location = model.Location
                };

                _context.Educations.Add(education);
                await _context.SaveChangesAsync();
            }

            var existingUserEducation = await _context.UserEducations.FirstOrDefaultAsync(ue =>
                ue.UserId == model.UserId &&
                ue.EducationId == education.EducationId);

            if (existingUserEducation != null)
            {
                if (!existingUserEducation.IsActive)
                {
                    // Reactivate and update
                    existingUserEducation.IsActive = true;
                    existingUserEducation.CurrentlyStudying = model.CurrentlyStudying;
                    existingUserEducation.Grade = model.Grade;
                    existingUserEducation.PassedYear = model.PassedYear;
                    existingUserEducation.DeletedDate = null;  
                    existingUserEducation.UpdatedDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                return;
            }

            var userEducation = new UserEducation
            {
                UserId = model.UserId,
                EducationId = education.EducationId,
                CurrentlyStudying = model.CurrentlyStudying,
                Grade = model.Grade,
                PassedYear = model.PassedYear,
                IsActive = true,
            };
            _context.UserEducations.Add(userEducation);
            await _context.SaveChangesAsync();
        }
        public async Task<(bool Success, string Message)> DeleteAddressAsync(int userId, int addressId)
        {
            try
            {
                // Find the junction record
                var userAddress = await _context.UserAddresses
                    .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AddressId == addressId && ua.IsActive);

                if (userAddress == null)
                {
                    return (false, "Address association not found or already removed!");
                }

                // Soft delete - mark as inactive and set deletion date
                userAddress.IsActive = false;
                userAddress.DeletedDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return (true, "Address removed from your profile successfully!");
            }
            catch (Exception ex)
            {
                return (false, $"Error removing address: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> DeleteSkillAsync(int userId, int skillId)
        {
            try
            {
                // Find the junction record
                var userSkill = await _context.UserSkills
                    .FirstOrDefaultAsync(us => us.UserId == userId && us.SkillId == skillId && us.IsActive);

                if (userSkill == null)
                {
                    return (false, "Skill association not found or already removed!");
                }

                // Soft delete - mark as inactive and set deletion date
                userSkill.IsActive = false;
                userSkill.DeletedDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return (true, "Skill removed from your profile successfully!");
            }
            catch (Exception ex)
            {
                return (false, $"Error removing skill: {ex.Message}");
            }
        }

        public async Task<(bool Success, string Message)> DeleteEducationAsync(int userId, int educationId)
        {
            try
            {
                // Find the junction record
                var userEducation = await _context.UserEducations
                    .FirstOrDefaultAsync(ue => ue.UserId == userId && ue.EducationId == educationId && ue.IsActive);

                if (userEducation == null)
                {
                    return (false, "Education association not found or already removed!");
                }

                // Soft delete - mark as inactive and set deletion date
                userEducation.IsActive = false;
                userEducation.DeletedDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return (true, "Education removed from your profile successfully!");
            }
            catch (Exception ex)
            {
                return (false, $"Error removing education: {ex.Message}");
            }
        }
    }
}
