using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class PersonalScoreRange : ValidationAttribute
    {
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();

            var gamelist = (GameList)validationContext.ObjectInstance;

            var isValid = false;
            if(gamelist.PersonalScore.HasValue)
            {
                if(gamelist.PersonalScore.Value >=1 || gamelist.PersonalScore.Value <= 10)
                {
                    isValid = true;
                }
            }
            else { isValid = true; }
            if (!isValid)
            {
                return new ValidationResult("Pole powinno być puste lub mieć wartość od 1 do 10");
            }

            return ValidationResult.Success;

        }


    }
}