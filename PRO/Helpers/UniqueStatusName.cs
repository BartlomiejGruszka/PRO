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
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();

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