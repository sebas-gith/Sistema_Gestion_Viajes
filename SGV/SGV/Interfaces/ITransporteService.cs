using SGV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Interfaces
{
    public interface ITransporteService
    {
        public void Insertar(Transporte transporte);
        public void Actualizar(int Id, Transporte transporte);
        public void Eliminar(int Id);
        public Transporte BuscarPorId(int Id);
        public List<Transporte> ObtenerTodos();
    }
}
