using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3_API.Models
{
    public class Hobbys
    {
        [Key]
        public int HobbyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PeoplesPeopleId { get; set; }
        public IEnumerable<Webpages> Webpages { get; set; }

    }
}
