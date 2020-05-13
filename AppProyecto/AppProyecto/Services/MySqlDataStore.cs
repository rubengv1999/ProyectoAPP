using AppProyecto.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProyecto.Services
{
    class MySqlDataStore : IDataStore<Persona>
    {
        readonly string ConnectionString = "server=35.226.81.131;database=proyectoapp;uid=root;pwd=Pa$$w0rd;CharSet=utf8;";
        public MySqlDataStore() { }

        public async Task<bool> AddItemAsync(Persona persona)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand($"INSERT INTO PERSONA VALUES ('{persona.Id}', '{persona.Nombre}', {persona.Edad}, '{persona.Correo}');", connection))
                    {
                        command.ExecuteReader();
                        return await Task.FromResult(true);
                    }
                }
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateItemAsync(Persona persona)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand($"UPDATE PERSONA SET NOMBRE = '{persona.Nombre}', EDAD = {persona.Edad}, CORREO = '{persona.Correo}' WHERE ID = '{persona.Id}';", connection))
                    {
                        command.ExecuteReader();
                        return await Task.FromResult(true);
                    }
                }
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand($"DELETE FROM PERSONA WHERE ID = '{id}';", connection))
                    {
                        command.ExecuteReader();
                        return await Task.FromResult(true);
                    }
                }
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Persona> GetItemAsync(string id)
        {
            Persona persona = null;
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand($"SELECT ID, NOMBRE, EDAD, CORREO FROM PERSONA WHERE ID = '{id}';", connection))
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            persona = new Persona()
                            {
                                Id = reader.GetString(0),
                                Nombre = reader.GetString(1),
                                Edad = reader.GetInt32(2),
                                Correo = reader.GetString(3)
                            };
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(persona);
        }

        public async Task<IEnumerable<Persona>> GetItemsAsync(bool forceRefresh = false)
        {
            var personas = new List<Persona>();
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand("SELECT ID, NOMBRE, EDAD, CORREO FROM PERSONA;", connection))
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            personas.Add(new Persona()
                            {
                                Id = reader.GetString(0),
                                Nombre = reader.GetString(1),
                                Edad = reader.GetInt32(2),
                                Correo = reader.GetString(3)
                            });
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(personas);
        }
    }
}
