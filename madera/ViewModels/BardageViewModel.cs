using madera.Models;
using madera.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class BardageViewModel : BaseViewModel
    {
        private readonly BardageService bardageService = new BardageService();

        // -------------------------------------------------------------------

        public void LoadBardage()
        {
            Bardages = bardageService.GetAllBardageAsync().Result;
        }

        // -------------------------------------------------------------------

        private List<Bardage> _bardages;
        public List<Bardage> Bardages
        {
            get
            {
                return _bardages;
            }

            set
            {
                _bardages = value;
                OnPropertyChanged();
            }
        }

        /**
         * Choix Bardage
         */
        private Bardage _selectedBardage;
        public Bardage SelectedBardage
        {
            get
            {
                return _selectedBardage;
            }

            set
            {
                _selectedBardage = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        /**
         * Ajout Bardage
         */
        private Command _btnBardage;
        public Command BtnBardage
        {
            get
            {
                if (_btnBardage == null)
                {
                    _btnBardage = new Command(async () =>
                    {
                        MessagingCenter.Send<BaseViewModel, Bardage>(this, "AddBardage", _selectedBardage);
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnBardage;
            }
        }
    }
}
