using System;
using System.Collections.Generic;

namespace Sasy.NET.Model;

public partial class Cart
{
    public string Prodotto { get; set; } = null!;

    public int? Qty { get; set; }

    public int? Costo { get; set; }

    public string Email { get; set; } = null!;

    public virtual Utenti EmailNavigation { get; set; } = null!;
}
