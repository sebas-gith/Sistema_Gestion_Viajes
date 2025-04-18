using SGV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace SGV.Views
{
    public class ClienteView
    {
        public static int MostrarOpcionesDelCliente()
        {
            int opcion;   
            MenuView.MostrarLogo("Administrar_Clientes");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar por correo");
            Console.WriteLine("3. Buscar por Id");
            Console.WriteLine("4. Obtener todos los clientes");
            Console.WriteLine("5. Actualizar cliente");
            Console.WriteLine("6. Eliminar cliente");
            Console.WriteLine("7. Salir");
            Console.Write("¿Que deseas hacer? ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("No te pases de listo :<");
                opcion = -129;
            }

            return opcion;
        }
        public static Cliente MostrarInsertarCliente()
        {
            string nombre, correo, telefono, direccion;
            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Correo: ");
            correo = Console.ReadLine();
            Console.WriteLine("Telefono: ");
            telefono = Console.ReadLine();
            Console.WriteLine("Direccion: ");
            direccion = Console.ReadLine();

            return new Cliente
            {
                Nombre = nombre,
                Correo = correo,
                Telefono = telefono,
                Direccion = direccion
            };

        }
        public static void MostrarClienteBuscado(Cliente cliente)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Nombre[/]");
            tabla.AddColumn("[blue]Correo[/]");
            tabla.AddColumn("[cyan]Teléfono[/]");
            tabla.AddColumn("[red]Direccion[/]");

            tabla.AddRow(
                   cliente.IdCliente.ToString(),
                   cliente.Nombre,
                   cliente.Correo,
                   cliente.Telefono,
                   cliente.Direccion
               );
            AnsiConsole.Write(tabla);
        }
        public static void MostrarMasDeUnCliente(List<Cliente> clienteList) {
            var tabla = new Table();

            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Nombre[/]");
            tabla.AddColumn("[blue]Correo[/]");
            tabla.AddColumn("[cyan]Teléfono[/]");
            tabla.AddColumn("[red]Direccion[/]");

            foreach (var c in clienteList)
            {
                tabla.AddRow(
                    c.IdCliente.ToString(),
                    c.Nombre,
                    c.Correo,
                    c.Telefono,
                    c.Direccion
                );
            }

            AnsiConsole.Write(tabla);
        }
        public static int MostrarBuscarPorId()
        {
            int opcion;
            try
            {
                Console.Write("Ingresa el id del usuario: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }catch(Exception ex)
            {
                throw new ArgumentException("Debe ingresar una opcion valida");
            }

            return opcion;
        }
        public static string MostrarBuscarPorCorreo()
        {
            string correo;
            Console.Write("Ingrese el correo del cliente: ");
            correo = Console.ReadLine();

            return correo;
        }


    }
}
