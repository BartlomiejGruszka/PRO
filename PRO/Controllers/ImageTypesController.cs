using PRO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PRO.Controllers
{
    public class ImageTypesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ImageTypes
        [Route("ImageTypes/")]
        public ActionResult Index()
        {
            return View(db.ImageTypes.ToList());
        }
        [Route("ImageTypes/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];
            var ImageTypes = db.ImageTypes.ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, ImageTypes.Count());

            return View(ImageTypes);
        }

        // GET: ImageTypes/Details/5
        [Route("ImageTypes/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageType ImageType = db.ImageTypes.Find(id);
            if (ImageType == null)
            {
                return HttpNotFound();
            }
            return View(ImageType);
        }

        // GET: ImageTypes/add
        [Route("ImageTypes/add")]
        public ActionResult Add()
        {
            return View();
        }

        // POST: ImageTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("ImageTypes/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Name")] ImageType ImageType)
        {
            if (ModelState.IsValid)
            {
                db.ImageTypes.Add(ImageType);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            return View(ImageType);
        }

        // GET: ImageTypes/Edit/5
        [Route("ImageTypes/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageType ImageType = db.ImageTypes.Find(id);
            if (ImageType == null)
            {
                return HttpNotFound();
            }
            return View(ImageType);
        }

        // POST: ImageTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("ImageTypes/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ImageType ImageType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ImageType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(ImageType);
        }

        // GET: ImageTypes/Delete/5
        [Route("ImageTypes/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageType ImageType = db.ImageTypes.Find(id);
            if (ImageType == null)
            {
                return HttpNotFound();
            }
            return View(ImageType);
        }

        // POST: ImageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("ImageTypes/delete/{id}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageType ImageType = db.ImageTypes.Find(id);
            db.ImageTypes.Remove(ImageType);
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

