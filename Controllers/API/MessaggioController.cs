using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessaggioController : ControllerBase
    {
        AgencyContext db;

        public MessaggioController()
        {
            db = new();
        }

        // POST api/<MessaggioController>/Post
        [HttpPost]
        public IActionResult Post([FromBody] Messaggio formData)
        {
            db.Messaggi.Add(formData);
            db.SaveChanges();

            return Ok();
        }
    }
}
