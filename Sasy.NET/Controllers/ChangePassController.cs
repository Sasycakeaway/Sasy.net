using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangePassController : ControllerBase
    {
        [HttpPost]
        public string Post([FromForm] IFormCollection request)
        {
            string email = request["email"];
            Guid uuid = Guid.Parse(request["uuid"]);
            string password = request["password"];
            using(var context = new SasyContext()){
                var user = context.Utentis.Where(b => b.PkEmail == email).First();
                user.Password = password;
                var requestpass = context.RecoveryPasswords.Where(c => c.Uuid == uuid).First();
                context.RecoveryPasswords.Remove(requestpass);
                context.SaveChanges();
                return "1";
            }
        }

    }
}
