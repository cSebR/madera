using madera.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace madera.Views.PopupViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PanneauModule : PopupPage
    {
        public PanneauModule()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((PanneauViewModel)this.BindingContext).LoadPanneau();
        }
    }
}