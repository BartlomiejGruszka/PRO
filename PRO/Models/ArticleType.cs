using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class ArticleType
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50), DisplayName("Rodzaj artykułu"), MinLength(3), UniqueArticleTypeName] //add custom is unique constraint
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}