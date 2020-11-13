using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueSeriesName : ValidationAttribute
    {
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             _context = new ApplicationDbContext();

            var obj = (Series)validationContext.ObjectInstance;

            var isUnique = _context.Series
                .SingleOrDefault(s => s.Name == obj.Name);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już seria o takiej nazwie.");
            }

            return ValidationResult.Success;

        }
    }
}