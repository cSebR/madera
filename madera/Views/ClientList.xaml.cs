﻿using madera.Models;
using madera.Services;
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
    
    public partial class ClientList : ContentPage
    {
        public ClientList()
        {
            InitializeComponent();
            this.BindingContext = new ClientViewModel();
        }

        // -------------------------------------------------------------------

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((ClientViewModel)this.BindingContext).Init();
        }

        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as ClientModel;

            await Navigation.PushAsync(new FicheClient(Selected));
        }
    }
}