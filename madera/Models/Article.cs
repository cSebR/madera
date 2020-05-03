using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    public class Article
    {
        public long Reference { get; set; }
        public string Nom { get; set; }
        public float PrixHT { get; set; }

        public float PrixTTC
        {
            get {
                return PrixHT * 1.2f;
            }
        }
    }
}
