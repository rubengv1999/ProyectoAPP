using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AppProyecto.Models;
using AppProyecto.Views;

namespace AppProyecto.ViewModels
{
    public class PersonasViewModel : BaseViewModel
    {
        public ObservableCollection<Persona> Personas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PersonasViewModel()
        {
            Title = "CRUD de Personas";
            Personas = new ObservableCollection<Persona>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<PersonaCreatePage, Persona>(this, "Agregar", async (obj, persona) =>
            {
                var personaNueva = persona as Persona;
                Personas.Add(personaNueva);
                await DataStore.AddItemAsync(personaNueva);
            });

            MessagingCenter.Subscribe<PersonaEditPage, Persona>(this, "Editar", async (obj, persona) =>
            {
                var personaEditada = persona as Persona;
                Personas.Remove(personaEditada);
                await DataStore.UpdateItemAsync(personaEditada);
            });

            MessagingCenter.Subscribe<PersonaDetailPage, Persona>(this, "Eliminar", async (obj, persona) =>
            {
                var personaBorrada = persona as Persona;
                Personas.Remove(personaBorrada);
                await DataStore.DeleteItemAsync(personaBorrada.Id);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Personas.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Personas.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}