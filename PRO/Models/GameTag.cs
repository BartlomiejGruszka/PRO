using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRO.Models
{
    public class GameTag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }


        [Required]
        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}