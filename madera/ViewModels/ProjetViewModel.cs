using madera.Models;
using madera.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class ProjetViewModel : BaseViewModel
    {

        public ProjetViewModel()
        {
            Title = "Projet";
            Init();
        }

        public void Init()
        {
            Projets = App.Database.GetPeopleAsync().Result;

        }

        private List<ProjetModel> projets;
        public List<ProjetModel> Projets
        {
            get
            {
                return projets;
            }

            set
            {
                projets = value;
                OnPropertyChanged("Projets");
            }
        }

        
    }
}
