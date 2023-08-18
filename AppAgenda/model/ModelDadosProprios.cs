using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAgenda.model
{
    [Table("MeusDados")]
    public class ModelMeusDados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Nome { get; set; }
        [NotNull]
        public String Celular { get; set; }

        public ModelMeusDados()
        {
            this.Celular = "";
            this.Nome = "";
        }
    }
}
