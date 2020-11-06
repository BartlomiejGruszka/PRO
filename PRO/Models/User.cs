using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; } //pk

        [Required, DisplayName("Data rejestracji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

        [MaxLength(5000), DisplayName("Opis"), AllowHtml]
        public string Description { get; set; } //nullable

        [Required, DisplayName("Wciąż aktywny")]
        public bool IsActive { get; set; }

        [Required, DisplayName("Publiczny profil")]
        public bool IsPublic { get; set; }

        [DisplayName("Obraz profilu")]
        public int? ImageId { get; set; }

        [ForeignKey("ImageId"),DisplayName("Obraz profilu")]
        public Image Image{ get; set; }

        [Required, MaxLength(128), ForeignKey("ApplicationUser"), DisplayName("Pseudonim")]
        public string UserId { get; set; }

        [DisplayName("Pseudonim")]
        public ApplicationUser ApplicationUser { get; set; }



        public ICollection<UserList> UserLists { get; set; }
        public ICollection<Review> Reviews { get; set; }


    }
}