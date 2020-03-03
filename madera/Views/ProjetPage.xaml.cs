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
    public partial class ProjetPage : ContentPage
    {
        public ProjetPage()
        {
            InitializeComponent();
            this.BindingContext = new ProjetViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ProjetViewModel)this.BindingContext).Init();
        }

        void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

        }

        async void OnCreateProjetClicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new ProjetForm());
            await DisplayAlert("Nouveau Projet", "Selectionner un client", "Valider");
        }

       
    }
}