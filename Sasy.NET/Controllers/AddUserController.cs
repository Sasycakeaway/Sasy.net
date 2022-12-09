using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Sasy.NET.AES;

namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes("application/x-www-form-urlencoded")]
    public class AdduserController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public string Post([FromForm] IFormCollection value)
        {
            var key = System.Configuration.ConfigurationManager.AppSettings.Get("DecryptionKey");
            string cf = AesOperation.EncryptString(key,value["cf"]);
            string nascita = AesOperation.EncryptString(key, value["nascita"]);
            string telefono = AesOperation.EncryptString(key, value["telefono"]);
            string email = value["email"];
            string password = value["password"];
            string timestamp = value["timestamp"];
            Guid token = new Guid();

            if (value["token"] != "null")
            {
                token = Guid.Parse(value["token"]);
            }
            else
            {
                token = Guid.Empty;
            }
            
            bool news = Boolean.Parse(value["news"]);

            if(cf == null || nascita == null || telefono == null || email == null || password == null || timestamp == null)
            {
                return "0";
            }
            else
            {
                try
                {
                    using (var db = new SasyContext())
                    {

                        var user = new Utenti();
                        user.Cf = cf;
                        user.Nascita = nascita;
                        user.Telefono = telefono;
                        user.PkEmail = email;
                        user.Password = password;
                        user.Timestamp = DateTime.Parse(timestamp);
                        user.News = new byte[Convert.ToByte(news)];
                        db.Add(user);
                        db.SaveChanges();

                        if (news == true)
                        {
                            var news_token = new Newsletter();
                            news_token.PkToken = token;
                            news_token.FkEmail = email;
                            db.Add(news_token);
                            db.SaveChanges();
                        }



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
}
