using System.ComponentModel.DataAnnotations;

namespace ModelValidationOnServer.Models
{
    public class Person
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
