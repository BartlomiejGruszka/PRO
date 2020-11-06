using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.ViewModels
{
    public class GameDetailsViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

        public Pagination Pagination { get; set; }
    }
}