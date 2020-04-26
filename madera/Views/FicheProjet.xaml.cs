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
            BindingContext = new ProjetViewModel();

            ClientIdEntry.Text = projet.ClientId.ToString();
            ClientNameEntry.Text = projet.ClientNom;
            

            ProjetIDEntry.Text = projet.ID.ToString();
            ProjetNameEntry.Text = projet.Nom;
            ProjetDateEntry.Text = projet.Date;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ProjetViewModel)this.BindingContext).Init();

        }

        


    }
}