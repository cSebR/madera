using madera.Models;
using madera.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupView : PopupPage
    {
        public PopupView()
        {
            InitializeComponent();
            this.BindingContext = new ClientViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ClientViewModel)this.BindingContext).Init();

        }

        private void UpdateSelectionData(IEnumerable<object> currentSelectedItems)
        {
            string current = (currentSelectedItems.FirstOrDefault() as ClientModel)?.ID.ToString();
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
            Debug.WriteLine("id: " + current);
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.CurrentSelection);
        }

        async private void BtnSave_Clicked(object sender, EventArgs e)
        {

            if ((!string.IsNullOrWhiteSpace(NomProjet.Text)) && (!string.IsNullOrWhiteSpace(currentSelectedItemLabel.Text)))
            {
                int Clientid = Convert.ToInt32(currentSelectedItemLabel.Text);
                Debug.WriteLine("item : " + Clientid);
                await App.Database.SaveProjetAsync(new ProjetModel
                {
                    Nom = NomProjet.Text,
                    Date = DateTime.Now.ToString("dd-MM-yyyy"),
                    Ref = NomProjet.Text + 1,
                    Created_by = 1,
                    ClientId = Clientid
                });
                await Navigation.RemovePopupPageAsync(this);

            }
            else
            {

                ErrorLabel.Text = "Veuillez entrer le nom du projet";
                base.OnAppearing();
            }
            //
        }

        async private void BtnClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.RemovePopupPageAsync(this);
        }
    }
}