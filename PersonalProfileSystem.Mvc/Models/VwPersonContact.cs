using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonContact
{
    public int UserId { get; set; }

    public int? ContactId { get; set; }

    public int? SocialId { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public string? PlatformName { get; set; }

    public string? PlatformUrl { get; set; }
}
