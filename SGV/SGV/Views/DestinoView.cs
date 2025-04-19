using SGV.Entities;
using SGV.Interfaces;
using SGV.Repositories;
using SGV.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGV.Views
{
    public class DestinoView
    {
        public static int MostrarOpcionesDelDestino()
        {
            int opcion;
            MenuView.MostrarLogo("Administrar_Destino");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar por Id");
            Console.WriteLine("3. Obtener todos los Destinos");
            Console.WriteLine("4. Actualizar Destino");
            Console.WriteLine("5. Eliminar Destino");
            Console.WriteLine("6. Salir");
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
        public static Destino MostrarInsertarDestino()
        {
            string ciudad, pais, descripcion;
            decimal precio_base;
            Console.WriteLine("Ciudad: ");
            ciudad = Console.ReadLine();
            Console.WriteLine("Pais: ");
            pais = Console.ReadLine();
            Console.WriteLine("Descripcion: ");
            descripcion = Console.ReadLine();
            Console.WriteLine("Precio base: ");
            try
            {
                precio_base = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception ex) {
                throw new ArgumentException("El campo Precio Base debe de ser de tipo numero");
            }
            

            return new Destino
            {
                Ciudad = ciudad,
                Pais = pais,
                Descripcion = descripcion,
                PrecioBase = precio_base
            };

        }
        public static void MostrarDestinoBuscado(Destino destino)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Pais[/]");
            tabla.AddColumn("[blue]Ciudad[/]");
            tabla.AddColumn("[cyan]Descripcion[/]");
            tabla.AddColumn("[red]Precio Base[/]");

            tabla.AddRow(
                   destino.IdDestino.ToString(),
                   destino.Pais,
                   destino.Ciudad,
                   destino.Descripcion,
                   destino.PrecioBase.ToString()
               );
            AnsiConsole.Write(tabla);
        }
        public static void MostrarMasDeUnDestino(List<Destino> destinoList)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Pais[/]");
            tabla.AddColumn("[blue]Ciudad[/]");
            tabla.AddColumn("[cyan]Descripcion[/]");
            tabla.AddColumn("[red]Precio Base[/]");

            foreach (var destino in destinoList)
            {
                tabla.AddRow(
                   destino.IdDestino.ToString(),
                   destino.Pais,
                   destino.Ciudad,
                   destino.Descripcion,
                   destino.PrecioBase.ToString()
               );
            }

            AnsiConsole.Write(tabla);
        }
        public static int MostrarBuscarPorId()
        {
            int opcion;
            try
            {
                Console.Write("Ingresa el id del destino: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Debe ingresar una opcion valida");
            }

            return opcion;
        }
        public static void MostrarVista()
        {
            IDestinoRepository destinoRepository = new DestinoRepository();
            IDestinoService destinoService = new DestinoService(destinoRepository);

            while (true)
            {
                Console.Clear();
                int opcionesDestino = MostrarOpcionesDelDestino();
                if (opcionesDestino == 1)
                {
                    try
                    {
                        Destino destino = MostrarInsertarDestino();
                        destinoService.Insertar(destino);
                        Console.WriteLine("Destino Ingresado exitosamente :)");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (opcionesDestino == 2)
                {
                    try
                    {

                        MostrarDestinoBuscado(destinoService.BuscarPorId(MostrarBuscarPorId()));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (opcionesDestino == 3)
                {
                    MostrarMasDeUnDestino(destinoService.ObtenerTodos());
                }
                else if (opcionesDestino == 4)
                {
                    //Actualizar cliente
                    try
                    {

                        int Id = MostrarBuscarPorId();
                        Console.WriteLine("Antiguos datos: ");
                        MostrarDestinoBuscado(destinoService.BuscarPorId(Id));
                        var destino = MostrarInsertarDestino();
                        destinoService.Actualizar(Id, destino);
                        Console.WriteLine("Datos actualizados exitosamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                 }
                else if (opcionesDestino == 5)
                {
                    //Eliminar cliente
                    try
                    {

                        int Id = MostrarBuscarPorId();
                        Console.WriteLine("Datos a eliminar: ");
                        MostrarDestinoBuscado(destinoService.BuscarPorId(Id));
                        destinoService.Eliminar(Id);
                        Console.WriteLine("Datos Eliminados exitosamente");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else if (opcionesDestino == 6)
                {
                    break;
                }
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}
