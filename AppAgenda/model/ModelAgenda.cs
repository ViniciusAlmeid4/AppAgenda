using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppAgenda.model
{
    [Table("Pessoas")]
    public class ModelAgenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Nome { get; set; }
        [NotNull]
        public String Celular { get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }

        public ModelAgenda()
        {
            this.Id = 0;
            this.Celular = "";
            this.Favorito = false;
            this.Nome = "";
        }
    }
}
