using System.Collections.Generic;

namespace TesteProgramacao.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }

        #region Address
        public string Estate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        #endregion

        public List<Book> Books { get; set; }
    }
}