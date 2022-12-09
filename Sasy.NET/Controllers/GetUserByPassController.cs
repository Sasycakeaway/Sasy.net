using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Sasy.NET.AES;

namespace Sasy.NET.Model
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
        [HttpGet]
        public string Get()
        {
            var key = System.Configuration.ConfigurationManager.AppSettings.Get("DecryptionKey");
            string? email = Request.Cookies["username"];
            string? password = Request.Cookies["password"];
            try
            {
                using (var context = new SasyContext())
                {
                    var query = context.Utentis
                                       .Where(s => s.PkEmail == email)
                                       .FirstOrDefault();
             
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
