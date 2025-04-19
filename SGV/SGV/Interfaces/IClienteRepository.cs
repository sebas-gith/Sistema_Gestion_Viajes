using SGV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Interfaces
{
    interface IClienteRepository
    {
        public void Insertar(Cliente cliente);
        public void Actualizar(int Id, Cliente cliente);
        public void Eliminar(int Id);
        public Cliente BuscarPorId(int Id);
        public Cliente BuscarPorCorreo(string correo);
        public List<Cliente> ObtenerTodos();
    }
}
