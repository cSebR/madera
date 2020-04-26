using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    [Table("role")]
    public class Role
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(60)]
        public string Nom { get; set; }

        [OneToMany]
        public List<Utilisateur> Utilisateurs { get; set;}
    }
}
