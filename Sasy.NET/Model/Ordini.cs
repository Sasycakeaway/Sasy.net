using System;
using System.Collections.Generic;

namespace SvelteKitSample.Model
{
    public partial class Ordini
    {
        public Guid PkId { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Indirizzo { get; set; }
        public string? Cap { get; set; }
        public string? Domicilio { get; set; }
        public string? FkEmail { get; set; }
        public int? Totale { get; set; }
        public string? Cart { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual Utenti? FkEmailNavigation { get; set; }
    }
}
