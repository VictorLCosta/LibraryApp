using System;

namespace TesteProgramacao.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual int AuthorId { get; set; }
        public virtual int PublisherId { get; set; }
    }
}