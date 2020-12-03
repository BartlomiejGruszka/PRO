using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRO.Models;
using PRO.Helpers;

namespace PRO.Controllers
{
    [Authorize]
    public class UserListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserLists
        [Route("userlists/manage")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var userlists = db.GetUsersListList();

            ViewBag.Pagination = new Pagination(pageString, itemString, userlists.Count());

            return View(userlists.ToList());
        }

        // GET: UserLists/Details/5
        [Route("userlists/details/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.GetFullUsersListForm((int)id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // GET: UserLists/Create
        [Route("userlists/add")]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var users = db.AppUsers.Include(s => s.ApplicationUser).ToList();

            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();
            ViewBag.typesList = db.ListTypes.ToList();
            return View();
        }

        // POST: UserLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("userlists/add")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,CreatedDate,Name,IsPublic,UserId,ListTypeId")] UserList userList)
        {
            if (ModelState.IsValid)
            {
                db.UserLists.Add(userList);
                db.SaveChanges();
                return RedirectToAction("Manage");
            }

            var users = db.AppUsers.Include(s => s.ApplicationUser).ToList();

            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();
            ViewBag.typesList = db.ListTypes.ToList();
            return View(userList);
        }

        // GET: UserLists/Edit/5
        [Route("userlists/edit/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.GetFullUsersListForm((int)id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            var users = db.AppUsers.Include(s => s.ApplicationUser).ToList();

            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();
            ViewBag.typesList = db.ListTypes.ToList();
            return View(userList);
        }

        // POST: UserLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin,Moderator")]
        [Route("userlists/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedDate,Name,IsPublic,UserId,ListTypeId")] UserList userList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            var users = db.AppUsers.Include(s => s.ApplicationUser).ToList();

            ViewBag.usersList = users.Select(s => new { Id = s.Id, UserName = s.ApplicationUser.UserName }).ToList();
            ViewBag.typesList = db.ListTypes.ToList();
            return View(userList);
        }

        // GET: UserLists/Delete/5
        [Route("userlists/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.GetFullUsersListForm((int)id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // POST: UserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [Route("userlists/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserList userList = db.GetFullUsersListForm((int)id);
            db.UserLists.Remove(userList);
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
