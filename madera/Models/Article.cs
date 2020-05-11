using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    public abstract class Article
    {
        [PrimaryKey]
        public string Reference { get; set; }
        public string Nom { get; set; }
        public float PrixHT { get; set; }
        public int QuantiteDefaut { get; set; }

        public float PrixTTC
        {
            get {
                return PrixHT * 1.2f;
            }
        }
    }
}
