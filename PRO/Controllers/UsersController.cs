using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace PRO.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;


        public UsersController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: Users
        [Route("users/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var users = _context.AppUsers.Include(a => a.ApplicationUser).Include(i=>i.Image).ToList();

            ViewBag.Pagination = new Pagination(pageString, itemString, users.Count());
            return View(users);
        }

        [Route("users/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Route("users/add")]
        public ActionResult Add()
        {
            //modify view to load register partial view

            return View();
        }

        [HttpPost]
        [Route("users/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "UserId,FirstName,LastName,CreatedDate")] Author author)
        {
            //not sure if its needed at all with built-in register
            return View();
        }


        [Route("users/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("users/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( User user)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(user);
        }

        // GET: Authors/Delete/5
        [Route("users/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _context.AppUsers.Include(a => a.ApplicationUser).SingleOrDefault(i => i.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("users/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _context.AppUsers.Find(id);
            var userid = user.UserId;
           // _context.AppUsers.Remove(user);

            //remove applicationUser too right here
            _context.SaveChanges();
            return RedirectToAction("DeleteUser","Manage",new {userId = userid});
        }



        [Route("users/{id}/lists")]
        public ActionResult UserGameList(int id)
        {

            return View();
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