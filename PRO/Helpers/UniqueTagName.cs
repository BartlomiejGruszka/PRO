using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniqueTagName : ValidationAttribute
    {

        private ApplicationDbContext _context;



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _context = new ApplicationDbContext();


            var obj = (Tag)validationContext.ObjectInstance;

            var isUnique = _context.Tags
                .SingleOrDefault(s => s.Name == obj.Name && s.Id != obj.Id);


            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już słowo kluczowe o takiej nazwie.");
            }

            return ValidationResult.Success;

        }


    }
}