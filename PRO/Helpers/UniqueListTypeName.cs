using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueListTypeName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var obj = (ListType)validationContext.ObjectInstance;

            var isUnique = _context.ListTypes
                .SingleOrDefault(s => s.Name == obj.Name);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już rodzaj listy o takiej nazwie.");
            }

            return ValidationResult.Success;

        }
    }
}