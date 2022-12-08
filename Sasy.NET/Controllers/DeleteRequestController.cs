using Microsoft.AspNetCore.Mvc;

namespace SvelteKitSample.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteRequestController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(string id)
        {
            try
            {
                using (var db = new SasyContext())
                {
                    var RecoveryToRemove = db.RecoveryPasswords.Single(x => x.Uuid == Guid.Parse(id));
                    db.RecoveryPasswords.Remove(RecoveryToRemove);
                    db.SaveChanges();
                    return "1";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "0";
            }
        }

    }
}
