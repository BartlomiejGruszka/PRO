﻿using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRO.ViewModels;
using System.Data.Entity;
using PRO.Helpers;
using System.Net;

namespace PRO.Controllers
{

    public class ArticlesController : Controller
    {
        private ApplicationDbContext _context;

        public ArticlesController()
        {
            _context = new ApplicationDbContext();
        }
        [AllowAnonymous]
        [Route("articles/")]
        public ActionResult Index()
        {
            var articlesList = _context.GetArticlesList();
            return View(articlesList);
        }

        [Route("articles/manage")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Manage()
        {
            List<Article> articlesList = null;

            if (!User.IsInRole("Admin"))
            {
                articlesList = _context.GetArticlesList().Where(s => s.Author.UserId == getCurrentUserId()).ToList();
            }
            else
            {
                articlesList = _context.GetArticlesList();
            }
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            ViewBag.Pagination = new Pagination(pageString, itemString, articlesList.Count());
            return View(articlesList);
        }

        [AllowAnonymous]
        [Route("articles/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = _context.GetArticleById((int)id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [Route("articles/details/{id}")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult ManageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var article = _context.GetArticleById((int)id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [Route("articles/add")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Add()
        {

            return View(_context.GetFullArticleForm(null));
        }


        [HttpPost]
        [Route("articles/add")]
        [Authorize(Roles = "Admin,Author")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Article article)
        {
            if (ModelState.IsValid)
            {
                var userid = getCurrentUserId();
                if (userid == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                article.UserId = (int)userid;
                article.PublishedDate = DateTime.Now;
                _context.Articles.Add(article);
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            var articleViewModel = _context.GetFullArticleForm(null);
            articleViewModel.Article = article;
            return View(articleViewModel);
        }

        [Route("articles/edit/{id}")]
        [Authorize(Roles = "Admin,Author")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleViewModel articleViewModel = _context.GetFullArticleForm(id);
            if (articleViewModel.Article == null)
            {
                return HttpNotFound();
            }
            if (articleViewModel.Article.UserId != getCurrentUserId() && !User.IsInRole("Admin")) { RedirectToAction("Manage"); }

            return View(articleViewModel);
        }

        [HttpPost]
        [Route("articles/edit/{id}")]
        [Authorize(Roles = "Admin,Author")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleViewModel articleViewModel)
        {
            if (articleViewModel.Article.UserId != getCurrentUserId() && !User.IsInRole("Admin")) { RedirectToAction("Manage"); }
            if (ModelState.IsValid)
            {
                _context.Entry(articleViewModel.Article).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            articleViewModel = _context.GetFullArticleForm(articleViewModel.Article.Id);
            return View(articleViewModel);
        }

        [Route("articles/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = _context.GetArticleById((int)id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("articles/delete/{id}")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = _context.Articles.Find(id);
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }
        public int? getCurrentUserId()
        {
            string currentUserId = User.Identity.GetUserId();
            var user = _context.AppUsers.SingleOrDefault(s => s.UserId.Equals(currentUserId));
            if (user == null) return null;
            var id = user.Id;
            return id;
        }


    }
}