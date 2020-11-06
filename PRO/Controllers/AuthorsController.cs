using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PRO.Models;

namespace PRO.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
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

        // GET: Authors
        [Route("authors/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var authors = db.Authors.Include(a => a.User).Include(a => a.User.ApplicationUser).ToList();

            ViewBag.Pagination = new Pagination(pageString, itemString, authors.Count());
            return View(authors);
        }

        // GET: Authors/Details/5
        [Route("authors/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(i => i.User).Include(i => i.User.ApplicationUser).SingleOrDefault(i => i.UserId == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        [Route("authors/add")]
        public ActionResult Add()
        {

            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();

            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("authors/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "UserId,FirstName,LastName,CreatedDate,isActive")] Author author)
        {
            if (ModelState.IsValid)
            {
                var user = db.AppUsers.Include(s => s.ApplicationUser).SingleOrDefault(s => s.Id == author.UserId);
                
                if (author.IsActive)
                {
                    UserManager.AddToRole(user.UserId, "Author");
                }

                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            var users = db.AppUsers.Include(i => i.ApplicationUser).ToList();
            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();
           
            return View(author);
        }

        // GET: Authors/Edit/5
        [Route("authors/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("authors/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,CreatedDate")] Author author)
        {
            if (ModelState.IsValid)
            {
                var user = db.AppUsers.Include(s => s.ApplicationUser).SingleOrDefault(s => s.Id == author.UserId);
                var isAuthor = UserManager.IsInRole(user.UserId, "Author");
                
                if (isAuthor && !author.IsActive)
                {
                    UserManager.RemoveFromRole(user.UserId, "Moderator");
                };
                if (!isAuthor && author.IsActive)
                {
                    UserManager.AddToRole(user.UserId, "Moderator");
                }

                db.Entry(author).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        [Route("authors/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Include(i=>i.User).Include(i => i.User.ApplicationUser).SingleOrDefault(i=>i.UserId==id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("authors/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Include(s => s.User).Single(s => s.UserId == id);
           
            var isAuthor = UserManager.IsInRole(author.User.UserId, "Author");

            if (isAuthor)
            {
                UserManager.RemoveFromRole(author.User.UserId, "Author");
            };

            db.Authors.Remove(author);
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
