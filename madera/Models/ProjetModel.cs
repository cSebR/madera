using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace madera.Models
{
    public class ProjetModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nom { get; set; }
        public DateTime Date { get; set; }
        public string Ref { get; set; }
        public int Created_by { get; set; }

        public override string ToString()
        {
            return Nom;
        }

    }

}
