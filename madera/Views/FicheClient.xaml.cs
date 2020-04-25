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
    public partial class FicheClient : ContentPage
    {
        public FicheClient(ClientModel client)
        {
            InitializeComponent();
            BindingContext = new ClientViewModel();

            NomClientEntry.Text = client.Nom;
            PrenomClientEntry.Text = client.Prenom;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ClientViewModel)this.BindingContext).Init();

        }
    }
}