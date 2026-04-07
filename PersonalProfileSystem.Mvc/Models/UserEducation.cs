using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserEducation
{
    public int UserId { get; set; }

    public int EducationId { get; set; }

    public bool? CurrentlyStudying { get; set; }

    public string? Grade { get; set; }

    public int? PassedYear { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Education Education { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
