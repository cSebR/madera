using System;
using SQLite;

namespace madera.Models
{
    public partial class ClientModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RefClient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DteNaissance { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Commentaire { get; set; }
        public string NumRue { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }

        public ClientModel()
        {

        }

        public string FullName
        {
            get
            {
                return Nom.ToUpper() + " " + Prenom;
            }
        }
    }
}
