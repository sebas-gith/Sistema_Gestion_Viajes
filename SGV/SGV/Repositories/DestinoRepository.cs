using Microsoft.Data.SqlClient;
using SGV.Entities;
using SGV.Infrastructure;
using SGV.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Repositories
{
    public class DestinoRepository : IDestinoRepository
    {
        private readonly string _connectionString;

        public DestinoRepository()
        {
            _connectionString = AppSettings.DBstring;
        }
        public void Insertar(Destino destino)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Destinos(ciudad, pais, descripcion, precio_base) VALUES(@ciudad, @pais, @descripcion, @precio_base)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ciudad", destino.Ciudad);
            command.Parameters.AddWithValue("@pais", destino.Pais);
            command.Parameters.AddWithValue("@descripcion", destino.Descripcion);
            command.Parameters.AddWithValue("@precio_base", destino.PrecioBase);

            command.ExecuteNonQuery();
        }
        public void Actualizar(int Id, Destino destino)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Destinos SET ciudad = @ciudad, pais = @pais, descripcion = @descripcion, precio_base = @precio_base WHERE id_destino = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ciudad", destino.Ciudad);
            command.Parameters.AddWithValue("@pais", destino.Pais);
            command.Parameters.AddWithValue("@descripcion", destino.Descripcion);
            command.Parameters.AddWithValue("@precio_base", destino.PrecioBase);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
        public void Eliminar(int Id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Destinos WHERE id_destino = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
        public Destino BuscarPorId(int Id)
        {
            Cliente cliente = new Cliente();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Destinos WHERE id_destino = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            using var Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                return new Destino
                {
                    IdDestino = (int)Reader["id_destino"],
                    Ciudad = (string)Reader["ciudad"],
                    Pais = (string)Reader["pais"],
                    Descripcion = (string)Reader["descripcion"],
                    PrecioBase = (decimal)Reader["precio_base"]
                };
            }

            return null;
        }
        public List<Destino> ObtenerTodos()
        {
            List<Destino> list = new List<Destino>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Destinos";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader Reader = command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        list.Add(new Destino
                        {
                            IdDestino = (int)Reader["id_destino"],
                            Ciudad = (string)Reader["ciudad"],
                            Pais = (string)Reader["pais"],
                            Descripcion = (string)Reader["descripcion"],
                            PrecioBase = (decimal)Reader["precio_base"]
                        });
                    }
                }
            }
            return list;
        }
    }
}
