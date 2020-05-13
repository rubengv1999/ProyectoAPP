using System;

using AppProyecto.Models;

namespace AppProyecto.ViewModels
{
    public class PersonaViewModel : BaseViewModel
    {
        public Persona Persona { get; set; }
        public PersonaViewModel(Persona persona = null)
        {
            Title = persona?.Nombre;
            Persona = persona;
        }
    }
}
