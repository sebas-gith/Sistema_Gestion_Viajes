using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SGV.Entities;
using SGV.Infrastructure;
using SGV.Interfaces;
using System.Data.SqlClient;
using System.Reflection;

namespace SGV.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository()
        {
            _connectionString = AppSettings.DBstring;
        }
        public void Insertar(Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO Clientes(nombre, correo, telefono, direccion) VALUES (@nombre, @correo, @telefono, @direccion)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@correo", cliente.Correo);
            command.Parameters.AddWithValue("@telefono", cliente.Telefono);
            command.Parameters.AddWithValue("@direccion", cliente.Direccion);

            command.ExecuteNonQuery();
        }
        public void Actualizar(int Id, Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "UPDATE Clientes SET nombre = @nombre, correo = @correo, telefono = @telefono, direccion = @direccion WHERE id_cliente = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@correo", cliente.Correo);
            command.Parameters.AddWithValue("@telefono", cliente.Telefono);
            command.Parameters.AddWithValue("@direccion", cliente.Direccion);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
        public void Eliminar(int Id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "DELETE FROM Clientes WHERE id_cliente = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            command.ExecuteNonQuery();
        }
        public Cliente BuscarPorId(int Id)
        {
            Cliente cliente = new Cliente();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Clientes WHERE id_cliente = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);

            using var Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                return new Cliente
                {
                    IdCliente = (int)Reader["id_cliente"],
                    Nombre = (string)Reader["nombre"],
                    Correo = (string)Reader["correo"],
                    Telefono = (string)Reader["telefono"],
                    Direccion = (string)Reader["direccion"]
                };
            }

            return null;
        }
        
        public Cliente BuscarPorCorreo(string correo)
        {
            Cliente cliente = new Cliente();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var query = "SELECT * FROM Clientes WHERE correo = @correo";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@correo", correo);

            using var Reader = command.ExecuteReader();
            if (Reader.Read())
            {
                return new Cliente
                {
                    IdCliente = (int)Reader["id_cliente"],
                    Nombre = (string)Reader["nombre"],
                    Correo = (string)Reader["correo"],
                    Telefono = (string)Reader["telefono"],
                    Direccion = (string)Reader["direccion"]
                };
            }

            return null;
        }
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> list = new List<Cliente>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Clientes";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Cliente
                        {
                            IdCliente = (int)reader["id_cliente"],
                            Nombre = (string)reader["nombre"],
                            Correo = (string)reader["correo"],
                            Telefono = (string)reader["telefono"],
                            Direccion = (string)reader["direccion"]

                        });
                    }
                }
            }
            return list;
        }
    }
}
