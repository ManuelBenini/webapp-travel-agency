using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PacchettoViaggioController : ControllerBase
    {
        AgencyContext db;

        public PacchettoViaggioController()
        {
            db = new();
        }

        // GET: api/<PacchettoViaggioController>/Get
        // Restituisce tutti i pacchetti viaggio
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.PacchettiViaggi.ToList());
        }

        // GET api/<PacchettoViaggioController>/Get/5
        // Restituisce un pacchetto viaggio specifico
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.PacchettiViaggi.Find(id));
        }

        // Restituisce Pacchetto con corrispondenza titolo o descrizione
        [HttpGet]
        public IActionResult CercaPacchetto(string userSearch)
        {
            List<PacchettoViaggio> pacchettiViaggi =
                db.PacchettiViaggi.Where(p => p.Titolo.ToLower().Contains(userSearch.ToLower()) 
                || p.Descrizione.ToLower().Contains(userSearch.ToLower())).ToList();
            if (pacchettiViaggi.Count > 0)
            {
                return Ok(pacchettiViaggi);
            }
            else
            {
                return NotFound();
            }
        }

        //// POST api/<PacchettoViaggioController>
        //[HttpPost]
        //public void Post([FromBody] Messaggio formData)
        //{
        //}

        //// PUT api/<PacchettoViaggioController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PacchettoViaggioController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
