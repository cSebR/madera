using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("module")]
    public class Module
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(75)]
        public string NomModule { get; set; }

        [ForeignKey(typeof(Plan))]
        public int PlanReference { get; set; }

        [ManyToOne]
        public Plan Plan { get; set; }

        [ForeignKey(typeof(CoupePrincipe)), NotNull]
        public string CoupePrincipeReference { get; set; }

        [ManyToOne]
        public CoupePrincipe CoupePrincipe { get; set; }

        [ForeignKey(typeof(Plancher))]
        public string PlancherReference { get; set; }

        [ManyToOne]
        public Plancher Plancher { get; set; }

        [ForeignKey(typeof(Toiture))]
        public string ToitureReference { get; set; }

        [ManyToOne]
        public Toiture Toiture { get; set; }

        [ForeignKey(typeof(Panneau))]
        public string PanneauReference { get; set; }

        [ManyToOne]
        public Panneau Panneau { get; set; }

        [ForeignKey(typeof(Bardage))]
        public string BardageReference { get; set; }

        [ManyToOne]
        public Bardage Bardage { get; set; }

        public List<Article> getAllArticle()
        {
            return new List<Article>()
            {
                CoupePrincipe,
                Plancher,
                Toiture,
                Panneau,
                Bardage
            };
        }
    }
}
