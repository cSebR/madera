using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("dossier_technique")]
    public class DossierTechnique
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(180)]
        public string Nom_dossier { get; set; }

        [ForeignKey(typeof(Devis))] 
        public int DevisId { get; set; }

        [OneToOne] 
        public Devis Devis { get; set; }
    }
}
