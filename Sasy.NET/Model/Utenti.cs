using System;
using System.Collections.Generic;

namespace Sasy.NET.Model;

public partial class Utenti
{
    public string? Cf { get; set; }

    public string? Nascita { get; set; }

    public string? Telefono { get; set; }

    public string PkEmail { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? Timestamp { get; set; }

    public byte[]? News { get; set; }

    public virtual ICollection<Newsletter> Newsletters { get; } = new List<Newsletter>();

    public virtual ICollection<Ordini> Ordinis { get; } = new List<Ordini>();

    public virtual RecoveryPassword? RecoveryPassword { get; set; }
}
