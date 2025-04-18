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
    }
}
