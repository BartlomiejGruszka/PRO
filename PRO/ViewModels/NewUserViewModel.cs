using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.ViewModels
{
    public class NewUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "{0}musi mieć co najmniej {2} znaków.", MinimumLength = 3)]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same.")]
        public string ConfirmPassword { get; set; }

        [Required, DisplayName("Data rejestracji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

        [MaxLength(5000), DisplayName("Opis"), System.Web.Mvc.AllowHtml]
        public string Description { get; set; }

        [Required, DisplayName("Wciąż aktywny")]
        public bool IsActive { get; set; }

        [Required, DisplayName("Publiczny profil")]
        public bool IsPublic { get; set; }

        [DisplayName("Obraz profilu")]
        public int? ImageId { get; set; }


        public List<Image> Images { get; set; }
    }
}