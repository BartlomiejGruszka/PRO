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
    public class PlatformsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Platforms
        [Route("platforms/")]
        public ActionResult Index()
        {
            var platforms = db.Platforms.Include(p => p.Company);
            return View(platforms.ToList());
        }
        // GET: Platforms
        [Route("platforms/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var platforms = db.Platforms.Include(p => p.Company).ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, platforms.Count());

            return View(platforms);
        }

        // GET: Platforms/Details/5
        [Route("platforms/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = db.Platforms.Include(p => p.Company).SingleOrDefault(s=>s.Id==id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // GET: Platforms/Create
        [Route("platforms/add")]
        public ActionResult Add()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            return View();
        }

        // POST: Platforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("platforms/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Name,ReleaseDate,IsActive,CompanyId")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Platforms.Add(platform);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", platform.CompanyId);
            return View(platform);
        }

        // GET: Platforms/Edit/5
        [Route("platforms/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = db.Platforms.Include(p => p.Company).SingleOrDefault(s => s.Id == id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", platform.CompanyId);
            return View(platform);
        }

        // POST: Platforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("platforms/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ReleaseDate,IsActive,CompanyId")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", platform.CompanyId);
            return View(platform);
        }

        // GET: Platforms/Delete/5
        [Route("platforms/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = db.Platforms.Include(p => p.Company).SingleOrDefault(s => s.Id == id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Platforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("platforms/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Platform platform = db.Platforms.Find(id);
            db.Platforms.Remove(platform);
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
