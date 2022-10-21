using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class PacchettoViaggioController : Controller
    {
        AgencyContext db;
        public PacchettoViaggioController()
        {
            db = new();
        }

        public IActionResult Index()
        {
            List<PacchettoViaggio> pacchettiViaggi = db.PacchettiViaggi.ToList();

            return View(pacchettiViaggi);
        }

        public IActionResult Show(int id)
        {
            PacchettoViaggio pacchettoViaggio = db.PacchettiViaggi.Where(p => p.Id == id).Include("Messaggi").First();

            return View(pacchettoViaggio);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(PacchettoViaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            db.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PacchettoViaggio pacchettoViaggio = db.PacchettiViaggi.Find(id);

            if (pacchettoViaggio == null)
            {
                return NotFound("Non è stato possibile trovare il pacchetto viaggio da modificare");
            }
            else
            {
                return View(pacchettoViaggio);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PacchettoViaggio model)
        {

            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            PacchettoViaggio pacchettoViaggio = db.PacchettiViaggi.Find(id);

            pacchettoViaggio.Titolo = model.Titolo;
            pacchettoViaggio.Localita = model.Localita;
            pacchettoViaggio.Immagine = model.Immagine;
            pacchettoViaggio.Descrizione = model.Descrizione;
            pacchettoViaggio.Prezzo = model.Prezzo;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PacchettoViaggio pacchettoViaggio = db.PacchettiViaggi.Find(id);

            if (pacchettoViaggio == null)
            {
                return NotFound();
            }
            else
            {
                db.PacchettiViaggi.Remove(pacchettoViaggio);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        public FileResult Esporta()
        {
            string[] columnNames = new string[] { "ID", "Titolo", "Descrizione", "Località", "Prezzo", "Immagine" };
            List<PacchettoViaggio> viaggi = db.PacchettiViaggi.ToList();

            string csv = string.Empty;

            foreach (string columnName in columnNames)
            {
                csv += columnName + ',';
            }

            csv += "\r\n";

            foreach (PacchettoViaggio pacchettoViaggio in viaggi)
            {
                csv += pacchettoViaggio.Id.ToString().Replace(",", ";") + ',';
                csv += pacchettoViaggio.Titolo.Replace(",", ";") + ',';

                if (pacchettoViaggio.Descrizione != null)
                {
                    csv += pacchettoViaggio.Descrizione.Replace(",", ";") + ',';
                }
                else
                {
                    csv += "" + ',';
                }

                csv += ',';
                csv += pacchettoViaggio.Prezzo.ToString().Replace(",", ";") + ',';
                csv += pacchettoViaggio.Immagine.Replace(",", ";") + ',';

                csv += "\r\n";
            }

            byte[] bytes = Encoding.ASCII.GetBytes(csv);
            return File(bytes, "text/csv", "PacchettoViaggio.csv");
        }
    }
}
