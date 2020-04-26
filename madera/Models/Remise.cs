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

        public int Taux_remise { get; set; }

        [MaxLength(75)]
        public string Nom_remise { get; set; }

        [ForeignKey(typeof(Devis))] 
        public int Devis_id { get; set; }

        [OneToOne] 
        public Devis Devis { get; set; }
    }
}
