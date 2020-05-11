using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("plan")]
    public class Plan
    {
        [PrimaryKey, AutoIncrement]
        public long Reference { get; set; }

        [MaxLength(85)]
        public string Nom { get; set; }

        public DateTime CreeLe { get; set; }

        [ForeignKey(typeof(Utilisateur)), NotNull]
        public long CreeParId { get; set; }

        [OneToOne]
        public Utilisateur CreePar { get; set; }

        [ForeignKey(typeof(Utilisateur))]
        public long ModifieParId { get; set; }

        [OneToOne]
        public Utilisateur ModifiePar { get; set; }

        [ForeignKey(typeof(ProjetModel))] 
        public int ProjetModelId { get; set; }

        [ManyToOne] 
        public ProjetModel ProjetModel { get; set; }

        [OneToMany]
        public List<Module> Modules { get; set; }

    }
}
