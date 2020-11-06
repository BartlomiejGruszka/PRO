using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PRO.Models
{
    [Authorize]
    public class ListTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListTypes
        [Route("listtypes/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var listTypes = db.ListTypes.ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, listTypes.Count());

            return View(listTypes);
        }

        // GET: ListTypes/Details/5
        [Route("listtypes/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListType listType = db.ListTypes.Find(id);
            if (listType == null)
            {
                return HttpNotFound();
            }
            return View(listType);
        }

        // GET: ListTypes/Create
        [Route("listtypes/add")]
        public ActionResult Add()
        {
            return View();
        }

        // POST: ListTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("listtypes/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Name")] ListType listType)
        {
            if (ModelState.IsValid)
            {
                db.ListTypes.Add(listType);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            return View(listType);
        }

        // GET: ListTypes/Edit/5
        [Route("listtypes/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListType listType = db.ListTypes.Find(id);
            if (listType == null)
            {
                return HttpNotFound();
            }
            return View(listType);
        }

        // POST: ListTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("listtypes/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ListType listType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(listType);
        }

        // GET: ListTypes/Delete/5
        [Route("listtypes/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListType listType = db.ListTypes.Find(id);
            if (listType == null)
            {
                return HttpNotFound();
            }
            return View(listType);
        }

        // POST: ListTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("listtypes/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListType listType = db.ListTypes.Find(id);
            db.ListTypes.Remove(listType);
            db.SaveChanges();
            return RedirectToAction("Manage");
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
