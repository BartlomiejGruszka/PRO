using PRO.Models;
using PRO.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueUserName : ValidationAttribute
    {
        private ApplicationDbContext _context;
          
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();
            var obj = (EditUserViewModel)validationContext.ObjectInstance;

            var isUnique = _context.Users
                .SingleOrDefault(s => s.UserName == obj.UserName);
            if (isUnique != null)
            {
                return new ValidationResult("Nazwa użytkownika jest zajęta.");
            }

            return ValidationResult.Success;

        }
    }
}