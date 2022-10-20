using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacchettoViaggioController : ControllerBase
    {
        AgencyContext db;

        public PacchettoViaggioController()
        {
            db = new();
        }

        // GET: api/<GuestsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.PacchettiViaggi.ToList());
        }

        //// GET api/<GuestsController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok(db.PacchettiViaggi.Find(id));
        //}

        //// Restituisce Pacchetto con corrispondenza titolo o descrizione
        //[HttpGet]
        //public IActionResult CercaPacchettoViaggio(string userSearch)
        //{
        //    List<PacchettoViaggio> pacchettiViaggiTitolo = db.PacchettiViaggi.Where(p => p.Titolo.ToLower().Contains(userSearch.ToLower())).ToList();
        //    if (pacchettiViaggi.Count > 0)
        //    {
        //        return Ok(pacchettiViaggi);
        //    }
        //    else
        //    {
        //        List<PacchettoViaggio> pacchettiViaggiDescrizione = db.PacchettiViaggi.Where(p => p.Descrizione.ToLower().Contains(userSearch.ToLower())).ToList();
        //    }
            

        //    return Ok(pizzas);
        //}

        //// POST api/<GuestsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<GuestsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GuestsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
