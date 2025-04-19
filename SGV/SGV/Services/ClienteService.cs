using SGV.Entities;
using SGV.Interfaces;
using SGV.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Services
{
    class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void Eliminar(int Id)
        {
            _clienteRepository.Eliminar(Id);
        }
        public void Actualizar(int Id, Cliente cliente)
        {
            Validations.SonLosDatosDelClienteValidos(cliente);
            try
            {
                var mail = new System.Net.Mail.MailAddress(cliente.Correo);
            }
            catch
            {
                throw new ArgumentException("El correo no tiene un formato válido.");
            }
            _clienteRepository.Actualizar(Id, cliente);
        }
        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.ObtenerTodos();
        }
        public Cliente BuscarPorCorreo(string correo)
        {
           Validations.EsElCorreoValido(correo);
            Cliente cliente = _clienteRepository.BuscarPorCorreo(correo);
            if(cliente == null)
            {
                throw new ArgumentException("No existe un cliente con ese correo");
            }
            return cliente;
        }
        public Cliente BuscarPorId(int Id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(Id);
            if (cliente == null)
            {
                throw new ArgumentException("No existe un cliente con ese id");
            }
            return cliente;
        }
        public void Insertar(Cliente cliente)
        {
            Validations.SonLosDatosDelClienteValidos(cliente);
            Validations.EsElCorreoValido(cliente.Correo);

            _clienteRepository.Insertar(cliente);
        }



    }
}
