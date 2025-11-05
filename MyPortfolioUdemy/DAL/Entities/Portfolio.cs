
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolioUdemy.DAL.Entities
{
    public class Portfolio
    {
        public int PortfolioId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        // Adım 1'de eklenen "taşıma çantası" özelliği
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}