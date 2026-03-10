using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserLanguage> UserLanguages { get; set; } = new List<UserLanguage>();
}
