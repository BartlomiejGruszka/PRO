using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Models;
using PRO.Helpers;


namespace PRO.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [EmailAddress,UniqueUserEmail]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(25, ErrorMessage = "{0}musi mieć co najmniej {2} znaków.", MinimumLength = 3),UniqueUserName]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [DisplayName("Data rejestracji")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

        [MaxLength(5000), DisplayName("Opis"), System.Web.Mvc.AllowHtml]
        public string Description { get; set; }

        [DisplayName("Wciąż aktywny")]
        public bool IsActive { get; set; }

        [DisplayName("Publiczny profil")]
        public bool IsPublic { get; set; }

        [DisplayName("Obraz profilu")]
        public int? ImageId { get; set; }


        public List<Image> Images { get; set; }
    }
}