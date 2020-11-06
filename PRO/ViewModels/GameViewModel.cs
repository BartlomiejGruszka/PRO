using PRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO.ViewModels
{
    public class GameViewModel
    {
        public IEnumerable<Platform> Platforms { get; set; }
        public IEnumerable<Status> Statuses{ get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Series> Series { get; set; }
        public IEnumerable<Company> Publlishers { get; set; }
        public IEnumerable<Company> Developers { get; set; }
        public IEnumerable<Image> Images{ get; set; }
        public IEnumerable<Language> Languages{ get; set; }
        public IEnumerable<Tag> Tags{ get; set; }
        public IEnumerable<int> selectedLanguagesId { get; set; }
        public IEnumerable<int> selectedTagsId { get; set; }
        public Game Game { get; set; }
    }
}