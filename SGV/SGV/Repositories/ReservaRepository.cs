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
    namespace SGV.Repositories
    {
        public class ReservaRepository : IReservaRepository
        {
            private readonly string _connectionString;

            public ReservaRepository()
            {
                _connectionString = AppSettings.DBstring;
            }

            public void Insertar(Reserva reserva)
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var query = @"INSERT INTO Reservas (id_cliente, id_destino, id_transporte, fecha_reserva, cantidad_personas)
                          VALUES (@cliente, @destino, @transporte, @fecha, @cantidad)";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente", reserva.IdCliente);
                command.Parameters.AddWithValue("@destino", reserva.IdDestino);
                command.Parameters.AddWithValue("@transporte", reserva.IdTransporte);
                command.Parameters.AddWithValue("@fecha", reserva.FechaReserva);
                command.Parameters.AddWithValue("@cantidad", reserva.CantidadPersonas);

                command.ExecuteNonQuery();
            }

            public void Actualizar(int id, Reserva reserva)
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var query = @"UPDATE Reservas
                          SET id_cliente = @cliente,
                              id_destino = @destino,
                              id_transporte = @transporte,
                              fecha_reserva = @fecha,
                              cantidad_personas = @cantidad
                          WHERE id_reserva = @id";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cliente", reserva.IdCliente);
                command.Parameters.AddWithValue("@destino", reserva.IdDestino);
                command.Parameters.AddWithValue("@transporte", reserva.IdTransporte);
                command.Parameters.AddWithValue("@fecha", reserva.FechaReserva);
                command.Parameters.AddWithValue("@cantidad", reserva.CantidadPersonas);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }

            public void Eliminar(int id)
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var query = "DELETE FROM Reservas WHERE id_reserva = @id";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }

            public Reserva BuscarPorId(int id)
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var query = "SELECT * FROM Reservas WHERE id_reserva = @id";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Reserva
                    {
                        IdReserva = (int)reader["id_reserva"],
                        IdCliente = (int)reader["id_cliente"],
                        IdDestino = (int)reader["id_destino"],
                        IdTransporte = (int)reader["id_transporte"],
                        FechaReserva = (DateTime)reader["fecha_reserva"],
                        CantidadPersonas = (int)reader["cantidad_personas"],
                        Total = reader["total"] == DBNull.Value ? 0 : (decimal)reader["total"]
                    };
                }

                return null;
            }

            public List<Reserva> ObtenerTodos()
            {
                var lista = new List<Reserva>();
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                var query = "SELECT * FROM Reservas";
                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Reserva
                    {
                        IdReserva = (int)reader["id_reserva"],
                        IdCliente = (int)reader["id_cliente"],
                        IdDestino = (int)reader["id_destino"],
                        IdTransporte = (int)reader["id_transporte"],
                        FechaReserva = (DateTime)reader["fecha_reserva"],
                        CantidadPersonas = (int)reader["cantidad_personas"],
                        Total = reader["total"] == DBNull.Value ? 0 : (decimal)reader["total"]
                    });
                }

                return lista;
            }
        }
    }
}
