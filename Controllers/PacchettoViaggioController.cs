﻿using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class PacchettoViaggioController : Controller
    {
        AgencyContext db;
        public PacchettoViaggioController()
        {
            db = new();
        }

        public IActionResult Index()
        {
            return View();
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

            return View(Index);
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
                return View();
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
            pacchettoViaggio.Località = model.Località;
            pacchettoViaggio.Descrizione = model.Descrizione;
            pacchettoViaggio.Prezzo = model.Prezzo;

            db.SaveChanges();

            return View("Index");
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

                return View("Index");
            }

        }
    }
}
