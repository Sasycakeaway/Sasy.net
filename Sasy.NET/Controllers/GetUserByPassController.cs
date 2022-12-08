using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;


namespace SvelteKitSample.Model
{
    public class PartialUser
    {
        public string Cf;
        public string Nascita;
        public string Telefono;
    }
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserByPassController : ControllerBase
    {
        [HttpPost]
        public string Get([FromForm] IFormCollection request)
        {
            var key = System.Configuration.ConfigurationManager.AppSettings.Get("DecryptionKey");
            string Email = request["email"];
            string password = request["password"];
            try
            {
                using (var context = new SasyContext())
                {
                    var query = context.Utentis
                                       .Where(s => s.PkEmail == Email)
                                       .First();
             
                    if (query.Password == password)
                    {
               
                        PartialUser userdecrypted = new PartialUser();
                        userdecrypted.Cf = AesOperation.DecryptString(key, query.Cf);
                        userdecrypted.Nascita = AesOperation.DecryptString(key, query.Nascita);
                        userdecrypted.Telefono = AesOperation.DecryptString(key, query.Telefono);
                        return JsonConvert.SerializeObject(userdecrypted);
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }

    }

    }
}
