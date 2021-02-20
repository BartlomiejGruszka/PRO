using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO.ViewModels
{
    public class GameAndGameListFormViewModel
    {
        public Game Game { get; set; }
        public GameList GameList { get; set; }
        public List<UserList> userLists { get; set; }

        public int Popularity { get; set; }
        public int? Ranking { get; set; }
        public double? Rating { get; set; }
    }
}