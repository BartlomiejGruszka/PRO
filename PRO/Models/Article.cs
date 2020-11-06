using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100), DisplayName("Tytuł"),MinLength(10)]
        public string Title { get; set; }

        [Required, MaxLength(10000), DisplayName("Treść"), AllowHtml,MinLength(100)]
        public string Content { get; set; }

        [Required, DisplayName("Data publikacji")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

        [MaxLength(255), DisplayName("Link źródłowy")]
        public string SourceLink { get; set; }


        [Required, DisplayName("Widoczny")]
        public bool IsActive { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public Image Image { get; set; }

        [Required, DisplayName("Gra")]
        public int GameId { get; set; }

        [ForeignKey("GameId"),DisplayName("Gra")]
        public Game Game { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Author Author { get; set; }

        [Required, DisplayName("Rodzaj artykułu")]
        public int ArticleTypeId { get; set; }

        [ForeignKey("ArticleTypeId"),DisplayName("Rodzaj artykułu")]
        public ArticleType ArticleType { get; set; }


    }
}