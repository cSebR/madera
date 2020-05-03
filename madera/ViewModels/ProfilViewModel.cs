using madera.Models;
using madera.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace madera.ViewModels
{
    public class ProfilViewModel : BaseViewModel
    {
        /**
         * Service d'intérrogation API
         */
        private readonly AuthService _serviceAuth = new AuthService();

        public ProfilViewModel()
        {
            Title = "Profil";
            Task<Utilisateur> task = _serviceAuth.GetUtilisateurAsync();
            task.Wait();
            Utilisateur = task.Result;
        }

        private Utilisateur _utilisateur;
        public Utilisateur Utilisateur
        {
            get
            {
                return _utilisateur;
            }

            set
            {
                _utilisateur = value;
                OnPropertyChanged();
            }
        }
    }
}
