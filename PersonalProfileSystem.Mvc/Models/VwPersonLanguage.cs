using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonLanguage
{
    public int UserId { get; set; }

    public int? LanguageId { get; set; }

    public string? LanguageName { get; set; }

    public string? ProficiencyLevel { get; set; }
}
