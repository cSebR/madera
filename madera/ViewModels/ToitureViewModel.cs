using madera.Models;
using madera.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class ToitureViewModel : BaseViewModel
    {
        private readonly ToitureService toitureService = new ToitureService();

        // -------------------------------------------------------------------

        public void LoadToiture()
        {
            Toitures = toitureService.GetAllToitureAsync().Result;
        }

        // -------------------------------------------------------------------

        private List<Toiture> _toitures;
        public List<Toiture> Toitures
        {
            get
            {
                return _toitures;
            }

            set
            {
                _toitures = value;
                OnPropertyChanged();
            }
        }

        /**
         * Choix Toiture
         */
        private Toiture _selectedToiture;
        public Toiture SelectedToiture
        {
            get
            {
                return _selectedToiture;
            }

            set
            {
                _selectedToiture = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        /**
         * Ajoute une toiture
         */
        private Command _btnToiture;
        public Command BtnToiture
        {
            get
            {
                if (_btnToiture == null)
                {
                    _btnToiture = new Command(async () =>
                    {
                        MessagingCenter.Send<BaseViewModel, Toiture>(this, "AddToiture", _selectedToiture);
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnToiture;
            }
        }
    }
}
