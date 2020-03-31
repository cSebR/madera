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
    public partial class FicheProjet : ContentPage
    {
        public FicheProjet(int ID, string Nom, DateTime Date)
        {
            InitializeComponent();
            BindingContext = new ProjetViewModel();
            IDEntry.Text = ID.ToString();
            NameEntry.Text = Nom;
            DateEntry.Text = Date.ToString();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ProjetViewModel)this.BindingContext).Init();

        }
    }
}