using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.ViewModels
{
    public class GameDetailsViewModel
    {
        public GameAndGameListFormViewModel GameGameList { get; set; }
        public IEnumerable<ReviewGametimeViewModel> ReviewGametimes { get; set; }
        public IEnumerable<Article> RelevantArticles { get; set; }


        public Pagination Pagination { get; set; }
    }
}