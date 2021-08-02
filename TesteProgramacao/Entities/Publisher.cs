using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteProgramacao.Services.Validators;

namespace TesteProgramacao.Entities
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        [CnpjAttribute(ErrorMessage = "Insira um CNPJ válido")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        public string Name { get; set; }

        #region Address
        [Required(ErrorMessage = "Insira um valor")]
        public string Estate { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public string City { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public string Complement { get; set; }
        #endregion

        public List<Book> Books { get; set; }
    }
}