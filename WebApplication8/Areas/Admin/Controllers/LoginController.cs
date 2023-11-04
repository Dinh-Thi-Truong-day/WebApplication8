using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Areas.Models;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(WebApplication8.Areas.Models.User userModel)
        {
            using (LoginDataBaseEntities1 db = new LoginDataBaseEntities1())
            {
                var userDeatails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDeatails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserID"] = userDeatails.UserID;
                    return RedirectToAction("index", "Home");
                }
            }
            return View();
        }
    }
}
