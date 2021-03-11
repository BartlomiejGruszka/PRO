using PRO.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRO.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100),DisplayName("Nazwa"),MinLength(3), UniqueImageName] //add custom is unique constraint
        public string Name { get; set; }

        public string ImagePath { get; set; }

        [NotMapped, FileMustBeAnImage, DisplayName("Plik obrazu")]
        public HttpPostedFileBase ImageFile{ get; set; }

        [Required, DisplayName("Rodzaj obrazu")]
        public int ImageTypeId { get; set; }

        [ForeignKey("ImageTypeId")]
        public ImageType ImageType { get; set; }
    }
}