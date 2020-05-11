using madera.Models;
using madera.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class PanneauViewModel : BaseViewModel
    {
        private readonly PanneauService panneauService = new PanneauService();

        // -------------------------------------------------------------------

        public void LoadPanneau()
        {
            Panneaux = panneauService.GetAllPanneauAsync().Result;
        }

        // -------------------------------------------------------------------

        private List<Panneau> _panneaux;
        public List<Panneau> Panneaux
        {
            get
            {
                return _panneaux;
            }

            set
            {
                _panneaux = value;
                OnPropertyChanged();
            }
        }

        /**
         * Choix Panneau
         */
        private Panneau _selectedPanneau;
        public Panneau SelectedPanneau
        {
            get
            {
                return _selectedPanneau;
            }

            set
            {
                _selectedPanneau = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        /**
         * Ajout Panneau
         */
        private Command _btnPanneau;
        public Command BtnPanneau
        {
            get
            {
                if (_btnPanneau == null)
                {
                    _btnPanneau = new Command(async () =>
                    {
                        MessagingCenter.Send<BaseViewModel, Panneau>(this, "AddPanneau", _selectedPanneau);
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnPanneau;
            }
        }
    }
}
