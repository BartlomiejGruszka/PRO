using PRO.Models;
using PRO.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PRO.Helpers;
using System.Collections.Generic;
using System;

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

            var comingReleases = _context.Games
                .Include(i => i.Image)
                .Where(w => DbFunctions.TruncateTime(w.ReleaseDate) > System.DateTime.Now).OrderBy(o => o.ReleaseDate).ToList().Take(5);

            var recentReviews = _context.GetRecentReviews();

            var recentArticles = _context.Articles
             .Include(i => i.Image)
             .Include(i => i.Author)
             .Include(i => i.ArticleType)
             .Include(i => i.Game)
             .Include(i => i.Game.Platform)
             .Where(w => DbFunctions.TruncateTime(w.PublishedDate) < System.DateTime.Now).OrderByDescending(o => o.PublishedDate).ToList().Take(5);

            // var highestRatedGames =
            //  var popularCompanies = _context.Companies.Include(g => g.)
            var recentlyReviewed = new List<Game>();
            foreach (var review in recentReviews)
            {
                recentlyReviewed.Add(review.Game);
            }



            var homeViewModel = new HomeViewModel
            {
                RecentGames = recentReleases,
                RecentReviews = recentReviews,
                RecentArticles = recentArticles,
                ComingGames = comingReleases


            };

            return View(homeViewModel);
        }

        [Route("search/{type?}")]
        public ActionResult Search(string type)
        {
            var query = Request.QueryString["searchString"];
            if (string.IsNullOrEmpty(query)) { return RedirectToAction("Index"); }

            switch (type)
            {
                case "games":
                    return RedirectToAction("Search", "Games", new { query = query });
                case "articles":
                    return RedirectToAction("Search", "Articles", new { query = query });
                case "users":
                    //redirect to filtered list view of users
                    return RedirectToAction("Index");
                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult GetFooter()
        {

            var highestRatedGames = _context.GetUnorderedGamesRanking().OrderByDescending(t=>t.Item2).Take(5);
            var recentReviews = _context.GetRecentReviews();
            var popularCompanies = _context.GameLists
                .Include(i => i.Game)
                .Include(i => i.Game.DeveloperCompany)
                .GroupBy(g => g.Game.DeveloperCompany)
                .Select(g => new { company = g.Key, count = g.Count() })
                .AsEnumerable()
                .Select(c => new Tuple<Company, int>(c.company, c.count))
                .OrderByDescending(o => o.Item2)
                .Take(5)
                .ToList();

            
            FooterViewModel footerViewModel = new FooterViewModel
            {
                HighestRatedGames = highestRatedGames,
                PopularCompanies = popularCompanies,
                RecentReviews = recentReviews
            };


            return PartialView("_Footer", footerViewModel);
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