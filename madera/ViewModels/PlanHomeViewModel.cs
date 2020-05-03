using madera.Models;
using madera.Views.PopupViews;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class PlanHomeViewModel : BaseViewModel
    {
        //--------------------------------------------------------------------

        public PlanHomeViewModel()
        {
            this.Devis = new Devis();
            this.Plan = new Plan();
            this.Articles = new ObservableCollection<Article>();
            this.Modules = new ObservableCollection<Module>();
            this.Module = new Module();
        }

        //--------------------------------------------------------------------

        /**
         * Articles du paniers
         */
        private ObservableCollection<Article> _articles;
        public ObservableCollection<Article> Articles
        {
            get
            {
                return _articles;
            }

            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }

        /**
         * Liste des modules du devis
         */
        private ObservableCollection<Module> _modules;
        public ObservableCollection<Module> Modules
        {
            get
            {
                return _modules;
            }

            set
            {
                _modules = value;
                OnPropertyChanged();
            }
        }

        /**
         * Devis
         */
        private Devis _devis;
        public Devis Devis
        {
            get
            {
                return _devis;
            }

            set
            {
                _devis = value;
                OnPropertyChanged();
            }
        }

        /**
         * Plan
         */
        private Plan _plan;
        public Plan Plan
        {
            get
            {
                return _plan;
            }

            set
            {
                _plan = value;
                OnPropertyChanged();
            }
        }

        /**
         * Total TTC
         */
        private float _totalTtc;
        public float TotalTtc
        {
            get
            {
                return _totalTtc;
            }

            set
            {
                _totalTtc = value;
                OnPropertyChanged();
            }
        }

        /**
         * Total TTC
         */
        private float _totalHt;
        public float TotalHt
        {
            get
            {
                return _totalHt;
            }

            set
            {
                _totalHt = value;
                OnPropertyChanged();
            }
        }


        /**
         * Module en édition
         */
        private Module _module;
        public Module Module
        {
            get
            {
                return _module;
            }

            set
            {
                _module = value;
                OnPropertyChanged();
            }
        }

        //--------------------------------------------------------------------

        private void _calculerTotal()
        {
            float total = 0;
            
            foreach(Article Article in Articles)
            {
                total += Article.PrixHT;
            }

            TotalHt = total;
            TotalTtc = total * 1.2f;
        }

        //--------------------------------------------------------------------

        /**
         * Commande lors d'une action sur le bouton "Créer Module"
         */
        private Command _btnModule;
        public Command BtnModule
        {
            get
            {
                if (_btnModule == null)
                {
                    _btnModule = new Command(async () =>
                    {
                        await PopupNavigation.Instance.PushAsync(new ModulePage(this));
                    },
                    () =>
                    {
                        /**
                         * Désactive le bouton de connexion tant que l'utilisateur 
                         * n'a pas remplie tous les champs
                         */
                        //!string.IsNullOrWhiteSpace(Utilisateur_email) && !string.IsNullOrWhiteSpace(Utilisateur_password)
                        return true;
                    });
                }
                return _btnModule;
            }
        }

        /**
         * Commande lors d'une action sur le bouton "Choix Coupe Principal"
         */
        private Command _btnCoupePrincipal;
        public Command BtnCoupePrincipal
        {
            get
            {
                if (_btnCoupePrincipal == null)
                {
                    _btnCoupePrincipal = new Command(async () =>
                    {
                        await PopupNavigation.Instance.PushAsync(new CoupePrincipeModule(this));
                    },
                    () =>
                    {
                        /**
                         * Désactive le bouton de connexion tant que l'utilisateur 
                         * n'a pas remplie tous les champs
                         */
                        //!string.IsNullOrWhiteSpace(Utilisateur_email) && !string.IsNullOrWhiteSpace(Utilisateur_password)
                        return true;
                    });
                }
                return _btnCoupePrincipal;
            }
        }

        /**
         * Commande lors d'une action sur le bouton "Créer Module"
         */
        private Command _btnAddModule;
        public Command BtnAddModule
        {
            get
            {
                if (_btnAddModule == null)
                {
                    _btnAddModule = new Command( async () =>
                    {
                        this.Articles.Add(new Article
                        {
                            Nom = "Article #1",
                            Reference = 12345645465,
                            PrixHT = 100.25f
                        });                        
                        this.Articles.Add(new Article
                        {
                            Nom = "Article #2",
                            Reference = 123454545465,
                            PrixHT = 280.25f
                        });                        
                        this.Articles.Add(new Article
                        {
                            Nom = "Article #3",
                            Reference = 12332147465,
                            PrixHT = 360.99f
                        });                        
                        this.Articles.Add(new Article
                        {
                            Nom = "Article #4",
                            Reference = 12332445465,
                            PrixHT = 999.99f
                        });                        
                        this.Articles.Add(new Article
                        {
                            Nom = "Article #5",
                            Reference = 12345895465,
                            PrixHT = 499.99f
                        });
                        _calculerTotal();
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnAddModule;
            }
        }
    }
}
