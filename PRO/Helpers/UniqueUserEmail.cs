using PRO.Models;
using PRO.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PRO.Helpers
{
    public class UniqueUserEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var obj = (EditUserViewModel)validationContext.ObjectInstance;

            var isUnique = _context.AppUsers.Include(s => s.ApplicationUser)
                .SingleOrDefault(s => s.ApplicationUser.Email == obj.Email);
            if (isUnique != null)
            {
                return new ValidationResult("Ten adres email jest już wykorzystany.");
            }

            return ValidationResult.Success;

        }
    }
}