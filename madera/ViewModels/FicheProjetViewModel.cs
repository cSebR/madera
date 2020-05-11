using madera.Models;
using madera.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace madera.ViewModels
{
    public class FicheProjetViewModel : BaseViewModel
    {
        public FicheProjetViewModel(ProjetModel projetModel)
        {
            ProjetModel = projetModel;
        }

        // -------------------------------------------------------------------

        private ProjetModel _projetModel;
        public ProjetModel ProjetModel
        {
            get
            {
                return _projetModel;
            }

            set
            {
                _projetModel = value;
                OnPropertyChanged();
            }
        }

        // -------------------------------------------------------------------

        private Command _addPlan;
        public Command AddPlan
        {
            get
            {
                if(_addPlan == null)
                {
                    _addPlan = new Command(async () =>
                    {
                        MessagingCenter.Send<BaseViewModel, ProjetModel>(this, "AddPlan", _projetModel);
                    });
                }
                return _addPlan;
            }
        }
    }
}
