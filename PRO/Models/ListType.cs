using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PRO.Helpers;

namespace PRO.Models
{
    public class ListType
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Nazwa"), MaxLength(50), MinLength(3), UniqueListTypeName] //add custom is unique constraint
        public string Name { get; set; }

        public ICollection<UserList> UserLists { get; set; }
    }
}