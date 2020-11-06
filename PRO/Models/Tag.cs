using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100), DisplayName("Słowo kluczowe"), MinLength(2), UniqueTagName] //add custom is unique constraint
        public string Name { get; set; }
        public Tag()
        {
            this.Games = new HashSet<Game>();
        }

        public ICollection<Game> Games { get; set; }
    }
}