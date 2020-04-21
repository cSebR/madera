using madera.Models;
using madera.Services;
using madera.Views;
using System.Net;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace madera.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        /**
         * Service d'intérrogation API
         */
        private readonly AuthService _serviceAuth = new AuthService();

        //--------------------------------------------------------------------

        /**
         * Constructeur
         */
        public LoginViewModel()
        {
            Title = "Authentification";
            ErrorMessage();
            Utilisateur_email    = "admin@admin.com";
            Utilisateur_password = "123456";
        }

        //--------------------------------------------------------------------

        private bool _utilisateur_email_read_only;
        public bool Utilisateur_email_read_only
        {
            get
            {
                return _utilisateur_email_read_only;
            }

            set
            {
                _utilisateur_email_read_only = value;
                OnPropertyChanged();
            }
        }

        /**
         * Input Utilisateur_email
         */
        private string _utilisateur_email;
        public string Utilisateur_email
        {
            get
            {
                return _utilisateur_email;
            }

            set
            {
                _utilisateur_email = value;
                OnPropertyChanged();
                ((Command)Login).ChangeCanExecute();
            }
        }

        /**
         * Input Utilisateur_password
         */
        private string _utilisateur_password;
        public string Utilisateur_password
        {
            get
            {
                return _utilisateur_password;
            }

            set
            {
                _utilisateur_password = value;
                OnPropertyChanged();
                ((Command)Login).ChangeCanExecute();
            }
        }

        /**
         * Visibilité message d'erreur
         */
        private bool _errorIsVisible;
        public bool ErrorIsVisible
        {
            get
            {
                return _errorIsVisible;
            }

            set
            {
                _errorIsVisible = value;
                OnPropertyChanged();
            }
        }
        
        /**
         * Message d'erreur
         */
        private string _messageError;
        public string MessageError
        {
            get
            {
                return _messageError;
            }

            set
            {
                _messageError = value;
                OnPropertyChanged();
            }
        }

        //--------------------------------------------------------------------
        
        /**
         * Commande lors d'une action sur le bouton "Connexion"
         */
        private Command _login;
        public Command Login {
            get
            {
                if( _login == null )
                {
                    _login = new Command(async () =>
                    {
                        Utilisateur user = new Utilisateur
                        {
                            Email = _utilisateur_email,
                            Password = _utilisateur_password
                        };

                        /**
                         * Authentification de l'utilisateur via API
                         * Retourne le code HTTP
                         */
                        HttpStatusCode status = await _serviceAuth.Login(user);

                        switch(status)
                        {
                            case HttpStatusCode.BadRequest:
                                ErrorMessage("Identifiants incorrects, veuillez vérifier votre email et mot de passe.", true);
                                break;
                            case HttpStatusCode.InternalServerError:
                                ErrorMessage("Le serveur est actuellement indisponible, veuillez réessayer ultérieurement.", true);
                                break;
                            case HttpStatusCode.OK:
                                Application.Current.MainPage = new MainPage();
                                ErrorMessage();
                                break;
                        }
                    },
                    () => 
                        /**
                         * Désactive le bouton de connexion tant que l'utilisateur 
                         * n'a pas remplie l'input utilisateur_email et
                         * utilisateur_password
                         */
                        !string.IsNullOrWhiteSpace( Utilisateur_email ) && !string.IsNullOrWhiteSpace( Utilisateur_password)
                    );
                }
                return _login;
            }
        }

        //--------------------------------------------------------------------

        /**
         * Permet d'afficher un message d'erreur au dessus du bouton Connexion
         * Par défaut cette fonction met la variable Message à vide et 
         * cache le label
         * @param string Message message d'erreur à personnaliser
         * @param bool Show Affiche (true) ou Cache (false) le message d'erreur
         */
        private void ErrorMessage( string Message = "", bool Show = false )
        {
            ErrorIsVisible = Show;
            MessageError = Message;
        }
    }
}
