namespace Sasy.NET.Model;

public class Cart_Response
{
    private string _prodotto;
    public string prodotto
    {
        get { return _prodotto;  }
        set { _prodotto = value; }
    }
    private int? _qty;
    public int? qty
    {
        get { return _qty;  }
        set { _qty = value; }
    }

    private int? _costo;
    public int? costo
    {
        get { return _costo;  }
        set { _costo = value; }
    }
}