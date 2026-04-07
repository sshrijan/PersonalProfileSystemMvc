using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserAddress
{
    public int UserId { get; set; }

    public int AddressId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DeletedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
