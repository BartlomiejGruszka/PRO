using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueArticleTypeName : ValidationAttribute
    {
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             _context = new ApplicationDbContext();

            var articletype = (ArticleType)validationContext.ObjectInstance;

            var isUnique = _context.ArticleTypes
                .SingleOrDefault(s => s.Name == articletype.Name && s.Id != articletype.Id);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już rodzaj artykułu o takiej nazwie.");
            }

            return ValidationResult.Success;

        }

    }
}