using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Clinic4.Models;

namespace Clinic4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Authenticate()
        {
            return View("Login1");
        }

        public ActionResult Validate()
        {
            ModelClinic context = new ModelClinic();
            string username = Request.Form["UserName"].Trim();
            string password = Request.Form["Password"].Trim();
            List<user> users = (from u in context.users
                                where ((u.UserName == username) && (u.LoginPassWord == password))
                                select u).ToList<user>();
            if (users.Count == 1)
            {
                FormsAuthentication.SetAuthCookie("Cookie", true);
                var u = users[0];

                if (u.UserRole == "Admin")
                {
                    ViewData["UserRole"] = u.UserRole;
                    return View("~/Views/Home/Admin.cshtml");
                }
                else if (u.UserRole == "Doctor")
                {
                    //TempData["DoctorId"] = u.DoctorId;
                    Session["DoctorId"] = u.DoctorId;

                    return View("~/Views/Home/Doctor.cshtml");
                }
                else
                {
                    patient patient = (from p in context.patients where p.Id == u.PatientId select p).SingleOrDefault();
                    ViewData["PatientId"] = patient.Id;

                    // cant pass object with redirect to action, so adding it to TempData
                    // probably not a safe way to do this since it contains sensitive data?
                    //TempData["Patient"] = patient;

                    System.Web.HttpContext.Current.Session["UserId"] = patient.Id;
                    return RedirectToAction("Patient", "Home", new { id = patient.Id });
                    //return View("~/Views/Home/Patient.cshtml", patient);
                }

            }
            else
            {
                TempData["notice"] = "login is not correct";
                return View("Login1");

            }
        }
    }
}