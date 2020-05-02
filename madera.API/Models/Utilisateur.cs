using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace madera.API.Models
{
    [Table("utilisateur")]
    [JsonObject(MemberSerialization.OptIn)]
    public class Utilisateur
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        [Column(TypeName = "varchar(75)")]
        [Required]
        public string Nom { get; set; }

        [JsonProperty]
        [Column(TypeName = "varchar(60)")]
        [Required]
        public string Prenom { get; set; }

        [JsonProperty]
        [Column(TypeName = "varchar(180)")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        public string PlainPassword { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [JsonProperty]
        public Role Role { get; set; }
    }
}
