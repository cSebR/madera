using madera.Models;
using madera.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class PlancherViewModel : BaseViewModel
    {
        private readonly PlancherService plancherService = new PlancherService();

        // -------------------------------------------------------------------

        public void LoadPlanchers()
        {
            Planchers = plancherService.GetAllPlancherAsync().Result;
        }

        // -------------------------------------------------------------------

        private List<Plancher> _planchers;
        public List<Plancher> Planchers
        {
            get
            {
                return _planchers;
            }

            set
            {
                _planchers = value;
                OnPropertyChanged();
            }
        }

        /**
         * Choix Plancher
         */
        private Plancher _selectedPlancher;
        public Plancher SelectedPlancher
        {
            get
            {
                return _selectedPlancher;
            }

            set
            {
                _selectedPlancher = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        /**
         * Ajoute un plancher
         */
        private Command _btnPlancher;
        public Command BtnPlancher
        {
            get
            {
                if (_btnPlancher == null)
                {
                    _btnPlancher = new Command(async () =>
                    {
                        MessagingCenter.Send<BaseViewModel, Plancher>(this, "AddPlancher", _selectedPlancher);
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnPlancher;
            }
        }
    }
}
