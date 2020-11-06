using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.ViewModels
{
    public class GameFilterViewModel
    {
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<Status> Statuses{ get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<Company> Companies{ get; set; }
        public IEnumerable<Genre> Genres{ get; set; }
        public IEnumerable<Game> Games { get; set; }

        public Pagination Pagination { get; set; }

    }
}