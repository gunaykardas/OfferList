using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : ControllerBase
    {
       

        UmulyDbContext db=new UmulyDbContext();


         [HttpGet(Name = "GetOffer")]
        [EnableCors("policy1")]
        public string Get()
        {
           
            var response = db.Offers.FromSqlRaw("EXECUTE OfferList").ToList();
            return JsonConvert.SerializeObject(response);

        }


        [HttpPost]
        [EnableCors("policy1")]
        public IActionResult Post(Offer offer)
        {
            try {

                if (!ModelState.IsValid)
                {
                    return Ok();
                }
                else
                {
                    string query = String.Format("EXECUTE OfferAdd @Mode='{0}', @MovementType={1}, @Incoterm={2}, @Country='{3}', @City='{4}', @PackageType='{5}',  @Unit1='{6}',  @Unit1Value={7},  @Unit2='{8}', @Unit2Value={9}, @Currency='{10}', @Price='{11}'",

                        offer.Mode,
                        offer.MovementType,
                        offer.Incoterm,
                        offer.Country,
                        offer.City,
                        offer.PackageType,
                        offer.Unit1,
                        offer.Unit1Value.ToString().Replace(",", "."),
                        offer.Unit2,
                        offer.Unit2Value.ToString().Replace(",", "."),
                        offer.Currency,
                        offer.Price.ToString().Replace(",", ".")


                        );
                    db.Database.ExecuteSqlRaw(query);
                    db.SaveChanges();
                    return Ok("200");

                }
            }
            catch
            {
                return Ok();
            }
            }
       



    }
}