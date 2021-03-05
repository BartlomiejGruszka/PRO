using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class ImageType
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50), DisplayName("Rodzaj obrazu"), MinLength(3), UniqueImageTypeName] //add custom is unique constraint
        public string Name { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}