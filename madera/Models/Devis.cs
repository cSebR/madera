using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("devis")]
    public class Devis
    {
        [PrimaryKey, AutoIncrement]
        public long Ref_devis { get; set; }

        public string Nom_devis { get; set; }

        public DateTime Date_creation { get; set; }

        public int Marge_entreprise { get; set; }

        [ForeignKey(typeof(Remise))]
        public int Remise_id { get; set; }

        [OneToOne]
        public Remise Remise { get; set; }

        [ForeignKey(typeof(DossierTechnique))]
        public int Dossier_technique_id { get; set; }

        [OneToOne]
        public DossierTechnique DossierTechnique { get; set; }

        [ForeignKey(typeof(TypeEtat)), NotNull]
        public int Type_etat_id { get; set; }

        [OneToOne]
        public TypeEtat Type_etat { get; set; }
    }
}
