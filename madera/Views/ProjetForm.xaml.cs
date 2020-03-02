using System;
using System.Collections.Generic;
using madera.Models;
using Xamarin.Forms;
using madera.Views;
using Xamarin.Forms.Xaml;

namespace madera.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjetForm : ContentPage
    {
        public ProjetForm()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //ClientList.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnSaveProjetClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NomProjetEntry.Text))
            {
                await App.Database.SaveProjetAsync(new ProjetModel
                {
                    Nom = NomProjetEntry.Text,
                    //Prenom = NomClientEntry.Text
                    //Age = int.Parse(ageEntry.Text)
                });

                NomProjetEntry.Text = string.Empty;
                //ClientList.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }
}