using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWMData.Models;

namespace HWMData.Controllers
{
    public class FlowEFController : Controller
    {
        private dbHWMDataEntities db = new dbHWMDataEntities();

        // GET: FlowEF
        public ActionResult Index()
        {
            return View(db.tFlowmeters.ToList());
        }

        // GET: FlowEF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFlowmeter tFlowmeter = db.tFlowmeters.Find(id);
            if (tFlowmeter == null)
            {
                return HttpNotFound();
            }
            return View(tFlowmeter);
        }

        // GET: FlowEF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlowEF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fId,fSerialNo,fDateTime,fDepth,fVelocity,fTemperature,fQuality,fFlow,fDate,fTime")] tFlowmeter tFlowmeter)
        {
            if (ModelState.IsValid)
            {
                db.tFlowmeters.Add(tFlowmeter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tFlowmeter);
        }

        // GET: FlowEF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFlowmeter tFlowmeter = db.tFlowmeters.Find(id);
            if (tFlowmeter == null)
            {
                return HttpNotFound();
            }
            return View(tFlowmeter);
        }

        // POST: FlowEF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fId,fSerialNo,fDateTime,fDepth,fVelocity,fTemperature,fQuality,fFlow,fDate,fTime")] tFlowmeter tFlowmeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tFlowmeter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tFlowmeter);
        }

        // GET: FlowEF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFlowmeter tFlowmeter = db.tFlowmeters.Find(id);
            if (tFlowmeter == null)
            {
                return HttpNotFound();
            }
            return View(tFlowmeter);
        }

        // POST: FlowEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tFlowmeter tFlowmeter = db.tFlowmeters.Find(id);
            db.tFlowmeters.Remove(tFlowmeter);
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
