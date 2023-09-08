using System.ComponentModel.DataAnnotations;

namespace ModelValidationOnClient.Models
{
    public record class Person
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
