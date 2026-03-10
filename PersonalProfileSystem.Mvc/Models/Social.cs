using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Social
{
    public int SocialId { get; set; }

    public string PlatformName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserSocial> UserSocials { get; set; } = new List<UserSocial>();
}
