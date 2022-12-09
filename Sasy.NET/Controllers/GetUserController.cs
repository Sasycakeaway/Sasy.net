using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(string id)
        {
            try
            {
                using (var db = new SasyContext())
                {
                    var users = db.Utentis.ToList();
                    return JsonConvert.SerializeObject(users);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "NOP";
        }

    }
}
