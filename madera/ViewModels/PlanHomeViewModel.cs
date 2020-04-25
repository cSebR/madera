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
            this.Test = "abcdef";
            this.Article = new ObservableCollection<Article>();
        }

        //--------------------------------------------------------------------

        private string _test;
        public string Test
        {
            get
            {
                return _test;
            }

            set
            {
                _test = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Article> _article;
        public ObservableCollection<Article> Article
        {
            get
            {
                return _article;
            }

            set
            {
                _article = value;
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
         * Commande lors d'une action sur le bouton "Créer Module"
         */
        private Command _btnAddModule;
        public Command BtnAddModule
        {
            get
            {
                if (_btnAddModule == null)
                {
                    _btnAddModule = new Command( () =>
                    {
                        this.Article.Add(
                            new Article
                            {
                                ArticleNom = "Module-Rect-500x750",
                                ArticleReference = 12345674,
                                ArticlePrix = 750
                            }
                        );
                        this.Article.Add(
                            new Article
                            {
                                ArticleNom = "Module-Rect-500x750",
                                ArticleReference = 12345674,
                                ArticlePrix = 750
                            }
                        );
                        this.Article.Add(
                            new Article
                            {
                                ArticleNom = "Module-Rect-500x750",
                                ArticleReference = 12345674,
                                ArticlePrix = 750
                            }
                        );
                        this.Article.Add(
                            new Article
                            {
                                ArticleNom = "Module-Rect-500x750",
                                ArticleReference = 12345674,
                                ArticlePrix = 750
                            }
                        );
                        //await PopupNavigation.Instance.PushAsync(new CoupePrincipeModule());
                    });
                }
                return _btnAddModule;
            }
        }
    }
}
