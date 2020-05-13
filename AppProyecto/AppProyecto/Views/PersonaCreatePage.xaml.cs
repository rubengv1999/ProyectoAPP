using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppProyecto.Models;

namespace AppProyecto.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PersonaCreatePage : ContentPage
    {
        public Persona Persona { get; set; }

        public PersonaCreatePage()
        {
            InitializeComponent();

            Persona = new Persona() { Id = Guid.NewGuid().ToString() };

            BindingContext = this;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            if(Persona.Nombre == "" || Persona.Edad == 0 || Persona.Correo == "")
            {
                await DisplayAlert("Persona no guardada", "Debe llenar todos los campos", "Aceptar");  
            }
            else
            {
                MessagingCenter.Send(this, "Agregar", Persona);
                await Navigation.PopModalAsync();
            }
           
        }

        async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}