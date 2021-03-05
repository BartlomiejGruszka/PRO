using PRO.Models;
using PRO.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;


namespace PRO.Helpers
{
    public class UniqueUserName : ValidationAttribute
    {
        private ApplicationDbContext _context;
          
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();
            var obj = (EditUserViewModel)validationContext.ObjectInstance;

            var isUnique = _context.AppUsers.Include(a=>a.ApplicationUser)
                .SingleOrDefault(s => s.Id != obj.Id && s.ApplicationUser.UserName.ToLower().Trim() == obj.UserName.ToLower().Trim());
            if (isUnique != null)
            {
                return new ValidationResult("Nazwa użytkownika jest zajęta.");
            }

            return ValidationResult.Success;

        }
    }
}