using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppProyecto.Models;
using AppProyecto.Views;
using AppProyecto.ViewModels;

namespace AppProyecto.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PersonasPage : ContentPage
    {
        PersonasViewModel viewModel;

        public PersonasPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PersonasViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var persona = (Persona)layout.BindingContext;
            await Navigation.PushAsync(new PersonaDetailPage(new PersonaViewModel(persona)));
        }

        async void Crear_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PersonaCreatePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Personas.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}