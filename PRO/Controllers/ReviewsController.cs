using PRO.Models;
using PRO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Data.Entity;
using PRO.Helpers;

namespace PRO.Controllers
{
    //[Authorize]
    public class ReviewsController : Controller
    {
        private ApplicationDbContext _context;


        public ReviewsController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("reviews/")]
        public ActionResult Index()
        {
            return View(_context.Reviews.ToList());
        }

        [Route("reviews/manage")]
        [Authorize(Roles ="Admin,Moderator")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];
            var reviews = _context.GetReviewsList();
            ViewBag.Pagination = new Pagination(pageString, itemString, reviews.Count());

            return View(reviews);
        }
       // [Authorize]
        [Route("reviews/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: reviews/Details/5
        [Route("reviews/details/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult ManageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _context.GetReviewById((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [Authorize]
        [Route("reviews/new/{id}")]
        public ActionResult New(int id)
        {
            var review = new Review
            {
                GameId = id
            };

            return View(review);
        }

        [Authorize]
        [HttpPost]
        [Route("reviews/new")]
        [ValidateAntiForgeryToken]
        public ActionResult New(Review review)
        {
            review.ReviewDate = DateTime.Now;
            review.EditDate = null;
            review.ModeratorId = null;
            review.UserId = getCurrentUserId();
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("?");
            }
            return View(review);
        }



        [Route("reviews/add")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Add()
        {
            ViewBag.GameId = new SelectList(_context.Games, "Id", "Title");
            return View();
        }

        [HttpPost]
        [Route("reviews/add")]
        [Authorize(Roles = "Admin,Moderator")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Review review)
        {
            review.ReviewDate = DateTime.Now;
            review.EditDate = null;
            review.ModeratorId = null;
            review.UserId = getCurrentUserId();
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(review);
        }

        [Route("reviews/edit/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _context.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [HttpPost]
        [Route("reviews/edit/{id}")]
        [Authorize(Roles = "Admin,Moderator")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                var user = _context.AppUsers.Include(u => u.ApplicationUser).SingleOrDefault(s => s.Id == review.UserId);

                if (!user.UserId.Equals(User.Identity.GetUserId()))
                {
                    review.ModeratorId = getCurrentUserId();
                }
                review.EditDate = DateTime.Now;

                _context.Entry(review).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(review);
        }

        [Route("reviews/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _context.GetReviewById((int)id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("reviews/delete/{id}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = _context.Reviews.Find(id);
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }

        public int getCurrentUserId()
        {
            string currentUserId = User.Identity.GetUserId();
            var user = _context.AppUsers.Single(s => s.UserId.Equals(currentUserId));
            var id = user.Id;
            return id;
        }
    }
}