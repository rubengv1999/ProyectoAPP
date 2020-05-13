using AppProyecto.Models;
using AppProyecto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonaEditPage : ContentPage
    {
        public PersonaViewModel viewModel { get; set; }

        public PersonaEditPage(PersonaViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (viewModel.Persona.Nombre == "" || viewModel.Persona.Edad == 0 || viewModel.Persona.Correo == "")
            {
                await DisplayAlert("Persona no guardada", "Debe llenar todos los campos", "Aceptar");
            }
            else
            {
                MessagingCenter.Send(this, "Editar", viewModel.Persona);
                await Navigation.PopToRootAsync();
              //  await Navigation.PopAsync();
            }
        }

        async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}