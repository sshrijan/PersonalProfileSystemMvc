using PersonalProfileSystem.Mvc.Models;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.ViewModels
{
    public class DashboardViewModel
    {
        public PersonInfo Person { get; set; } = null!;
        public Contact? Contact { get; set; }
        public List<UserEducation>? Educations { get; set; }
        public List<UserAddress>? Addresses { get; set; }
        public List<UserSkill>? Skills { get; set; }
       
    }
}
