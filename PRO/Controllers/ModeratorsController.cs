using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using PRO.Models;


namespace PRO.Controllers
{
    public class ModeratorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Moderators
        [Route("moderators/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var moderators = db.Moderators.Include(m => m.User).Include(a => a.User.ApplicationUser).ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, moderators.Count());
            return View(moderators);
        }
        // GET: Moderators
        [Route("moderators/")]
        public ActionResult Index()
        {
            var moderators = db.Moderators.Include(m => m.User);
            return View(moderators.ToList());
        }

        // GET: Moderators/Details/5
        [Route("moderators/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderator moderator = db.Moderators
                .Include(m => m.User)
                .Include(a => a.User.ApplicationUser)
                .SingleOrDefault(a => a.UserId == id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            return View(moderator);
        }

        // GET: Moderators/Create
        [Route("moderators/add")]
        public ActionResult Add()
        {
            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            return View();
        }

        // POST: Moderators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("moderators/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "UserId,CreatedDate,isActive")] Moderator moderator)
        {
            if (ModelState.IsValid)
            {
                var user = db.AppUsers.Include(s => s.ApplicationUser).SingleOrDefault(s => s.Id == moderator.UserId);

                if (moderator.IsActive)
                {
                    UserManager.AddToRole(user.UserId, "Moderator");
                }

                db.Moderators.Add(moderator);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            return View(moderator);
        }

        // GET: Moderators/Edit/5
        [Route("moderators/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderator moderator = db.Moderators.Find(id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            return View(moderator);
        }

        // POST: Moderators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("moderators/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,CreatedDate,LastLoginDate,IsActive")] Moderator moderator)
        {

            if (ModelState.IsValid)
            {
                var user = db.AppUsers.Include(s => s.ApplicationUser).SingleOrDefault(s => s.Id == moderator.UserId);
                var isModerator = UserManager.IsInRole(user.UserId, "Moderator");

                if (isModerator && !moderator.IsActive)
                {
                    UserManager.RemoveFromRole(user.UserId, "Moderator");
                };
                if (!isModerator && moderator.IsActive)
                {
                    UserManager.AddToRole(user.UserId, "Moderator");
                }
                db.Entry(moderator).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(moderator);
        }

        // GET: Moderators/Delete/5
        [Route("moderators/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moderator moderator = db.Moderators.Include(i => i.User).Include(i => i.User.ApplicationUser).SingleOrDefault(i => i.UserId == id);
            if (moderator == null)
            {
                return HttpNotFound();
            }
            return View(moderator);
        }

        // POST: Moderators/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("moderators/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moderator moderator = db.Moderators.Include(s=>s.User).Single(s=>s.UserId ==id);

            var isModerator = UserManager.IsInRole(moderator.User.UserId, "Author");

            if (isModerator)
            {
                UserManager.RemoveFromRole(moderator.User.UserId, "Author");
            };

            db.Moderators.Remove(moderator);
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
