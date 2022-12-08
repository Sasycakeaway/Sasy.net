using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SvelteKitSample.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewPassController : ControllerBase
    {
        [HttpPost]
        public string Post([FromForm] IFormCollection request)
        {
            string email = request["email"];
            Guid uuid = Guid.Parse(request["uuid"]);
            using(var context = new SasyContext()){
                var newrequest = new RecoveryPassword();
                newrequest.FkEmail = email;
                newrequest.Uuid = uuid;
                context.RecoveryPasswords.Add(newrequest);
                context.SaveChanges();
                return "1";
            }
        }

    }
}
