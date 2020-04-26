using System;
using System.Collections.Generic;
using madera.Models;
using Xamarin.Forms;
using madera.Views;

namespace madera.Views
{
    public partial class ClientForm : ContentPage
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        async void OnSaveClientClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NomClientEntry.Text) && !string.IsNullOrWhiteSpace(PrenomClientEntry.Text))
            {
                await App.Database.SaveClientAsync(new ClientModel
                {
                    Nom = NomClientEntry.Text,
                    Prenom = PrenomClientEntry.Text,
                    RefClient = NomClientEntry.Text + PrenomClientEntry.Text + DateTime.Now
                    //Age = int.Parse(ageEntry.Text)
                });

                NomClientEntry.Text = PrenomClientEntry.Text = String.Empty;
                //ClientList.ItemsSource = await App.Database.GetPeopleAsync();
            }

        }

    }

}
