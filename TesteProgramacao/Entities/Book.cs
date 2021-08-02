using System;
using System.ComponentModel.DataAnnotations;

namespace TesteProgramacao.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public string Edition { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        public DateTime ReleaseDate { get; set; }


        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        public virtual int AuthorId { get; set; }
        
        [Required(ErrorMessage = "Insira um valor")]
        public virtual int PublisherId { get; set; }
    }
}