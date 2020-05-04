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
        public string Nom_Module { get; set; }

        public double Prix_ht { get; set; }

        [ForeignKey(typeof(Plan))]
        public int PlanReference { get; set; }

        [ManyToOne]
        public Plan Plan { get; set; }
    }
}
