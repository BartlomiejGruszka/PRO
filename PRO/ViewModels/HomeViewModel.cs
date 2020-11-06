using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<Game> RecentGames{ get; set; }
        public IEnumerable<Review>RecentReviews { get; set; }

    }
}