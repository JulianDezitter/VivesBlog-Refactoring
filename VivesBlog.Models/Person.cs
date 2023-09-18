using System.ComponentModel.DataAnnotations;

namespace VivesBlog.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IList<Article> Articles { get; set; } = new List<Article>();
    }
}
