using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueStatusName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var obj = (Status)validationContext.ObjectInstance;

            var isUnique = _context.Statuses
                .SingleOrDefault(s => s.Name == obj.Name);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już status o takiej nazwie.");
            }

            return ValidationResult.Success;

        }
    }
}