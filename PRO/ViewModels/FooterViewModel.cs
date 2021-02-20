using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.ViewModels
{
    public class FooterViewModel

    {
        public List<Tuple<Company, int>> PopularCompanies { get; set; }
        public IEnumerable<Review> RecentReviews { get; set; }
        public IEnumerable<Tuple<Game, double?>> HighestRatedGames { get; set; }
    }
}