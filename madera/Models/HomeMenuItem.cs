using System;
using System.Collections.Generic;
using System.Text;

namespace madera.Models
{
    public enum MenuItemType
    {
        Login,
        Profil,
        Projet,
        Client
        
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
