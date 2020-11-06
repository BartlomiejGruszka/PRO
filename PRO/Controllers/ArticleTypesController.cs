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
    [Authorize]
    public class ArticleTypesController : Controller
    {
        private ApplicationDbContext _context;

        public ArticleTypesController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("articletypes/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("articletypes/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];
            var articleTypesList = _context.ArticleTypes.ToList();
            ViewBag.Pagination = new Pagination(pageString, itemString, articleTypesList.Count());

            return View(articleTypesList);
        }

        [Route("articletypes/details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleType articletype = _context.ArticleTypes.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        [Route("articletypes/add")]
        public ActionResult Add()
        {
            return View(new ArticleType());
        }


        [HttpPost]
        [Route("articletypes/add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ArticleType articleType)
        {
            if (ModelState.IsValid)
            {
                _context.ArticleTypes.Add(articleType);
                _context.SaveChanges();

                return RedirectToAction("Manage");
            }
            return View(articleType);
        }

        [Route("articletypes/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleType articletype = _context.ArticleTypes.Find(id);
            if (articletype == null)
            {
                return HttpNotFound();
            }
            return View(articletype);
        }

        [HttpPost]
        [Route("articletypes/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ArticleType articleType)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(articleType).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(articleType);
        }

        [Route("articletypes/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleType articleType = _context.ArticleTypes.Find(id);
            if (articleType == null)
            {
                return HttpNotFound();
            }
            return View(articleType);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("articletypes/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleType articleType = _context.ArticleTypes.Find(id);
            _context.ArticleTypes.Remove(articleType);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }

    }
}