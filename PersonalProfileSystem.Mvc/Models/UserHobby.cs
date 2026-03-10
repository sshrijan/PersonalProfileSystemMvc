using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserHobby
{
    public int UserId { get; set; }

    public int HobbyId { get; set; }

    public bool IsActive { get; set; }

    public virtual Hobby Hobby { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
