using madera.Models;
using madera.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace madera.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicheProjet : ContentPage
    {
        public FicheProjet(ProjetModel projet)
        {
            InitializeComponent();
            BindingContext = new FicheProjetViewModel(projet);

            MessagingCenter.Subscribe<BaseViewModel, ProjetModel>(this, "AddPlan", async (sender, projetModel) => {
                await Navigation.PushAsync(new PlanHome(projetModel));
            });
        }
    }
}