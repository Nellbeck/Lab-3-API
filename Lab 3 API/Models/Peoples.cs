using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3_API.Models
{
    public class Peoples
    {
        [Key]
        public int PeopleId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Hobbys> Hobbys { get; set; }

    }
}
