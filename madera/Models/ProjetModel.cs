using SQLite;
using SQLiteNetExtensions.Attributes;

namespace madera.Models
{
    public class ProjetModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Date { get; set; }
        public string Ref { get; set; }
        public int Created_by { get; set; }

        public override string ToString()
        {
            return Nom;
        }

        [ForeignKey(typeof(ClientModel))]
        public int ClientId { get; set;}

        [ManyToOne]
        public ClientModel Client { get; set; }

        public string ClientNom
        {
            get
            {
                if (Client != null)
                {
                    return Client.Nom;
                }
                return "";
            }
        }
    }
}
