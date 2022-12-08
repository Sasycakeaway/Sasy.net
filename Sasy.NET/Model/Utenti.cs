using System;
using System.Collections.Generic;

namespace SvelteKitSample.Model
{
    public partial class Utenti
    {
        public Utenti()
        {
            Ordinis = new HashSet<Ordini>();
        }

        public string? Cf { get; set; }
        public string? Nascita { get; set; }
        public string? Telefono { get; set; }
        public string PkEmail { get; set; } = null!;
        public string? Password { get; set; }
        public DateTime? Timestamp { get; set; }
        public byte[] News { get; set; }
        public virtual RecoveryPassword RecoveryPassword { get; set; } = null!;
        public virtual ICollection<Ordini> Ordinis { get; set; }
    }
}
