using SGV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Interfaces
{
    public interface IReservaRepository
    {
        public void Insertar(Reserva reserva);
        public void Actualizar(int Id, Reserva reserva);
        public void Eliminar(int Id);
        public Reserva BuscarPorId(int Id);
        public List<Reserva> ObtenerTodos();
    }
}
