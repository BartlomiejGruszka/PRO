using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRO.Models
{
    public class Author
    {
        [Key,ForeignKey("User"), DisplayName("Użytkownik")]
        public int UserId { get; set; } // user id fk and pk

        [Required, MaxLength(50), DisplayName("Imię"), MinLength(3)]
        public string FirstName { get; set; }

        [Required, MaxLength(50), DisplayName("Nazwisko"), MinLength(3)]
        public string LastName { get; set; }

        [Required, DisplayName("Data nadania roli")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [Required, DisplayName("Wciąż aktywny")]
        public bool IsActive { get; set; }

        public ICollection<Article> Articles { get; set; }

        [DisplayName("Użytkownik")]
        public User User { get; set; }
    }
}