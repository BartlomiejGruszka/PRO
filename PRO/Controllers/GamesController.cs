using PRO.Models;
using PRO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PRO.Helpers;
using System.Net;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace PRO.Controllers
{
    [Authorize(Roles = "Admin,Author")]
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Games
        [AllowAnonymous]
        [Route("games/")]
        public ActionResult Index()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];


            var games = _context.GetGamesList().ToList();
            var pagination = new Pagination(pageString, itemString, games.Count());

            var viewModel = new GameFilterViewModel
            {
                Games = games,
                Pagination = pagination,
                GameScores = _context.GetListOfAllGamesScores(games)
            };

            return View(viewModel);
        }
        [HttpGet]
        [Route("games/manage")]
        public ActionResult Manage()
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var games = _context.GetGamesList();

            ViewBag.Pagination = new Pagination(pageString, itemString, games.Count());
            return View(games);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("games/{id}")]
        public ActionResult Details(int id)
        {
            var viewModel = setupDetailsPage(id, null);
           
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [Route("games/{id}")]
        public ActionResult Details(int id,[Bind(Include = "Id,AddedDate,HoursPlayed,PersonalScore,UserListId,GameId")] GameList gameList)
        {

            if (gameList.UserListId <= 0)
            {
                ModelState.AddModelError("UserListId", "Wybierz listę użytkownika");
            }
            gameList.AddedDate = DateTime.Now;
            TempData["gameList"] = gameList;
            if (ModelState.IsValid)
            {
                _context.GameLists.Add(gameList);
                _context.SaveChanges();
                
            }
            var viewModel = setupDetailsPage(id, gameList);
            if (viewModel == null) return HttpNotFound();
            return View(viewModel);
        }
        private GameDetailsViewModel setupDetailsPage(int id, GameList gamelist)
        {
            var game = _context.GetGameById(id);
            if (game == null) return null;
            var reviews = _context.GetGameReviewsList(game.Id).Take(3);
            var pagination = new Pagination(null, null, reviews.Count());
            var articles = _context.GetArticlesList().Where(a => a.GameId == id).OrderByDescending(a => a.PublishedDate).Take(3);

            var userid = getCurrentUserId();
            var userLists = _context.UserLists.Where(u => u.UserId == userid).ToList();


            var GameGameList = new GameAndGameListFormViewModel
            {
                Game = game,
                GameList = gamelist,
                userLists = userLists
            };

            var viewModel = new GameDetailsViewModel
            {
                GameGameList = GameGameList,
                Reviews = _context.GetGameReviewsList(game.Id),
                RelevantArticles = articles,
                Pagination = pagination
            };
            return viewModel;
        }


        [Route("games/details/{id}")]
        public ActionResult ManageDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game games = _context.GetGameById((int)id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }
        [HttpGet]
        [Route("games/add")]
        public ActionResult Add()
        {
            return View(_context.GetFullGameForm(null));
        }

        [HttpPost]
        [Route("games/add")]
        public ActionResult Add(GameViewModel viewModel)
        {
            var languages = _context.Languages.ToList();
            var tags = _context.Tags.ToList();
            if (viewModel.selectedTagsId != null)
            {
                foreach (var tagid in viewModel.selectedTagsId)
                {
                    viewModel.Game.Tags.Add(tags.Single(s => s.Id == tagid));
                }
            }
            if (viewModel.selectedLanguagesId != null)
            {
                foreach (var languageid in viewModel.selectedLanguagesId)
                {
                    viewModel.Game.Languages.Add(languages.Single(s => s.Id == languageid));
                }
            }

            if (ModelState.IsValid)
            {

                _context.Games.Add(viewModel.Game);
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }
            var newViewModel = _context.GetFullGameForm(null);
            newViewModel.Game = viewModel.Game;
            return View(newViewModel);
        }

        [HttpGet]
        [Route("games/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var gameViewModel = _context.GetFullGameForm(id);

            if (gameViewModel.Game == null) return HttpNotFound();

            return View(gameViewModel);

        }

        [HttpPost]
        [Route("games/edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var languages = _context.Languages.ToList();
                var tags = _context.Tags.ToList();
                var newLanguages = new List<Language>();
                var newTags = new List<Tag>();

                _context.Entry(viewModel.Game).State = EntityState.Modified;



                if (viewModel.selectedTagsId != null)
                {
                    _context.Entry(viewModel.Game).Collection(l => l.Tags).Load();
                    viewModel.Game.Tags.Clear();

                    foreach (var tagid in viewModel.selectedTagsId)
                    {
                        viewModel.Game.Tags.Add(tags.Single(s => s.Id == tagid));
                    }
                }
                if (viewModel.selectedLanguagesId != null)
                {
                    _context.Entry(viewModel.Game).Collection(l => l.Languages).Load();
                    viewModel.Game.Languages.Clear();

                    foreach (var languageid in viewModel.selectedLanguagesId)
                    {
                        viewModel.Game.Languages.Add(languages.Single(s => s.Id == languageid));
                    }
                }

                _context.SaveChanges();

                return RedirectToAction("Manage");
            }
            return View(viewModel);
        }

        // GET: Companies/Delete/5
        [HttpGet]
        [Route("games/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _context.GetGameById((int)id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [Route("games/delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = _context.GetGameById((int)id);
            _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("games/ranking")]
        public ActionResult Ranking()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("games/{id}/reviews")]
        public ActionResult Reviews(int id)
        {
            var game = _context.GetGameById(id);
            if (game == null) return HttpNotFound();
            var reviews = _context.GetGameReviewsList(game.Id);
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var pagination = new Pagination(pageString, itemString, reviews.Count());

            var GameGameList = new GameAndGameListFormViewModel
            {
                Game = game
            };

            var viewModel = new GameDetailsViewModel
            {
                GameGameList = GameGameList,
                Reviews = _context.GetGameReviewsList(game.Id),
                Pagination = pagination
            };
            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("games/{id}/reviews/{review}")]
        public ActionResult SingleReview(int id, int review)
        {
            var game = _context.GetGameById(id);
            if (game == null) return HttpNotFound();
            var reviews = _context.GetReviewById(review);
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];

            var pagination = new Pagination(pageString, itemString, 1);

            List<Review> list = new List<Review>();
            list.Add(reviews);
            var GameGameList = new GameAndGameListFormViewModel
            {
                Game = game
            };

            var viewModel = new GameDetailsViewModel
            {
                GameGameList = GameGameList,
                Reviews = list,
                Pagination = pagination
            };
            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("games/search/{query?}")]
        public ActionResult Search(string query)
        {
            var pageString = Request.QueryString["page"];
            var itemString = Request.QueryString["items"];


            var games = _context.GetGamesList().ToList();
            var filteredgames = games
                .Where(g =>
                g.Title.CaseInsensitiveContains(query) ||
                g.Description.CaseInsensitiveContains(query) ||
                g.DeveloperCompany.Name.CaseInsensitiveContains(query) ||
                g.PublisherCompany.Name.CaseInsensitiveContains(query) ||
                g.Status.Name.CaseInsensitiveContains(query)
                ).ToList();
    
            var pagination = new Pagination(pageString, itemString, filteredgames.Count());

            var viewModel = new GameFilterViewModel
            {
                Games = filteredgames,
                Pagination = pagination,
                GameScores = _context.GetListOfAllGamesScores(filteredgames)
            };

            return View("Index",viewModel);
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