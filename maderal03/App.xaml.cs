using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using maderal03.Services;
using maderal03.Views;

namespace maderal03
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
