using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("type_etat")]
    public class TypeEtat
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(75)]
        public string Type_etat { get; set; }

        [OneToMany]
        public List<Devis> Devis { get; set; }
    }
}
