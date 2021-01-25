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
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //game can be present only on one of all of the user lists

            _context = new ApplicationDbContext();

            var gameList = (GameList)validationContext.ObjectInstance;

            var isUnique = _context.GameLists
                .SingleOrDefault(s => s.GameId == gameList.GameId && s.UserListId == gameList.UserListId);
            if (isUnique != null)
            {
                return new ValidationResult("Gra jest już na liście.");
            }

                return ValidationResult.Success;
            
        }
    }
}