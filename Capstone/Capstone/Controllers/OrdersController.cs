using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private OrderDBContext db = new OrderDBContext();
        private DraftDBContext Db = new DraftDBContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }


        // GET: Orders/Create
        public ActionResult Create()
        {
            OrderModel model = new OrderModel();
            model.Date = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderId,Date,NumBadge,AccountNbr,AccountName1,AccountName2,Fname,Lname,IDNbr,HolderType,Neutron,WLocation,UPD,Sname,ClipType,SeriesColor,FreqColor,BadgeUse")] OrderModel orderModel)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    db.Orders.Add(orderModel);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nestingC:\Users\Dane\Documents\GitHub\TLDForm\Capstone\Capstone\Models\ManageViewModels.cs
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }


                return RedirectToAction("Index");
            }

            return View(orderModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Draft([Bind(Include = "orderId,Date,NumBadge,AccountNbr,AccountName1,AccountName2,Fname,Lname,IDNbr,HolderType,Neutron,WLocation,UPD,Sname,ClipType,SeriesColor,FreqColor,BadgeUse")] DraftsModel draftModel)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    Db.Drafts.Add(draftModel);
                    Db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nestingC:\Users\Dane\Documents\GitHub\TLDForm\Capstone\Capstone\Models\ManageViewModels.cs
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }


                return RedirectToAction("Index");
            }

            return View(draftModel);
        }
        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }


        public ActionResult Clone(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Clone([Bind(Include = "orderId,AccountNbr,AccountName1,AccountName2,Fname,Lname,IDNbr,HolderType,Neutron,WLocation,UPD,Sname,ClipType,SeriesColor,FreqColor,BadgeUse")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orderModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderModel);
        }





        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderId,AccountNbr,AccountName1,AccountName2,Fname,Lname,IDNbr,HolderType,Neutron,WLocation,UPD,Sname,ClipType,SeriesColor,FreqColor,BadgeUse")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderModel);
        }

        

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel orderModel = db.Orders.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderModel orderModel = db.Orders.Find(id);
            db.Orders.Remove(orderModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
