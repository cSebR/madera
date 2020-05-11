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
        // -------------------------------------------------------------------

        public PlanHomeViewModel(ProjetModel projetModel)
        {
            Devis = new Devis();
            Plan = new Plan();
            LigneDevis = new ObservableCollection<LigneDevis>();
            Modules = new ObservableCollection<Module>();
            Module = new Module();
            _resetNameField();
            _registerMessenger();
        }

        // -------------------------------------------------------------------

        private void _registerMessenger()
        {
            MessagingCenter.Subscribe<BaseViewModel, CoupePrincipe>(this, "AddCoupePrincipe", (sender, _selectedCoupePrincipe) => {
                Module.CoupePrincipe = _selectedCoupePrincipe;
                NomCoupePrincipe = _selectedCoupePrincipe.Reference;
            });

            MessagingCenter.Subscribe<BaseViewModel, Plancher>(this, "AddPlancher", (sender, _selectedPlancher) => {
                Module.Plancher = _selectedPlancher;
                NomPlancher = _selectedPlancher.Reference;
            });

            MessagingCenter.Subscribe<BaseViewModel, Toiture>(this, "AddToiture", (sender, _selectedToiture) => {
                Module.Toiture = _selectedToiture;
                NomToiture = _selectedToiture.Reference;
            });

            MessagingCenter.Subscribe<BaseViewModel, Panneau>(this, "AddPanneau", (sender, _selectedPanneau) => {
                Module.Panneau = _selectedPanneau;
                NomPanneaux = _selectedPanneau.Reference;
            });

            MessagingCenter.Subscribe<BaseViewModel, Bardage>(this, "AddBardage", (sender, _selectedBardage) => {
                Module.Bardage = _selectedBardage;
                NomBardage = _selectedBardage.Reference;
            });
        }

        private void _resetNameField()
        {
            NomCoupePrincipe = "choix coupe de principe";
            NomPlancher = "choix plancher";
            NomToiture = "choix toiture";
            NomPanneaux = "choix panneaux";
            NomBardage = "choix bardage";
        }

        // -------------------------------------------------------------------

        /**
         * Articles du paniers
         */
        private ObservableCollection<LigneDevis> _ligneDevis;
        public ObservableCollection<LigneDevis> LigneDevis
        {
            get
            {
                return _ligneDevis;
            }

            set
            {
                _ligneDevis = value;
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
        
        private ProjetModel _projet;
        public ProjetModel Projet
        {
            get
            {
                return _projet;
            }

            set
            {
                _projet = value;
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

        /**
         * Ajoute un article au devis
         */
        private void _addModuleArticle()
        {
            foreach(Article Article in Module.getAllArticle())
            {
                if(Article!=null)
                {
                    if(!_articleIsPresent(Article))
                    {
                        float totalLigne = Article.PrixHT * Article.QuantiteDefaut;
                        LigneDevis.Add(new LigneDevis
                        {
                            Article = Article,
                            ArticleReference = Article.Reference,
                            Devis = Devis,
                            Quantite = Article.QuantiteDefaut,
                            PrixHT = totalLigne,
                            PrixTTC = totalLigne * 1.2f
                        });
                    }
                }
            }
        }

        /**
         * Vérifie que l'article n'est pas déjà présent dans le devis
         */
        private bool _articleIsPresent(Article article)
        {
            foreach(LigneDevis ld in _ligneDevis)
            {
                if(ld.Article.Reference.Equals(article.Reference))
                {
                    ld.Quantite += article.QuantiteDefaut;
                    ld.PrixHT = ld.Quantite * ld.Article.PrixHT;
                    return true;
                }
            }
            return false;
        }

        /**
         * Calcul le montant total du panier
         */
        private void _calculerTotal()
        {
            float total = 0;
            
            foreach(LigneDevis ld in LigneDevis)
            {
                total += (ld.Article.PrixHT * ld.Quantite);
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
                        await PopupNavigation.Instance.PushAsync(new CoupePrincipeModule());
                    });
                }
                return _btnCoupePrincipal;
            }
        }        
        
        private Command _btnPlancher;
        public Command BtnPlancher
        {
            get
            {
                if (_btnPlancher == null)
                {
                    _btnPlancher = new Command(async () =>
                    {
                        await PopupNavigation.Instance.PushAsync(new PlancherModule());
                    });
                }
                return _btnPlancher;
            }
        }

        private Command _btnToiture;
        public Command BtnToiture
        {
            get
            {
                if (_btnToiture == null)
                {
                    _btnToiture = new Command(async () =>
                    {
                        await PopupNavigation.Instance.PushAsync(new ToitureModule());
                    });
                }
                return _btnToiture;
            }
        }

        private Command _btnPanneau;
        public Command BtnPanneau
        {
            get
            {
                if (_btnPanneau == null)
                {
                    _btnPanneau = new Command(async () =>
                    {
                        await PopupNavigation.Instance.PushAsync(new PanneauModule());
                    });
                }
                return _btnPanneau;
            }
        }

        private Command _btnBardage;
        public Command BtnBardage
        {
            get
            {
                if (_btnBardage == null)
                {
                    _btnBardage = new Command(async () =>
                    {
                        await PopupNavigation.Instance.PushAsync(new BardageModule());
                    });
                }
                return _btnBardage;
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
                        // Ajoute le module à la liste des modules du plan
                        Modules.Add(Module);

                        // Ajoute les articles du modules dans la liste des articles
                        _addModuleArticle();

                        // Reset le nom des champs du choix du module
                        _resetNameField();

                        // Calcul le total du panier
                        _calculerTotal();

                        // Reset le module
                        Module = new Module();

                        // Supprime le popup
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnAddModule;
            }
        }

        // -------------------------------------------------------------------

        /**
         * Création d'un module
         */
        private string _nomCoupePrincipe;
        public string NomCoupePrincipe
        {
            get
            {
                return _nomCoupePrincipe;
            }

            set
            {
                _nomCoupePrincipe = value;
                OnPropertyChanged();
            }
        }

        private string _nomPlancher;
        public string NomPlancher
        {
            get
            {
                return _nomPlancher;
            }

            set
            {
                _nomPlancher = value;
                OnPropertyChanged();
            }
        }

        private string _nomToiture;
        public string NomToiture
        {
            get
            {
                return _nomToiture;
            }

            set
            {
                _nomToiture = value;
                OnPropertyChanged();
            }
        }

        private string _nomPanneaux;
        public string NomPanneaux
        {
            get
            {
                return _nomPanneaux;
            }

            set
            {
                _nomPanneaux = value;
                OnPropertyChanged();
            }
        }

        private string _nomBardage;
        public string NomBardage
        {
            get
            {
                return _nomBardage;
            }

            set
            {
                _nomBardage = value;
                OnPropertyChanged();
            }
        }
    }
}
