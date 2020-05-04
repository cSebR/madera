using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("remise")]
    public class Remise
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public int Taux { get; set; }

        [MaxLength(75)]
        public string Nom { get; set; }

        [ForeignKey(typeof(Devis))] 
        public int DevisId { get; set; }

        [OneToOne] 
        public Devis Devis { get; set; }
    }
}
