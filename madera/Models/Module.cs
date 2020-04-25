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

        [ManyToMany(typeof(PlanModule))] 
        public List<Plan> Plans { get; set; }
    }
}
