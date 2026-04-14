using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;
using PersonalProfileSystem.Mvc.ViewModels;
using System.Linq;

namespace PersonalProfileSystem.Mvc.Services
{
    public class DashboardManagerService : IProfileService
    {
        private readonly PersonalProfileSystemContext _context;

        public DashboardManagerService(PersonalProfileSystemContext context)
        {
            _context = context;
        }

        public async Task AddContact(ContactViewModel model)
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

        public async Task AddAddress(AddressViewModel model)
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

        public async Task AddSkill(SkillViewModel model)
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

        public async Task AddEducation(EducationViewModel model)
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


        public async Task<bool> UpdateEducationAsync(EducationViewModel model)
        {
            try
            {
                var userEducation = await _context.UserEducations
                    .Include(ue => ue.Education)
                    .FirstOrDefaultAsync(ue => ue.EducationId == model.EducationId
                                            && ue.UserId == model.UserId
                                            && ue.IsActive);

                if (userEducation == null)
                    return false;

                // Update Education basic info
                userEducation.Education.InstitutionName = model.InstitutionName;
                userEducation.Education.Degree = model.Degree;
                userEducation.Education.Field = model.Field;
                userEducation.Education.Location = model.Location;

                // Update UserEducation
                userEducation.CurrentlyStudying = model.CurrentlyStudying;
                userEducation.UpdatedDate = DateTime.Now;

                if (model.CurrentlyStudying)
                {
                    // === THIS IS THE KEY FIX ===
                    userEducation.PassedYear = null;
                    userEducation.Grade = null;

                    // Force EF Core to update these columns to NULL
                    _context.Entry(userEducation).Property(x => x.PassedYear).IsModified = true;
                    _context.Entry(userEducation).Property(x => x.Grade).IsModified = true;
                }
                else
                {
                    // Not currently studying
                    userEducation.PassedYear = model.PassedYear;

                    userEducation.Grade = string.IsNullOrWhiteSpace(model.Grade)
                        ? null
                        : model.Grade.Trim();
                }

                // Always mark this as modified too
                _context.Entry(userEducation).Property(x => x.CurrentlyStudying).IsModified = true;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateEducationAsync: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> UpdateSkillAsync(SkillViewModel model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Check if the user skill exists and is active
                var userSkill = await _context.UserSkills
                    .Include(us => us.Skill)
                    .FirstOrDefaultAsync(us => us.SkillId == model.SkillId
                        && us.UserId == model.UserId
                        && us.IsActive);

                if (userSkill == null)
                    return false;

                // Update the Skill master table if skill name changed
                if (userSkill.Skill.SkillName != model.SkillName)
                {
                    userSkill.Skill.SkillName = model.SkillName;
                }

                // Update the UserSkill mapping table
                userSkill.SkillLevel = model.SkillLevel;
                userSkill.YearsOfExperience = model.YearsOfExperience;
                userSkill.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAddressAsync(AddressViewModel model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Check if the user address exists and is active
                var userAddress = await _context.UserAddresses
                    .Include(ua => ua.Address)
                    .FirstOrDefaultAsync(ua => ua.AddressId == model.AddressId
                        && ua.UserId == model.UserId
                        && ua.IsActive);

                if (userAddress == null)
                    return false;

                // Update the Address table
                userAddress.Address.Tole = model.Tole;
                userAddress.Address.Ward = model.Ward;
                userAddress.Address.DistrictCity = model.DistrictCity;
                userAddress.Address.ProvinceState = model.ProvinceState;
                userAddress.Address.Country = model.Country;

                // Update the UserAddress mapping table
                userAddress.UpdatedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateProfileAsync(ProfileViewModel model)
        {
            var person = await _context.PersonInfos
                .FirstOrDefaultAsync(p => p.UserId == model.UserId);

            if (person == null)
                return false;

            person.FirstName = model.FirstName;
            person.MiddleName = model.MiddleName;
            person.LastName = model.LastName;
            person.Dob = DateOnly.FromDateTime(model.Dob);

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateContactAsync(ContactViewModel model)
        {
            if (model == null || model.ContactId == 0)
                return false;

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.ContactId == model.ContactId && c.UserId == model.UserId);

            if (contact == null)
                return false;

            // Update fields
            contact.Email = model.Email?.Trim();
            contact.Phone = model.Phone;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception in real project
                Console.WriteLine($"Error updating contact: {ex.Message}");
                return false;
            }
        }




    }
}
