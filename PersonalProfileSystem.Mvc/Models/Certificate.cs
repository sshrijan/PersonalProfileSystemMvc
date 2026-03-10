using System;
using System.Collections.Generic;

namespace PersonalProfileSystem.Mvc.Models;

public partial class Certificate
{
    public int CertificateId { get; set; }

    public string? CertificateType { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserCertificate> UserCertificates { get; set; } = new List<UserCertificate>();
}
