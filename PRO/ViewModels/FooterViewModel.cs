using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.ViewModels
{
    public class FooterViewModel

    {
        public IEnumerable<Company> PopularCompanies { get; set; }
        public IEnumerable<Game> RecentlyReviewedGames { get; set; }
        public IEnumerable<Game> HighestRatedGames { get; set; }
    }
}