//using SQLite;
using System;
using System.Collections.Generic;

namespace IncludeEngenharia.Models
{
    public class Contato
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //[MaxLength(100)]
        public string Nome_Lead { get; set; }

        //[MaxLength(100)]
        public string Celular_Lead { get; set; }

        //[MaxLength(100)]
        public string Interesse_Lead { get; set; }

        //[MaxLength(100)]
        public string Email_Lead { get; set; }

    }

}
