using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueReviewUserIdAndGameId : ValidationAttribute
    {
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             _context = new ApplicationDbContext();

            var review = (Review)validationContext.ObjectInstance;

            var isUnique = _context.Reviews
                .SingleOrDefault(s => s.GameId == review.GameId && s.UserId == review.UserId && s.Id!=review.Id);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już recenzja dla tej gry.");
            }

            return ValidationResult.Success;

        }
    }
}