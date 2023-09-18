using System.ComponentModel.DataAnnotations;

namespace VivesBlog.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public IList<Article> Articles { get; set; } = new List<Article>();
    }
}
