using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class UserCertificate
{
    public int UserId { get; set; }

    public int CertificateId { get; set; }

    public byte[]? CertificateImage { get; set; }

    public string? IssuedBy { get; set; }

    public DateOnly? IssuedDate { get; set; }

    public bool IsActive { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Certificate Certificate { get; set; } = null!;

    public virtual PersonInfo User { get; set; } = null!;
}
