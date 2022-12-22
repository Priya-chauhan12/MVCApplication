using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private PlacementDBEntities db = new PlacementDBEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(string sname,string password)
        {
            string url = string.Empty;
            try
            {
                if(sname != null && password != null){
                    if(sname == "Admin" && password == "Admin")
                    {
                       return RedirectToAction("Index");
                    }
                    else
                    {
                        var finduser = db.Students.Where(u => u.sname == sname && u.spassword == password).ToList();
                        if (finduser.Count != 0)
                        {
                            Session["sname"] = finduser[0].sname;
                            Session["spassword"] = finduser[0].spassword;
                            Session["sid"] = finduser[0].sid;
                            Session["sgender"] = finduser[0].sgender;
                            Session["scno"] = finduser[0].scno;
                            Session["semail"] = finduser[0].semail;
                            Session["sdob"] = finduser[0].sdob;
                            Session["saddress"] = finduser[0].saddress;
                            Session["sssc"] = finduser[0].sssc;
                            Session["shsc"] = finduser[0].shsc;
                            Session["scpi"] = finduser[0].scpi;
                            Session["sspi"] = finduser[0].sspi;
                            Session["srollno"] = finduser[0].srollno;
                            Session["sskill"] = finduser[0].sskill;
                            Session["sbranch"] = finduser[0].sbranch;
                            Session["stype"] = finduser[0].stype;
                            Session["srank"] = finduser[0].srank;
                            return RedirectToAction("About");
                        }
                        else
                        {
                            ViewBag.message = "Username and Password is incorrect!!";
                        }
                    }
                    
                }
            }
            catch(Exception e)
            {
                ViewBag.message = e.Message;
            }
            return View("Login");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}