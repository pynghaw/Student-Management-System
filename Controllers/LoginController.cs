using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class LoginController : Controller
    {
        db_smsEntities db = new db_smsEntities();


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tb_user objchk)
        {
            if (ModelState.IsValid)
            {
                using(db_smsEntities db = new db_smsEntities())
                {
                    var obj = db.tb_user.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");

                    }

                    else
                    {
                        ModelState.AddModelError("", "The Username or Password Incorrect");
                    }
                }
            }                    

                return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}