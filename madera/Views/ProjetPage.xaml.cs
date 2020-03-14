using madera.Models;
using madera.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            base.OnAppearing();

            var item = "client1";

            // Popup choi du client
            var client = await DisplayActionSheet("Selectionner un client","Cancel", null, item);
            Debug.WriteLine("Client: " + client);

            //Popup Nom du projet
            string result = await DisplayPromptAsync("Entrer le nom du projet", "Nom du projet");
       
             Debug.WriteLine("Answer: " + result);


          

            //Enregistrement en base
            if (!string.IsNullOrWhiteSpace(result))
            {

                await App.Database.SaveProjetAsync(new ProjetModel
                {
                    Nom = result,
                    Date = new DateTime(),
                });

                //result = string.Empty;

                await Navigation.PushAsync(new FicheProjet());
            }
        }

    }
}