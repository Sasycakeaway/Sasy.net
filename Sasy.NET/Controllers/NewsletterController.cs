using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SvelteKitSample.Model;

namespace SvelteKitSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public string GetUser([FromForm] IFormCollection value)
        {
            try
            {
                using(var db = new SasyContext())
                {
                    if (value["password"] == System.Configuration.ConfigurationManager.AppSettings.Get("DBPass"))
                    {
                        var utenti = db.Utentis.Where(b => b.News == new byte[Convert.ToByte(true)]).Select(b => b.PkEmail).ToList();
                        return JsonConvert.SerializeObject(utenti);
                    }
                    else
                    {
                        return "0";
                    }

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "0";
            }
        }
        [HttpGet("{email}/{token}")]
        public string Delete(string email, string token)
        {
            try
            {
                using(var db = new SasyContext())
                {
                    var email_to_delete = db.Utentis.Where(e => e.PkEmail == email).SingleOrDefault();
                    if (email_to_delete != null)
                    {
                        var token_to_delete = db.Newsletters.Where(e => e.PkToken == Guid.Parse(token))
                            .Where(e => e.FkEmail == email).SingleOrDefault();

                        if(token_to_delete != null)
                        {
                            email_to_delete.News = new byte[0x1];

                            db.Utentis.Attach(email_to_delete).Property(e => e.News).IsModified = true;
                            db.Newsletters.Remove(token_to_delete);
                            db.SaveChanges();
                        }

                    }
                }
                return "Sei stato rimosso dalla newsletter correttamente!";
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "C'è stato un errore durante la rimozione del tuo account dalla newsletter, contattare Sasy";
            }
        }
    }
}
