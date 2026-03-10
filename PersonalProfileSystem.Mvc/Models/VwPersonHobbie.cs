using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonHobbie
{
    public int UserId { get; set; }

    public int? HobbyId { get; set; }

    public string? HobbyName { get; set; }

    public string? Category { get; set; }
}
