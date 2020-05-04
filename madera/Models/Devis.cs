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
        public long Reference { get; set; }

        [MaxLength(255)]
        public string Nom { get; set; }

        public DateTime CreeLe { get; set; }

        public int Marge { get; set; }

        [ForeignKey(typeof(Remise))]
        public int RemiseId { get; set; }

        [OneToOne]
        public Remise Remise { get; set; }

        [ForeignKey(typeof(DossierTechnique))]
        public int DossierTechniqueId { get; set; }

        [OneToOne]
        public DossierTechnique DossierTechnique { get; set; }

        [ForeignKey(typeof(TypeEtat)), NotNull]
        public int TypeEtatId { get; set; }

        [ManyToOne]
        public TypeEtat TypeEtat { get; set; }

        [OneToMany]
        public List<LigneDevis> LigneDEvis { get; set; }
    }
}
