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
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public void Insertar(Reserva reserva)
        {
            Validations.SonLosDatosDeReservaValidos(reserva);

            _reservaRepository.Insertar(reserva);
        }

        public void Actualizar(int id, Reserva reserva)
        {
            Validations.SonLosDatosDeReservaValidos(reserva);

            _reservaRepository.Actualizar(id, reserva);
        }

        public void Eliminar(int id)
        {
            _reservaRepository.Eliminar(id);
        }

        public List<Reserva> ObtenerTodos()
        {
            return _reservaRepository.ObtenerTodos();
        }

        public Reserva BuscarPorId(int id)
        {
            var reserva = _reservaRepository.BuscarPorId(id);
            if (reserva == null)
            {
                throw new ArgumentException("No existe una reserva con ese ID");
            }

            return reserva;
        }
    }

}