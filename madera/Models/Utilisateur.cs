using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(75)]
        public string Nom { get; set; }

        [MaxLength(75)]
        public string Prenom { get; set; }

        [MaxLength(180), Unique]
        public string Email { get; set; }

        public string Password { get; set; }

        [ForeignKey(typeof(Role))]
        public long RoleId { get; set; }

        [ManyToOne] 
        public Role Role { get; set; }
    }
}