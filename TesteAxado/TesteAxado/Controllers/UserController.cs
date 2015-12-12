using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteAxado.Models;
using TesteAxado.Context;
using Teste2.Controllers;
using TesteAxado.Filters;

namespace TesteAxado.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        [Authorized]
        public ActionResult Index()
        {
            using (var db = new TesteAxadoContext())
            {
                var users = db.Users.ToList();

                return View(users);
            }
        }

        [Authorized]
        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        [Authorized]
        public ActionResult Create(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }

                using (var db = new TesteAxadoContext())
                {
                    var existedUser = db.Users.FirstOrDefault(u => u.Login == user.Login);

                    if (existedUser == null)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        SuccessMessage("User created.");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        WarningMessage("User already exists");
                        return View(user);
                    }
                }
            }
            catch
            {
                ErrorMessage("User was not created");
                return View(user);
            }
        }
    }
}
