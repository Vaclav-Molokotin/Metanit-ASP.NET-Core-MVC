using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AttributesOfValidation.Models
{
    public class Person
    {
        [Required (ErrorMessage = "Не указано имя")]
        [StringLength (50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Name { get; set; }

        [Required (ErrorMessage = "Не указана почта")]
        [Remote(controller: "Home", action: "CheckEmail", ErrorMessage = "Такой Email уже существует")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? PasswordConfirm { get; set; }

        [Range(1, 101, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
    }
}
