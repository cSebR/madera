using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace madera.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {

        public ClientPage()
        {
            InitializeComponent();
        }

        void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
            
        }

        async void OnCreateClientClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientForm());
        }

        //async void OnListClientClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ClientList());
        //}
    }
}