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
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();
            this.BindingContext = new ClientViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ClientViewModel)this.BindingContext).Init();
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