using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.Helpers
{
    public class FileMustBeAnImage :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var image = (Image)validationContext.ObjectInstance;

            if(image.ImageFile == null)
            {
                return new ValidationResult("Nie wybrano żadnego pliku.");
            }

            var file = image.ImageFile;
            if (file.ContentType.StartsWith("image/"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Wybrany plik nie jest obrazem.");
        }
    }
}