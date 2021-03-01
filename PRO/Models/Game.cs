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
    public class Game
    {
        public Game()
        {
            this.Languages = new HashSet<Language>();
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100), DisplayName("Tytuł"),MinLength(3)]
        public string Title { get; set; }

        [MaxLength(1000), DisplayName("Opis"), AllowHtml]
        public string Description { get; set; }

        
        [DataType(DataType.Date), DisplayName("Data premiery")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Required, DisplayName("Wciąż dostępna")]
        public bool IsActive { get; set; }

        [Required, DisplayName("Platforma")]

        public int PlatformId { get; set; }

        [ForeignKey("PlatformId"), DisplayName("Platforma")]
        public Platform Platform { get; set; }

        [Required, DisplayName("Status")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId"), DisplayName("Status")]
        public Status Status { get; set; }

        [Required, DisplayName("Gatunek")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId"), DisplayName("Gatunek")]
        public Genre Genre { get; set; }

        [ForeignKey("SeriesId"), DisplayName("Seria")]
        public Series Series { get; set; }
        public int? SeriesId { get; set; }


        [ForeignKey("ImageId"),DisplayName("Obraz")]
        public Image Image { get; set; }
        public int? ImageId { get; set; }

        public int? PublisherId { get; set; }

        [ForeignKey("PublisherId"),InverseProperty("PublishedGames"), DisplayName("Wydawca")]
        
        public  Company PublisherCompany { get; set; }

        public int? DeveloperId { get; set; }

        [ForeignKey("DeveloperId"), InverseProperty("DevelopedGames"), DisplayName("Producent")]
        public Company DeveloperCompany { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<Tag> Tags{ get; set; }

        public ICollection<Award> Awards{ get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<GameList> GameLists { get; set; }

    }
}