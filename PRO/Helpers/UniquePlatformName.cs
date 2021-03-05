﻿using PRO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRO.Helpers
{
    public class UniquePlatformName : ValidationAttribute
    {
        private ApplicationDbContext _context;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             _context = new ApplicationDbContext();

            var obj = (Platform)validationContext.ObjectInstance;

            var isUnique = _context.Platforms
                .SingleOrDefault(s => s.Name.ToLower().Trim() == obj.Name.ToLower().Trim() && s.Id != obj.Id);
            if (isUnique != null)
            {
                return new ValidationResult("Istnieje już platforma o takiej nazwie.");
            }

            return ValidationResult.Success;

        }
    }
}