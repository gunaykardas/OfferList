using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailsController : ControllerBase
    {


        UmulyDbContext db = new UmulyDbContext();


        [HttpGet("{id}")]
        [EnableCors("policy1")]
        public string Get(int id)
        {
           
            var response = db.Offers.FromSqlRaw($"OfferList {id}").ToList();
            return JsonConvert.SerializeObject(response);

        }



    }
}