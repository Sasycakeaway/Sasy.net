using System;
using System.Collections.Generic;

namespace SvelteKitSample.Model
{
    public partial class VwOrdini
    {
        public long PkId { get; set; }
        public string PkEmail { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Cf { get; set; }
        public string? Nascita { get; set; }
        public string? Cap { get; set; }
        public string? Indirizzo { get; set; }
        public string? Domicilio { get; set; }
        public string? FkEmail { get; set; }
        public int? Totale { get; set; }
        public string? Cart { get; set; }
    }
}
