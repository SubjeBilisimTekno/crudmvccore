using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMVCCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;

namespace CrudMVCCore.Controllers
{
    public class RandomController : Controller
    {
     
        // GET: RandomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RandomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RandomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RandomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RandomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RandomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RandomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public  class Beaconx
        {
            public int? Mac { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public string Date { get; set; }
            public int? Rssi1 { get; set; }
            public int? Rssi2 { get; set; }
            public int? Rssi3 { get; set; }
            public int? Rssi4 { get; set; }
        }


        public ActionResult Index()
        {
                var rng = new Random();

            return View(
                Enumerable.Range(1, 16).Select(index => new Beaconx
                {
                    Date = DateTime.Now.ToShortTimeString(),
                    Rssi1 = rng.Next(-50, -10),
                    Rssi2 = rng.Next(-100, -40),
                    Rssi3 = rng.Next(-80, -30),
                    Rssi4 = rng.Next(-50, -30),
                    Mac = rng.Next(40100500, 40101999),
                    Name = Summaries[rng.Next(Summaries.Length)],
                    Type = "ibeacon",
                        //  Name = "Ziyaretci - "+rng.Next(1,10).ToString() ,
                        Location = "Ofis - " + rng.Next(1, 3).ToString()
                }).ToArray()
        );

        }


        private static readonly string[] Summaries = new[]
        {
            "Ziyaretçi-1", "Ziyaretçi-2", "Ziyaretçi-3", "Ziyaretçi-4", "Betül", "Sanem", "Delal", "Göknur", "Hakkı", "Said","Ziyaretçi-5","Ziyaretçi-6","Ziyaretçi-7","Ziyaretçi-8",
            "Personel-1", "Personel-2", "Personel-3", "Personel-4", "Personel-5", "Personel-6","Personel-7","Personel-8","Personel-9","Personel-10","Ziyaretçi-8",
            "Ziyaretçi-9","Ziyaretçi-10","Ziyaretçi-11","Ziyaretçi-12"
        };

    }
}
