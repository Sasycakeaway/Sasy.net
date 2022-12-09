using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetOrdersByPassController : ControllerBase
    {
        [HttpPost]
        public string Get([FromForm] IFormCollection request)
        {
            var key = System.Configuration.ConfigurationManager.AppSettings.Get("DecryptionKey");
            string email = request["email"];
            string password = request["password"];

            try { 
                using (var db = new SasyContext())
                {
                    using (var context = new SasyContext())
                    {
                        var query = context.Utentis
                                           .Where(s => s.PkEmail == email)
                                           .FirstOrDefault<Utenti>();
                        if (query.Password == password)
                        {
                            var ordini = db.Ordinis.Where(b => b.FkEmail == email).ToList();

                            return JsonConvert.SerializeObject(ordini);
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return "0";
            }
        }
    }
}
