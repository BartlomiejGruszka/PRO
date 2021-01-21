﻿using PRO.Models;
using PRO.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PRO.Helpers;

namespace PRO.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var recentReleases = _context.Games
                .Include(i => i.Image)
                .Where(w => DbFunctions.TruncateTime(w.ReleaseDate) < System.DateTime.Now).OrderByDescending(o => o.ReleaseDate).ToList().Take(5);

            var recentReviews = _context.GetRecentReviews();

            var recentArticles = _context.Articles
             .Include(i => i.Image)
             .Include(i => i.Author)
             .Include(i => i.ArticleType)
             .Include(i => i.Game)
             .Include(i => i.Game.Platform)
             .Where(w => DbFunctions.TruncateTime(w.PublishedDate) < System.DateTime.Now).OrderByDescending(o => o.PublishedDate).ToList().Take(5);

            var homeViewModel = new HomeViewModel
            {
                RecentGames = recentReleases,
                RecentReviews = recentReviews,
                RecentArticles = recentArticles
            };

            return View(homeViewModel);
        }
        [Route("search/{type?}")]
        public ActionResult Search(string type)
        {
            var query = Request.QueryString["searchString"];
            if (string.IsNullOrEmpty(query)) { return RedirectToAction("Index"); }

            if (type == "games")
            {
                return RedirectToAction("Search","Games",new { query = query} );
            }
            else if (type == "articles")
            {
                return RedirectToAction("Search", "Articles", new { query = query });
            }
            else if (type == "users")
            {
                //redirect to filtered list view of users
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}