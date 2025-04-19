using SGV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Interfaces
{
    public interface IDestinoService
    {
        public void Insertar(Destino destino);
        public void Actualizar(int Id, Destino destino);
        public void Eliminar(int Id);
        public List<Destino> ObtenerTodos();
        public Destino BuscarPorId(int Id);

    }
}
