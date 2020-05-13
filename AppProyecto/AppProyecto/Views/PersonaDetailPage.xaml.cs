using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppProyecto.Models;
using AppProyecto.ViewModels;

namespace AppProyecto.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PersonaDetailPage : ContentPage
    {
        PersonaViewModel viewModel;

        public PersonaDetailPage(PersonaViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Editar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaEditPage(viewModel));
        }

        async void Eliminar_Clicked(object sender, EventArgs e)
        {
            bool eliminar = await DisplayAlert("¿Está seguro de eliminar la persona?", "Esta acción es permanente", "Si", "No");
            if(eliminar)
            {
                MessagingCenter.Send(this, "Eliminar", viewModel.Persona);
                await Navigation.PopAsync();
            }
        }
    }
}