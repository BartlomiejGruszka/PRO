using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRO.Models;

namespace PRO.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Status
        [Route("status/manage")]
        public ActionResult Manage()
        {var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];
            var statuses = _context.Statuses.ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, statuses.Count());
            return View(statuses);
        }

        // GET: Status/Details/5
        [Route("status/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = _context.Statuses.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: Status/add
        [Route("status/add")]
        public ActionResult Add()
        {
            return View();
        }

        // POST: Status/Create
        
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("status/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Name")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Statuses.Add(status);
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }

            return View(status);
        }

        // GET: Status/Edit/5
        [Route("status/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = _context.Statuses.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("status/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(status).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(status);
        }

        // GET: Status/Delete/5
        [Route("status/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = _context.Statuses.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("status/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status status = _context.Statuses.Find(id);
            _context.Statuses.Remove(status);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
