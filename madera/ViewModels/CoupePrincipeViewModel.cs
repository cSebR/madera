using madera.Models;
using madera.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class CoupePrincipeViewModel : BaseViewModel
    {
        private readonly CoupePrincipeService coupePrincipeService = new CoupePrincipeService();

        // -------------------------------------------------------------------

        public CoupePrincipeViewModel()
        {
            
        }

        // -------------------------------------------------------------------

        public void LoadCoupesPrincipe()
        {
            CoupesPrincipes = coupePrincipeService.GetAllCoupePrincipeAsync().Result;
        }

        // -------------------------------------------------------------------

        private List<CoupePrincipe> _coupesPrincipes;
        public List<CoupePrincipe> CoupesPrincipes
        {
            get
            {
                return _coupesPrincipes;
            }

            set
            {
                _coupesPrincipes = value;
                OnPropertyChanged();
            }
        }

        /**
         * Choix Coupe Principe
         */
        private CoupePrincipe _selectedCoupePrincipe;
        public CoupePrincipe SelectedCoupePrincipe
        {
            get
            {
                return _selectedCoupePrincipe;
            }

            set
            {
                _selectedCoupePrincipe = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        /**
         * Ajoute une coupe au module
         */
        private Command _btnCoupePrincipe;
        public Command BtnCoupePrincipe
        {
            get
            {
                if (_btnCoupePrincipe == null)
                {
                    _btnCoupePrincipe = new Command(async () =>
                    {
                        MessagingCenter.Send<BaseViewModel, CoupePrincipe>(this, "AddCoupePrincipe", _selectedCoupePrincipe);
                        await PopupNavigation.Instance.PopAsync();
                    });
                }
                return _btnCoupePrincipe;
            }
        }
    }
}
