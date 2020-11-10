using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueUserListUserIdAndName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var userList = (UserList)validationContext.ObjectInstance;

            var isUnique = _context.UserLists
                .SingleOrDefault(s => s.Name == userList.Name && s.UserId ==  userList.UserId);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już lista o takiej nazwie.");
            }

            return ValidationResult.Success;

        }
    }
}