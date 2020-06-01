using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaOsobZaginionych.Models;

namespace ListaOsobZaginionych.Controllers
{
    public class OsobaZaginionaController : Controller
    {
        // GET: OsobaZaginiona
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Gender")
            {
                using (OurDbContext db = new OurDbContext())
                {
                    return View(db.Zaginieci.Where(x => x.Gender == search || search == null).ToList());
                }
            }
            else if (searchBy == "Lokalizacja")
            {
                using (OurDbContext db = new OurDbContext())
                {
                    return View(db.Zaginieci.Where(x => x.Lokalizacja == search || search == null).ToList());
                }
            }
            else
            {
                using (OurDbContext db = new OurDbContext())
                {
                    return View(db.Zaginieci.Where(x => x.Firstname.StartsWith(search) || search == null).ToList());
                }
            }
        }
        public ActionResult Details(int id)
        {
            OurDbContext ourDbContext = new OurDbContext();
            OsobaZaginiona osobaZaginiona = ourDbContext.Zaginieci.Single(emp => emp.UserId == id);

            return View(osobaZaginiona);
        }
        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(OsobaZaginiona zaginiony)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.Zaginieci.Add(zaginiony);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = zaginiony.Firstname + " " + zaginiony.Lastname + " Dodana do listy zagionych";

            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            using (OurDbContext edit = new OurDbContext())
            {
                return View(edit.Zaginieci.Where(x => x.UserId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, OsobaZaginiona zaginiona)
        {
            try
            {
                using(OurDbContext edit = new OurDbContext())
                {
                    edit.Entry(zaginiona).State = EntityState.Modified;
                    edit.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (OurDbContext delete = new OurDbContext())
            {
                return View(delete.Zaginieci.Where(x => x.UserId == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, OsobaZaginiona zaginiona)
        {
            try
            {
                using (OurDbContext delete = new OurDbContext())
                {
                    zaginiona = delete.Zaginieci.Where(x => x.UserId == id).FirstOrDefault();
                    delete.Zaginieci.Remove(zaginiona);
                    delete.SaveChanges();
                }
            return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}