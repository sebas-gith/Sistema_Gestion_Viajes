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
    public class TransporteService : ITransporteService
    {
        private readonly ITransporteRepository _transporteRepository;
        public TransporteService(ITransporteRepository transporteRepository)
        {
            _transporteRepository = transporteRepository;
        }
        public void Eliminar(int Id)
        {
            _transporteRepository.Eliminar(Id);
        }
        public void Actualizar(int Id, Transporte transporte)
        {
            Validations.SonLosDatosDeTransporteValidos(transporte);
         
            _transporteRepository.Actualizar(Id, transporte);
        }
        public List<Transporte> ObtenerTodos()
        {
            return _transporteRepository.ObtenerTodos();
        }
        
        public Transporte BuscarPorId(int Id)
        {
            Transporte transporte = _transporteRepository.BuscarPorId(Id);
            if (transporte == null)
            {
                throw new ArgumentException("No existe un cliente con ese id");
            }
            return transporte;
        }
        public void Insertar(Transporte transporte)
        {
            Validations.SonLosDatosDeTransporteValidos(transporte);

            _transporteRepository.Insertar(transporte);
        }



    }
}
