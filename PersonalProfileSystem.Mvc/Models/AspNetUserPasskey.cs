using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class AspNetUserPasskey
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string CredentialId { get; set; } = null!;

    public byte[] PublicKey { get; set; } = null!;

    public string? DeviceName { get; set; }

    public bool BackupState { get; set; }

    public bool BackupEligible { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
