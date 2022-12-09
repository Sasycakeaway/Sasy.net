using Microsoft.AspNetCore.Mvc;
using Sasy.NET.AES;

namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/x-www-form-urlencoded")]
    public class AddOrderController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public string Post([FromForm] IFormCollection value)
        {
            var key = System.Configuration.ConfigurationManager.AppSettings.Get("DecryptionKey");
            Guid id = Guid.Parse(value["id"]);
            string nome = AesOperation.EncryptString(key, value["nome"]);
            string cognome = AesOperation.EncryptString(key, value["cognome"]);
            string indirizzo = AesOperation.EncryptString(key, value["indirizzo"]);
            string cap = AesOperation.EncryptString(key, value["cap"]);
            string email = Request.Cookies["username"];
            int totale = int.Parse(value["totale"]);
            string cart = value["cart"];
            DateTime timestamp = DateTime.Now;
            Boolean domicilio = Boolean.Parse(value["domicilio"]);
            Boolean spedizione = Boolean.Parse(value["spedizione"]);
            
                try
                {
                    using (var db = new SasyContext())
                    {
                        var order = new Ordini();
                        order.PkId = id;
                        order.Nome = nome;
                        order.Cognome = cognome;
                        order.Indirizzo = indirizzo;
                        order.Cap = cap;
                        order.Domicilio = domicilio;
                        order.Spedizione = spedizione;
                        order.FkEmail = email;
                        order.Cart = cart;
                        order.Timestamp = timestamp;
                        order.Totale = totale;
 
                        db.Add(order);
                        db.SaveChanges();

                        return "1";
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return "0";
                }
            
        }

    }
}
