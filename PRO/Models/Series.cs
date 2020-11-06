using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100), DisplayName("Tytuł serii"), MinLength(3), UniqueSeriesName] //add custom is unique constraint
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}