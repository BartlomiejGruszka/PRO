using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueAwardName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var award = (Award)validationContext.ObjectInstance;

            var isUnique = _context.Awards
                .SingleOrDefault(s => s.Name == award.Name);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już nagroda o takiej nazwie.");
            }

            return ValidationResult.Success;

        }

    }
}