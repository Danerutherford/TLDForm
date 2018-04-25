using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using Microsoft.AspNet.Identity;
using System.IO;

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
                    orderModel.OrderStatus = "Draft";
                    db.Orders.Add(orderModel);
                    db.SaveChanges();

                    //string xml = "";
                    //xml += "<Order>";
                    //xml += "<orderId>" + orderModel.orderId + "</orderId>";
                    //xml += "</Order>";

                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(orderModel.GetType());
                    //var sr = new StreamWriter("data.xml");
                    var xml = ""; // System.IO.File.ReadAllText("data.xml") 
                    using (StringWriter sr = new StringWriter())
                    {
                        xs.Serialize(sr, orderModel);
                        xml = sr.ToString();
                        //xml = Server.HtmlEncode(xml); // < >
                    }


                    
                    

                    

                    //var body = "<p>Email From: {0} ({1})</p><p>Here is the xml!</p><p>{2}</p>" + xml;
                    var body = "Here is the xml!\n\n" + xml;
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("aaronchestnut@gmail.com"));  // replace with valid value 
                    message.From = new MailAddress("testcapstonetest@gmail.com");  // replace with valid value
                    message.Subject = "XML File";
                    message.Body = string.Format(body, "TLD Admin", "testcapstonetest@gmail.com", "File Attached");
                    message.IsBodyHtml = false;

                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "testcapstonetest@gmail.com",  // replace with valid value
                            Password = "qeadzc1!"  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                        //smtp.SendMailAsync(message);
                        //return RedirectToAction("Sent");
                    }

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

        public ActionResult Submit()
        {

            var drafts = db.Orders.Where(o => o.OrderStatus == "Draft").ToList();

            foreach (var item in drafts)
            {
                item.OrderStatus = "Submitted";
            }

            db.SaveChanges();


            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(drafts.GetType());
            //var sr = new StreamWriter("data.xml");
            var xml = ""; // System.IO.File.ReadAllText("data.xml") 
            using (StringWriter sr = new StringWriter())
            {
                xs.Serialize(sr, drafts);
                xml = sr.ToString();
                //xml = Server.HtmlEncode(xml); // < >
            }

            


            //var body = "<p>Email From: {0} ({1})</p><p>Here is the xml!</p><p>{2}</p>" + xml;
            var body = "Here is the xml!\n\n" + xml;
            var message = new MailMessage();
            message.To.Add(new MailAddress("danerutherford94@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("testcapstonetest@gmail.com");  // replace with valid value
            message.Subject = "XML File";
            message.Body = string.Format(body, "TLD Admin", "testcapstonetest@gmail.com", "File Attached");
            message.IsBodyHtml = false;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "testcapstonetest@gmail.com",  // replace with valid value
                    Password = "qeadzc1!"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                //smtp.SendMailAsync(message);
                //return RedirectToAction("Sent");
            }

            return View();
        }

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
