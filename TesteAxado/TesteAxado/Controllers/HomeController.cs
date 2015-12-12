using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste2.Controllers;
using TesteAxado.Commom;
using TesteAxado.Context;
using TesteAxado.Models;

namespace TesteAxado.Controllers
{
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            TesteAxadoSession.LogOut();
            return View("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Login))
                {
                    using(var db = new TesteAxadoContext()){
                        User _user = db.Users.FirstOrDefault(u => u.Login == user.Login);

                        if (_user != null)
                        {
                            TesteAxadoSession.LoggedUser = _user;
                        }
                        else
                        {
                            WarningMessage("User not found");
                        }
                    }
                }
                else
                {
                    InformationMessage("Login field is required");
                }

                return View("Index");
            }
            catch
            {
                ErrorMessage("Login not possible");
                return View("Index");
            }
        }
    }
}
