using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public string Post([FromForm] IFormCollection request)
        {
            try{
                string password = request["password"];
                string email = request["email"];
                using (var context = new SasyContext())
                {
                    var user = context.Utentis.Where(e => e.PkEmail == email).Single();

                    if (user.Password == password)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                }
            }catch(Exception ex){
                Console.WriteLine(ex);
                return "0";
            }
        }
    }
 }
