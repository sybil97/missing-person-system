using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListaOsobZaginionych.Models;

namespace ListaOsobZaginionych.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using(OurDbContext db = new OurDbContext())
                {
                    db.Users.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Firstname + " " + account.Lastname + " Rejestracja zakończona pomyślnie";
                    
            }
            return View();
        }
        //Logowanie
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(OurDbContext db = new OurDbContext())
            {
                var usr = db.Users.Single(u => u.Username == user.Username && u.Password == user.Password);
                if(usr != null)
                {
                   if(usr.IsAdmin == true)
                    {
                        Session["UserIdAdmin"] = usr.UserId.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        if (usr.ConfirmRegistration == true)
                        {
                            Session["UserID"] = usr.UserId.ToString();
                            Session["Username"] = usr.Username.ToString();
                            return RedirectToAction("LoggedIn");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Konto nie zostało zweryfikowane");
                        }
                    }
                        
                }
                else
                {
                    ModelState.AddModelError("", "Logi lub hasło jest nieprawidłowe");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserIdAdmin"] != null)
            {
                return View();
            }
            else if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Edit(int id)
        {
            using (OurDbContext edit = new OurDbContext())
            {
                return View(edit.Users.Where(x => x.UserId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, UserAccount user)
        {
            try
            {
                using (OurDbContext edit = new OurDbContext())
                {
                    edit.Entry(user).State = EntityState.Modified;
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
                return View(delete.Users.Where(x => x.UserId == id).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, UserAccount user)
        {
            try
            {
                using (OurDbContext delete = new OurDbContext())
                {
                    user = delete.Users.Where(x => x.UserId == id).FirstOrDefault();
                    delete.Users.Remove(user);
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