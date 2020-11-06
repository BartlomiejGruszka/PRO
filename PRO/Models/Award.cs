using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class Award
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100), DisplayName("Nazwa nagrody"), MinLength(3), UniqueAwardName] //add custom is unique constraint
        public string Name { get; set; }
        [Required, DisplayName("Data nadania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AwardDate { get; set; }

        [Required, DisplayName("Nagrodzona gra")]
        public int GameId { get; set; }

        [ForeignKey("GameId"),DisplayName("Nagrodzona gra")]
        public Game Game { get; set; }


    }
}