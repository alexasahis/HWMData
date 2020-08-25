using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using HWMData.Models;

namespace HWMData.Controllers
{
    public class FlowController : Controller
    {
        dbHWMDataEntities db = new dbHWMDataEntities();

        // GET: Flow
        public ActionResult Index(int? page)
        {
            var lFlowmeters = db.tFlowmeters.OrderByDescending(m => m.fId).ToList();

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfFlowmeters = lFlowmeters.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize
            ViewBag.OnePageOfFlowmeters = onePageOfFlowmeters;

            return View(onePageOfFlowmeters);
        }

        // GET: Flow/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flow/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flow/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Flow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flow/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
