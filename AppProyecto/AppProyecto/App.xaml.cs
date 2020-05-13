using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppProyecto.Services;
using AppProyecto.Views;

namespace AppProyecto
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MySqlDataStore>();
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
