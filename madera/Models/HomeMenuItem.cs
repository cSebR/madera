using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    public enum MenuItemType
    {
        Profil,
        Projet,
        Client,
        Deconnexion
        
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
