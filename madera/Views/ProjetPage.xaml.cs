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
            var client = await DisplayActionSheet("Selectionner un client","Cancel", "OK", item);
            Debug.WriteLine("Client: " + client);

            
                var client2 = await DisplayActionSheet("Selectionner un client", "Cancel", "OK", item);
                Debug.WriteLine("Client: " + client);

                //Popup Nom du projet
                string result = await DisplayPromptAsync("Entrer le nom du projet", "Nom du projet");
                Debug.WriteLine("Answer: " + result);


                //Enregistrement en base
                if (!string.IsNullOrWhiteSpace(result))
                {
                    //DateTime now = DateTime.Now;
                    var date1 = DateTime.Now.ToString("dd-MM-yyyy");

                    await App.Database.SaveProjetAsync(new ProjetModel
                    {
                        Nom = result,
                        Date = date1,
                        Ref = result + 1,
                        Created_by = 1
                    });

                    //Debug.WriteLine("Date : " + now); 

                    await Navigation.PushAsync(new ProjetList());
                }
            
        }

        async void OnListProjectClicked(object sender, EventArgs e)
        {
            base.OnAppearing();
            await Navigation.PushAsync(new ProjetList());
        }

    }
}