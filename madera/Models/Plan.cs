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
        public long PlanReference { get; set; }

        [MaxLength(85)]
        public string PlanNom { get; set; }

        public DateTime Date_creation { get; set; }

        [ForeignKey(typeof(Utilisateur)), NotNull]
        public long PlanCreeParId { get; set; }

        [OneToOne]
        public Utilisateur PlanCreePar { get; set; }

        [ForeignKey(typeof(Utilisateur))]
        public long PlanModifieParId { get; set; }

        [OneToOne]
        public Utilisateur PlanModifiePar { get; set; }

        [ManyToMany(typeof(PlanModule))]
        public List<Module> Modules { get; set; }
    }
}
