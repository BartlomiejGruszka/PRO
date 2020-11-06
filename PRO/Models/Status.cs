using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100), DisplayName("Status"), MinLength(3), UniqueStatusName] //add custom is unique constraint
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}