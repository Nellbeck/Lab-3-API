using System.ComponentModel.DataAnnotations;

namespace Lab_3_API.Models
{
    public class Webpages
    {
        [Key]
        public int WebpageId { get; set; } 
        public string Webpage { get; set; }
        public int HobbysHobbyId { get; set; }
    }
}
