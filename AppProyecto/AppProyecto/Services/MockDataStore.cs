using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppProyecto.Models;

namespace AppProyecto.Services
{
    public class MockDataStore : IDataStore<Persona>
    {
        readonly List<Persona> personas;

        public MockDataStore()
        {
            personas = new List<Persona>()
            {
                new Persona { Id = Guid.NewGuid().ToString(), Nombre = "Rubén González Villanueva", Edad = 20, Correo = "rubengv1999@gmail.com" },
                new Persona { Id = Guid.NewGuid().ToString(), Nombre = "Cianny Masis Aguilar", Edad = 20 , Correo = "ciannymasis@gmail.com"},
                new Persona { Id = Guid.NewGuid().ToString(), Nombre = "David González Villanueva", Edad = 17, Correo = "davidgv03@gmail.com" }
            };
        }

        public async Task<bool> AddItemAsync(Persona persona)
        {
            personas.Add(persona);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Persona persona)
        {
            var oldItem = personas.Where((Persona arg) => arg.Id == persona.Id).FirstOrDefault();
            personas.Remove(oldItem);
            personas.Add(persona);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = personas.Where((Persona arg) => arg.Id == id).FirstOrDefault();
            personas.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Persona> GetItemAsync(string id)
        {
            return await Task.FromResult(personas.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Persona>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(personas);
        }
    }
}