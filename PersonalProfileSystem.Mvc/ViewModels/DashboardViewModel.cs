using PersonalProfileSystem.Mvc.Models;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.ViewModels
{
    public class DashboardViewModel
    {
        public int UserId { get; set; }
        public PersonInfo Person { get; set; } = null!;
        public Contact Contact { get; set; } = new();

        public List<UserEducation> Educations { get; set; } = new();
        public List<UserAddress> Addresses { get; set; } = new();
        public List<UserSkill> Skills { get; set; } = new();
    }
}