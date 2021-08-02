using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteProgramacao.Services.Validators;

namespace TesteProgramacao.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        [CpfAttribute(ErrorMessage = "Insira um CPF válido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        [EmailAddress]
        public string Email { get; set; }

        public List<Book> Books { get; set; }
    }
}