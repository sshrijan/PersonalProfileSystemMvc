using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Hobby
{
    public int HobbyId { get; set; }

    public string HobbyName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserHobby> UserHobbies { get; set; } = new List<UserHobby>();
}
