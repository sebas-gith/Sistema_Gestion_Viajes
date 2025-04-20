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
    public class TransporteRepository : ITransporteRepository
    {
        private readonly string _connectionString;

        public TransporteRepository()
        {
            _connectionString = AppSettings.DBstring;
        }
        public void Insertar(Transporte transporte)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Transportes(tipo, compania, capacidad, precio_unitario) VALUES(@tipo, @compania, @capacidad, @precio_unitario)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tipo", transporte.Tipo);
            command.Parameters.AddWithValue("@compania", transporte.Compania);
            command.Parameters.AddWithValue("@capacidad", transporte.Capacidad);
            command.Parameters.AddWithValue("@precio_unitario", transporte.Precio_unitario);

            command.ExecuteNonQuery();
        }
        public void Actualizar(int Id, Transporte transporte)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Transportes SET tipo = @tipo, compania = @compania, capacidad = @capacidad, precio_unitario = @precio_unitario WHERE id_transporte = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@tipo", transporte.Tipo);
            command.Parameters.AddWithValue("@compania", transporte.Compania);
            command.Parameters.AddWithValue("@capacidad", transporte.Capacidad);
            command.Parameters.AddWithValue("@precio_unitario", transporte.Precio_unitario);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
        public void Eliminar(int Id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Transportes WHERE id_transporte = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
        public Transporte BuscarPorId(int Id)
        {
            Transporte transporte = new Transporte();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Transportes WHERE id_transporte = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            using var Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                return new Transporte
                {
                    TransporteId = (int)Reader["id_transporte"],
                    Tipo = (string)Reader["tipo"],
                    Capacidad = (int)Reader["capacidad"],
                    Compania = (string)Reader["compania"],
                    Precio_unitario = (decimal)Reader["precio_unitario"]
                };
            }

            return null;
        }
        public List<Transporte> ObtenerTodos()
        {
            List<Transporte> list = new List<Transporte>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Transportes";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader Reader = command.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        list.Add(new Transporte
                        {
                            TransporteId = (int)Reader["id_transporte"],
                            Tipo = (string)Reader["tipo"],
                            Capacidad = (int)Reader["capacidad"],
                            Compania = (string)Reader["compania"],
                            Precio_unitario = (decimal)Reader["precio_unitario"]
                        });
                    }
                }
            }
            return list;
        }
    }
}
