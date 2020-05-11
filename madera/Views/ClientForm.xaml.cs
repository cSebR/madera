using System;
using System.Collections.Generic;
using madera.Models;
using Xamarin.Forms;
using madera.Views;
using madera.ViewModels;

namespace madera.Views
{
    public partial class ClientForm : ContentPage
    {
        public ClientForm()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<BaseViewModel, bool>(this, "BackClient", async (sender, values) => {
                await Navigation.PushAsync(new ClientList());
            });
        }
    }

}
