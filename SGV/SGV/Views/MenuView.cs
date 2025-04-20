using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Views
{
    public class MenuView
    {
        public static void MostrarLogo(string vista)
        {
            int width = Console.WindowWidth;

            Console.CursorLeft = width/2-20;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Viaja Facil SVG--{vista}\n\n");
            Console.ForegroundColor= ConsoleColor.White;

        }
        public static int MostrarOpcionesDeMenu()
        {
            MostrarLogo("Menu principal");
            int opcion = 0;
            Console.WriteLine("1. Administrar clientes");
            Console.WriteLine("2. Administrar transportes");
            Console.WriteLine("3. Administrar Reservas");
            Console.WriteLine("4. Administrar Desitnos");
            Console.WriteLine("5. Salir");
            Console.Write("¿Que quieres hacer hoy? ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ingresa una opcion valida:<");
                opcion = -129;
            }
            

            return opcion;
        }
    }
}
