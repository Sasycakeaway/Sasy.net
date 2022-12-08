using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SvelteKitSample.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetordersController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using (var context = new SasyContext())
            {
                var users = context.Ordinis.ToList();
                return JsonConvert.SerializeObject(users);
            }
          
           
        }
            
    }
}
