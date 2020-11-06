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
    public class UserList
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Data utworzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [Required, DisplayName("Nazwa"), MaxLength(50), MinLength(3), UniqueUserListName ] //add custom is unique constraint
        public string Name { get; set; }

        [Required, DisplayName("Dostępna publicznie")]
        public bool IsPublic { get; set; }

        [Required, DisplayName("Właściciel listy")]
        public int UserId { get; set; }

        [ForeignKey("UserId"), DisplayName("Właściciel listy")]
        public User User { get; set; }

        [Required, DisplayName("Rodzaj listy")]
        public int ListTypeId { get; set; }

        [ForeignKey("ListTypeId"), DisplayName("Rodzaj listy")]
        public ListType ListType { get; set; }

        public ICollection<GameList> GameLists { get; set; }
    }
}