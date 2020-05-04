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
    public partial class FicheClient : ContentPage
    {
        public FicheClient(ClientModel client)
        {
            InitializeComponent();
            BindingContext = new FicheClientViewModel(client);

            MessagingCenter.Subscribe<BaseViewModel, string[]>(this, "DisplayAlert", async (sender, values) => {
                bool answer = await DisplayAlert(values[0], values[1], values[2], values[3]);

                if(answer)
                {
                    await ((FicheClientViewModel)BindingContext).RemoveClientAsync();
                    await Navigation.PushAsync(new ClientList());
                }
            });
        }
    }
}