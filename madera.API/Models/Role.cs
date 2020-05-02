using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace madera.API.Models
{
    [Table("role")]
    public class Role
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(60)")]
        [Required]
        public string Nom { get; set; }

        [JsonIgnore]
        public List<Utilisateur> Utilisateurs { get; set; }
    }
}
