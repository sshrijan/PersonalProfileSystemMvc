using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserLanguage
{
    public int UserId { get; set; }

    public int LanguageId { get; set; }

    public string? ProficiencyLevel { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual PersonInfo LanguageNavigation { get; set; } = null!;
}
