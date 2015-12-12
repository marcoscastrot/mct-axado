using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteAxado.Models;

namespace TesteAxado.Commom
{
    public class TesteAxadoSession
    {
        public static void LogOut()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        public static User LoggedUser
        {
            get { return HttpContext.Current.Session["loggedUser"] == null ? new User() : (User)(HttpContext.Current.Session["loggedUser"]); }
            set { HttpContext.Current.Session["loggedUser"] = value; }
        }

        public static bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.Session["loggedUser"] != null;
            }
        }
    }
}