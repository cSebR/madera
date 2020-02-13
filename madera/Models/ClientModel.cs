using System;
using SQLite;

namespace madera.Models
{
    public class ClientModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
