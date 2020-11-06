using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRO.Models
{
    public class GameLanguage
    {
        [Key,Column(Order =1)]
        public int GameId { get; set; }


        [Key, Column(Order = 2)]
        public int LanguageId { get; set; }


        public Game Game { get; set; }
        public Language Language { get; set; }
    }
}