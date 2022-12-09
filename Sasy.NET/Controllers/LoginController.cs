using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
using Sasy.NET.AES;

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
                        var user_cookies = new CookieOptions();
                        user_cookies.Expires = DateTime.Now.AddDays(30);   // 1 month
                        user_cookies.Path = "/";
                        Response.Cookies.Append("username", user.PkEmail, user_cookies);
                        var sha_encrypter = new SHA256_Calculator();
                        var password_cookies = new CookieOptions();
                        password_cookies.Expires = DateTime.Now.AddDays(30); // 1 month
                        password_cookies.Path = "/";
                        Response.Cookies.Append("password", user.Password, password_cookies);
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
