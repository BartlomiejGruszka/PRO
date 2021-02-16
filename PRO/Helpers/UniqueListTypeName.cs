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
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             _context = new ApplicationDbContext();

            var obj = (ListType)validationContext.ObjectInstance;

            var isUnique = _context.ListTypes
                .SingleOrDefault(s => s.Name == obj.Name && s.Id != obj.Id);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już rodzaj listy o takiej nazwie.");
            }

            return ValidationResult.Success;

        }
    }
}