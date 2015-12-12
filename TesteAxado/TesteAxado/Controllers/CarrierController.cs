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
using TesteAxado.Commom;

namespace TesteAxado.Controllers
{
    public class CarrierController : BaseController
    {
        //
        // GET: /User/
        [Authorized]
        public ActionResult Index()
        {
            using (var db = new TesteAxadoContext())
            {
                List<CarrierIndex> listCarriers = new List<CarrierIndex>();
                var carriers = db.Carriers.ToList();

                foreach(var carrier in carriers){
                    var rates = db.UsersCarriers.Where(uc => uc.IdCarrier == carrier.Id).ToList();

                    listCarriers.Add(new CarrierIndex()
                    {
                        Id = carrier.Id,
                        Name = carrier.Name,
                        Identifier = carrier.Identifier,
                        AverageRate = rates.Any() ? (float)rates.Sum(r => r.Rate) / rates.Count : 0
                    });
                }

                return View(listCarriers);
            }
        }

        [Authorized]
        public ActionResult Create()
        {
            return View(new Carrier());
        }

        [HttpPost]
        [Authorized]
        public ActionResult Create(Carrier carrier)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(carrier);
                }

                using (var db = new TesteAxadoContext())
                {
                    var existedCarrier = db.Carriers.FirstOrDefault(c => c.Identifier == carrier.Identifier);

                    if (existedCarrier == null)
                    {
                        db.Carriers.Add(carrier);
                        db.SaveChanges();
                        SuccessMessage("Carrier created.");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        WarningMessage("Carrier already exists");
                        return View(carrier);
                    }
                }
            }
            catch
            {
                ErrorMessage("Carrier was not created");
                return View(carrier);
            }
        }

        [HttpGet]
        [Authorized]
        public ActionResult Detail(int id)
        {
            Carrier carrier;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new TesteAxadoContext())
            {
                carrier = db.Carriers.Find(id);

                if (carrier == null)
                {
                    return HttpNotFound();
                }
            }

            return View(carrier);
        }

        [HttpGet]
        [Authorized]
        public ActionResult Update(int id)
        {
            Carrier carrier;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new TesteAxadoContext())
            {
                carrier = db.Carriers.Find(id);

                if (carrier == null)
                {
                    return HttpNotFound();
                }
            }

            return View(carrier);
        }

        [HttpPost]
        [Authorized]
        public ActionResult Update(Carrier carrier)
        {
            if (!ModelState.IsValid)
            {
                return View(carrier);
            }

            try
            {
                using (var db = new TesteAxadoContext())
                {
                    Carrier oldCarrier = db.Carriers.Where(
                        x => x.Id == carrier.Id).SingleOrDefault();

                    if (oldCarrier != null)
                    {
                        db.Entry(oldCarrier).CurrentValues.SetValues(carrier);
                        db.SaveChanges();
                        SuccessMessage("Carrier updated");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
            catch
            {
                ErrorMessage("Carrier was not updated");
                return View(carrier);
            }
        }

        [Authorized]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                using (var db = new TesteAxadoContext())
                {
                    Carrier carrier = db.Carriers.Find(id);

                    if (carrier == null)
                    {
                        return HttpNotFound();
                    }

                    db.Carriers.Remove(carrier);
                    db.SaveChanges();
                }
            }
            catch
            {
                ErrorMessage("Carrier was not deleted");
                return RedirectToAction("Index");
            }

            SuccessMessage("Carrier deleted");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorized]
        public JsonResult GetRate(int id)
        {
            try
            {
                int valueUser = 0; 
                float valueAvg = 0;

                if (id == null)
                {
                    return Json(new { success = false, message = "Get rate is not possible" }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new TesteAxadoContext())
                {
                    var usersCarriers = db.UsersCarriers.Where(uc => uc.IdCarrier == id).ToList();
                    

                    if (usersCarriers != null)
                    {
                        var userCarrier = usersCarriers.FirstOrDefault(uc => uc.IdUser == TesteAxadoSession.LoggedUser.Id);

                        if (userCarrier != null)
                        {
                            valueUser = userCarrier.Rate;
                        }

                        valueAvg = (float)usersCarriers.Sum(u => u.Rate) / usersCarriers.Count;
                    }
                }

                return Json(new
                {
                    success = true,
                    valueUser = valueUser,
                    valueAvg = valueAvg
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, message = "Get rate is not possible" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorized]
        public JsonResult Rating(int id, int value)
        {
            try
            {
                if (id == null || value == null)
                {
                    return Json(new { success = false, message = "Rating is not possible" }, JsonRequestBehavior.AllowGet);
                }

                using (var db = new TesteAxadoContext())
                {
                    var userCarrier = db.UsersCarriers.FirstOrDefault(uc => uc.IdCarrier == id && uc.IdUser == TesteAxadoSession.LoggedUser.Id);

                    if (userCarrier == null){
                        UserCarrier uCarrier = new UserCarrier()
                        {
                            IdCarrier = id,
                            IdUser = TesteAxadoSession.LoggedUser.Id,
                            Rate = value
                        };

                        db.UsersCarriers.Add(uCarrier);
                    }
                    else{
                        userCarrier.Rate = value;
                    }
                    
                    db.SaveChanges();
                }                

                return Json(new
                {
                    success = true,
                    message = "Carrier rated"
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false, message = "Rating was not possible" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
