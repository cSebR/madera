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
        public FicheProjet(string Nom, string Date, int ClientId)
        {
            InitializeComponent();
            BindingContext = new ProjetViewModel();
            //IDEntry.Text = ID.ToString();
            NameEntry.Text = Nom;
            DateEntry.Text = Date.ToString();
            //ClientIdEntry.Text = ClientId.ToString();
            //NameClientEntry.Text = ClientNom;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ProjetViewModel)this.BindingContext).Init();

        }

       
            
    }
}