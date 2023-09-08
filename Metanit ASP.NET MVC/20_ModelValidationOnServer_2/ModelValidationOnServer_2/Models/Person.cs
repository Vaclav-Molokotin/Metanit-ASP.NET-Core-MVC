using System.ComponentModel.DataAnnotations;

namespace ModelValidationOnServer_2.Models
{
    public class Person
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
