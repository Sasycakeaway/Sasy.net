using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sasy.NET.Model
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public string GetCart()
        {
            string? email = Request.Cookies["username"];
            string? password = Request.Cookies["password"];

            using (var context = new SasyContext())
            {
                try
                {
                    context.Utentis.Where(utente => utente.PkEmail == email).Where(utente => utente.Password == password).First();   // Trigger trycatch if no record is present
                    List<Cart> cart = context.Carts.Where(prod => prod.Email == email).ToList();
                    List<Cart_Response> cart_response = new List<Cart_Response>();
                    foreach (var cart_obj in cart)
                    {
                        var cart_process = new Cart_Response
                        {
                            prodotto = cart_obj.Prodotto,
                            qty = cart_obj.Qty,
                            costo = cart_obj.Costo
                        };
                        cart_response.Add(cart_process);
                    }

                    return JsonConvert.SerializeObject(cart_response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "[]";
                }

            }
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public bool add_product([FromForm] IFormCollection value)
        {
            try
            {
                string prodotto = value["prodotto"];
                string email = Request.Cookies["username"];
                int qty = int.Parse(value["qty"]);
                int costo = int.Parse(value["costo"]);
                
                using (var context = new SasyContext())
                {
                    try
                    {
                        var prod_db = context.Carts.Where(prod => prod.Prodotto == prodotto).Where(prod => prod.Email == email).First();
                        prod_db.Qty += qty;
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        var prod = new Cart()
                        {
                            Prodotto = prodotto,
                            Qty = qty,
                            Costo = costo,
                            Email = email
                        };
                        context.Carts.Add(prod);
                        context.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpDelete]
        [Consumes("application/x-www-form-urlencoded")]
        public bool delete_prod([FromForm] IFormCollection value)
        {
            try
            {
                using (var context = new SasyContext())
                {
                    string? email = Request.Cookies["username"];

                    if (Boolean.Parse(value["all"]))
                    {
                        List<Cart> all_prod_email = context.Carts.Where(prod => prod.Email == email).ToList();
                        context.Carts.RemoveRange(all_prod_email);
                        context.SaveChanges();
                    }
                    else
                    {
                        string prod = value["prodotto"];
                        Cart prodotto = context.Carts.Where(product => product.Prodotto == prod).First();
                        if (prodotto.Qty == 1 || Boolean.Parse(value["nuke"]))
                            context.Carts.Remove(prodotto);
                        else
                        {
                            prodotto.Qty--;
                        }
                        context.SaveChanges();   
                    }

                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}

