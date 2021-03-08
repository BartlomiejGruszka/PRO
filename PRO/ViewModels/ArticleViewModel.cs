using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO.Models;

namespace PRO.ViewModels
{
    public class ArticleViewModel
    {
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<ArticleType> ArticleTypes { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<ImageType> ImageTypes { get; set; }

        public Article Article { get; set; }
    }
}