using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PRO.ViewModels;

namespace PRO.Helpers
{
    public static class Extensions
    {
        public static Game GetGameById(this ApplicationDbContext context, int? id)
        {

            var game = context.Games
         .Include(i => i.Platform)
         .Include(a => a.Genre)
         .Include(a => a.Status)
         .Include(a => a.Series)
         .Include(a => a.PublisherCompany)
         .Include(a => a.DeveloperCompany)
         .Include(a => a.Tags)
         .Include(a => a.Languages)
         .Include(a => a.Image)
         .Include(a => a.Awards)
         .Include(a => a.Reviews)
         .SingleOrDefault(g => g.Id == id);

            if (game == null) return null;

            var series = context.Series.Include(g => g.Games)
                .SingleOrDefault(s => s.Id == game.SeriesId);

            game.Series = series;

            return game;
        }

        public static IQueryable<Game> GetGamesList(this ApplicationDbContext context)
        {

            var games = context.Games
                 .Include(i => i.Platform)
                 .Include(a => a.Genre)
                 .Include(a => a.Status)
                 .Include(a => a.Series)
                 .Include(a => a.PublisherCompany)
                 .Include(a => a.DeveloperCompany)
                 .Include(a => a.Image)
                 .Include(a => a.Reviews);
                 
            return games;
        }

        public static IEnumerable<Review> GetGameReviewsList(this ApplicationDbContext context, int gameid)
        {
            var reviews = context.Reviews
                .Where(w => w.GameId == gameid)
                .Include(o => o.User.ApplicationUser)
                .Include(o => o.Game)
                .ToList();
            return reviews;
        }
        public static GameViewModel GetFullGameForm(this ApplicationDbContext context, int? id)
        {
            Game game = null;
            List<int> selectedLanguagesId = null;
            List<int> selectedTagsId = null;

            if (id != null) { game = context.GetGameById(id); }


            if (game != null)
            {
                selectedLanguagesId = game.Languages.Select(l => l.Id).ToList();
                selectedTagsId = game.Tags.Select(l => l.Id).ToList();
            }



            var gameViewModel = new GameViewModel
            {
                Platforms = context.Platforms.ToList(),
                Statuses = context.Statuses.ToList(),
                Genres = context.Genres.ToList(),
                Series = context.Series.ToList(),
                Publlishers = context.Companies.ToList(),
                Developers = context.Companies.ToList(),
                Images = context.Images.ToList(),
                Languages = context.Languages.ToList(),
                Tags = context.Tags.ToList(),
                Game = game,
                selectedLanguagesId = selectedLanguagesId,
                selectedTagsId = selectedTagsId

            };
            return gameViewModel;
        }

        public static ArticleViewModel GetFullArticleForm(this ApplicationDbContext context, int? id)
        {
            Article article = null;

            if (id != null)
            {
                article = context.Articles.Find((int)id);
            }



            var viewModel = new ArticleViewModel
            {
                Images = context.Images.ToList(),
                ArticleTypes = context.ArticleTypes.ToList(),
                Games = context.Games.ToList(),
                Authors = context.Authors.ToList(),
                Article = article

            };
            return (viewModel);
        }


        public static List<Article> GetArticlesList(this ApplicationDbContext context)
        {
            var articles = context.Articles
             .Include(i => i.Image)
             .Include(i => i.Author)
             .Include(i => i.ArticleType)
             .Include(i => i.Game)
             .Include(i => i.Game.Platform)
             .ToList();
            return articles;
        }
        public static List<Article> GetArticlesListByPlatform(this ApplicationDbContext context, string platform)
        {
            var articles = context.Articles
             .Include(i => i.Image)
             .Include(i => i.Author)
             .Include(i => i.ArticleType)
             .Include(i => i.Game)
             .Include(i => i.Game.Platform)
             .Where(i => i.Game.Platform.Name.Contains(platform))
             .ToList();
            return articles;
        }

        public static Article GetArticleById(this ApplicationDbContext context, int id)
        {
            Article article = context.Articles
                .Include(a => a.Game)
                .Include(a => a.Game.Tags)
                .Include(a => a.Author)
                .Include(a => a.ArticleType)
                .Include(a => a.Image)
                .SingleOrDefault(a => a.Id == id);
            return article;
        }

        public static Award GetAwardById(this ApplicationDbContext context, int id)
        {
            Award award = context.Awards
                .Include(a => a.Game)
                .SingleOrDefault(a => a.Id == id);
            return award;
        }

        public static List<Review> GetReviewsList(this ApplicationDbContext context)
        {
            var reviews = context.Reviews
                .Include(r => r.User.ApplicationUser)
                .Include(r => r.Moderator.User.ApplicationUser)
                .Include(r => r.Game)
                .ToList();
            return reviews;
        }
        public static Review GetReviewById(this ApplicationDbContext context, int id)
        {
            var review = context.Reviews
                .Include(r => r.User.ApplicationUser)
                .Include(r => r.Moderator.User.ApplicationUser)
                .Include(r => r.Game)
                .SingleOrDefault(r => r.Id == id);
            return review;
        }

        public static List<UserList> GetUsersListList(this ApplicationDbContext context)
        {
            var userlists = context.UserLists
            .Include(m => m.User)
            .Include(a => a.User.ApplicationUser)
            .Include(a => a.ListType).ToList();
            return userlists;
        }
        public static UserList GetFullUsersListForm(this ApplicationDbContext context, int id)
        {
            var userlist = context.UserLists
                .Include(m => m.User)
                .Include(a => a.User.ApplicationUser)
                .Include(a => a.ListType)
                .SingleOrDefault(r => r.Id == id);
            return userlist;
        }
        public static List<GameList> GetFullGameListsList(this ApplicationDbContext context)
        {
            var gameList = context.GameLists
                .Include(g => g.Game)
                .Include(g => g.UserList)
                .Include(g => g.UserList.User.ApplicationUser)
                .ToList();

            return gameList;
        }
        public static GameList GetFullGameListById(this ApplicationDbContext context, int? id)
        {
            var gameList = context.GameLists
                .Include(g => g.Game)
                .Include(g => g.UserList)
                .Include(g => g.UserList.User.ApplicationUser)
                .SingleOrDefault(g => g.Id == id);

            return gameList;
        }

        public static List<Review> GetRecentReviews(this ApplicationDbContext context)
        {
            var recentReviews = context.Reviews
               .Where(w => DbFunctions.TruncateTime(w.ReviewDate) < System.DateTime.Now)
               .OrderByDescending(o => o.ReviewDate)
               .Include(o => o.Game)
               .Include(o => o.User.ApplicationUser)
               .Take(5).ToList();

            return recentReviews;
        }

        public static double GetScoreByGameId(this ApplicationDbContext context, int id)
        {
            var game = context.GetGameById(id);
            double score = 0d;
            foreach (var review in game.Reviews)
            {
                var temp = (review.StoryScore + review.MusicScore + review.GraphicsScore + review.GameplayScore) / 4;
                score += temp;
            }
            score = score / game.Reviews.Count();

            return score;
        }

        public static List<Tuple<int,double>> GetListOfAllGamesScores(this ApplicationDbContext context, List<Game> games)
        {
            
            var list = new List<Tuple<int, double>>();
            foreach (var game in games)
            {
                var score = context.GetScoreByGameId(game.Id);
                list.Add(Tuple.Create(game.Id, score));
            };


            return list ;
        }
    }
}