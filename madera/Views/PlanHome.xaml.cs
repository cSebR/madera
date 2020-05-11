using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using madera.Models;
using madera.ViewModels;
using madera.Views.PopupViews;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace madera.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanHome : ContentPage
    {
        public PlanHome(ProjetModel projetModel)
        {
            InitializeComponent();
            BindingContext = new PlanHomeViewModel(projetModel);
        }
    }
}