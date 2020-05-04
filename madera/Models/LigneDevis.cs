using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    public class LigneDevis
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public int Quantite { get; set; }

        [ForeignKey(typeof(Article)), NotNull]
        public int ArticleReference { get; set; }

        [ManyToOne]
        public Article Article { get; set; }

        [ForeignKey(typeof(Devis)), NotNull]
        public int DevisReference { get; set; }

        [ManyToOne]
        public Devis Devis { get; set; }
    }
}
