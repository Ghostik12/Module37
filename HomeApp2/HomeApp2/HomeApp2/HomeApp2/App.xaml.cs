using HomeApp2.Services;
using HomeApp2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
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
