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
    public class DestinoService : IDestinoService
    {
        private readonly IDestinoRepository _destinoRepository;
        public DestinoService(IDestinoRepository destinoRepository)
        {
            _destinoRepository = destinoRepository;
        }
        public void Insertar(Destino destino)
        {
            Validations.SonLosDatosDelDestinoValidos(destino);

            _destinoRepository.Insertar(destino);
        }
        public void Actualizar(int Id, Destino destino)
        {
            Validations.SonLosDatosDelDestinoValidos(destino);
            _destinoRepository.Actualizar(Id, destino);
        }
        public void Eliminar(int Id)
        {
            _destinoRepository.Eliminar(Id);
        }
        public List<Destino> ObtenerTodos()
        {
            return _destinoRepository.ObtenerTodos();
        }
        public Destino BuscarPorId(int Id)
        {
            Destino destino = _destinoRepository.BuscarPorId(Id);
            if(destino == null)
            {
                throw new ArgumentException("No hay un destino con ese id");
            }
            return destino;
        }
    }
}
