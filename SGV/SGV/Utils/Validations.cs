using SGV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Utils
{
    public class Validations
    {
        public static void SonLosDatosDelClienteValidos(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Correo))
                throw new ArgumentException("El correo del cliente es obligatorio.");
            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new ArgumentException("El telefono del cliente es obligatorio. ");
            if (string.IsNullOrWhiteSpace(cliente.Direccion))
                throw new ArgumentException("La direccion del cliente es obligatorio. ");
            if (cliente.Nombre.Length > 100)
                throw new ArgumentException("El nombre no puede tener más de 100 caracteres.");
            if (cliente.Correo.Length > 100)
                throw new ArgumentException("El correo no puede tener más de 100 caracteres.");
            if (cliente.Telefono.Length > 20)
                throw new ArgumentException("El telefono no puede tener más de 20 caracteres.");
            if (cliente.Direccion.Length > 200)
                throw new ArgumentException("La direccion no puede tener más de 200 caracteres.");
        }
        public static void EsElCorreoValido(string correo)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(correo);
            }
            catch
            {
                throw new ArgumentException("El correo no tiene un formato válido.");
            }
        }
        public static void SonLosDatosDelDestinoValidos(Destino destino)
        {
            if (string.IsNullOrWhiteSpace(destino.Pais))
                throw new ArgumentException("El Pais es obligatorio.");
            if (string.IsNullOrWhiteSpace(destino.Ciudad))
                throw new ArgumentException("El destino es obligatorio.");
            if (string.IsNullOrWhiteSpace(destino.Descripcion))
                throw new ArgumentException("La descripcion es obligatorio. ");
            if (destino.Pais.Length > 100)
                throw new ArgumentException("El pais no puede tener más de 100 caracteres.");
            if (destino.Ciudad.Length > 100)
                throw new ArgumentException("La ciudad no puede tener más de 100 caracteres.");
            if (destino.Descripcion.Length > 2000)
                throw new ArgumentException("La descripcion no puede tener mas de 2000 caracters.");

 
        }
        public static void SonLosDatosDeTransporteValidos(Transporte transporte)
        {
            if (string.IsNullOrWhiteSpace(transporte.Tipo))
                throw new ArgumentException("El tipo es obligatorio.");
            if (string.IsNullOrWhiteSpace(transporte.Compania))
                throw new ArgumentException("La compania es obligatoria. ");
            if (transporte.Tipo.Length > 50)
                throw new ArgumentException("El tipo no puede tener más de 50 caracteres.");
            if (transporte.Compania.Length > 100)
                throw new ArgumentException("La compania no puede tener más de 100 caracteres.");


        }
        public static void SonLosDatosDeReservaValidos(Reserva reserva)
        {
            if (reserva.IdCliente <= 0)
                throw new ArgumentException("ID de cliente inválido.");

            if (reserva.IdDestino <= 0)
                throw new ArgumentException("ID de destino inválido.");

            if (reserva.IdTransporte <= 0)
                throw new ArgumentException("ID de transporte inválido.");

            if (reserva.CantidadPersonas <= 0)
                throw new ArgumentException("La cantidad de personas debe ser mayor a 0.");

            if (reserva.FechaReserva < DateTime.Today)
                throw new ArgumentException("La fecha de reserva no puede ser en el pasado.");
        }
    }
}
