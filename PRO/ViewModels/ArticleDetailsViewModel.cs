using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public Article Article { get; set; }
        public IEnumerable<Review>RecentReviews { get; set; }

        public IEnumerable<Game> RecentGames { get; set; }

        public List<Tuple<Game, double?>> BestRatedGames { get; set; }

    }
}