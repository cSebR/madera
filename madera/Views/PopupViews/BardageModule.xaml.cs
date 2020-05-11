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
    public partial class BardageModule : PopupPage
    {
        public BardageModule()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((BardageViewModel)this.BindingContext).LoadBardage();
        }
    }
}