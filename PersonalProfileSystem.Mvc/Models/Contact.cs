using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual PersonInfo User { get; set; } = null!;
}
