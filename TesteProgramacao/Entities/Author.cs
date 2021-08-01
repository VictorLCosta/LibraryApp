using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteProgramacao.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Book> Books { get; set; }
    }
}