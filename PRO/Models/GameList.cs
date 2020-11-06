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
    public class GameList
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Data dodania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [Required, DisplayName("Rozegrane godziny")]
        public int? HoursPlayed { get; set; }

        [Required, DisplayName("Własna ocena"), Range(1, 10)]
        public int? PersonalScore { get; set; }

        [Required, DisplayName("Lista użytkownika"),UniqueGameAndUserList]  //add custom is unique constraint
        public int UserListId { get; set; }

        [ForeignKey("UserListId"), DisplayName("Lista użytkownika")]
        public UserList UserList{ get; set; }

        [Required, DisplayName("Gra"), UniqueGameAndUserList]  //add custom is unique constraint
        public int GameId { get; set; }

        [ForeignKey("GameId"), DisplayName("Gra")]
        public Game Game { get; set; }

    }
}