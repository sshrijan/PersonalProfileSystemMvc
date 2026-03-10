using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class VwPersonCertificate
{
    public int UserId { get; set; }

    public int? CertificateId { get; set; }

    public string? CertificateType { get; set; }

    public byte[]? CertificateImage { get; set; }

    public string? IssuedBy { get; set; }

    public DateOnly? IssuedDate { get; set; }
}
