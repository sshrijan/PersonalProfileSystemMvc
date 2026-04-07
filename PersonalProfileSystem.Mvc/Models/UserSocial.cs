using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserSocial
{
    public int UserId { get; set; }

    public int SocialId { get; set; }

    public string? PlatformUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Social Social { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
