using madera.Models;
using madera.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace madera.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjetList : ContentPage
    {
        public ProjetList()
        {
            InitializeComponent();
            this.BindingContext = new ProjetViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ProjetViewModel)this.BindingContext).Init();

        }

        /* retour sur la fiche projet du client */

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as ProjetModel;
            await Navigation.PushAsync(new FicheProjet(Selected));
        }
    }
}