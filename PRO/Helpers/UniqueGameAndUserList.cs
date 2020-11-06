using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.Helpers
{
    public class UniqueGameAndUserList : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));

            var gameList = (GameList)validationContext.ObjectInstance;

            var isUnique = _context.GameLists
                .SingleOrDefault(s => s.GameId == gameList.GameId && s.UserListId == gameList.GameId);
            if (isUnique != null)
            {
                return new ValidationResult("Wybrana gra znajduje się już na wskazanej liście użytkownika.");
            }

                return ValidationResult.Success;
            
        }
    }
}