using SGV.Entities;
using SGV.Interfaces;
using SGV.Repositories;
using SGV.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;

namespace SGV.Views
{
    public class TransporteView
    {
        public static int MostrarOpcionesDeTransporte()
        {
            MenuView.MostrarLogo("Administrar_Transporte");

            Console.WriteLine("1. Insertar Transporte");
            Console.WriteLine("2. Buscar Transporte por ID");
            Console.WriteLine("3. Mostrar Todos los Transportes");
            Console.WriteLine("4. Actualizar Transporte");
            Console.WriteLine("5. Eliminar Transporte");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Opción inválida.");
                return -1;
            }
        }

        public static Transporte MostrarInsertarTransporte()
        {
            Console.Write("Tipo de transporte: ");
            string tipo = Console.ReadLine();

            Console.Write("Compañía: ");
            string compania = Console.ReadLine();

            Console.Write("Capacidad: ");
            int capacidad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Precio unitario: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine());

            return new Transporte
            {
                Tipo = tipo,
                Compania = compania,
                Capacidad = capacidad,
                Precio_unitario = precio
            };
        }

        public static void MostrarTransporteBuscado(Transporte transporte)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Tipo[/]");
            tabla.AddColumn("[red]Compañia[/]");
            tabla.AddColumn("[blue]Capacidad[/]");
            tabla.AddColumn("[cyan]Precio Unitario[/]");
            tabla.AddRow(
                transporte.TransporteId.ToString(),
                transporte.Tipo,
                transporte.Compania,
                transporte.Capacidad.ToString(),
                transporte.Precio_unitario.ToString("0.00")
            );

            AnsiConsole.Write(tabla);
        }

        public static void MostrarListaDeTransportes(List<Transporte> transportes)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Tipo[/]");
            tabla.AddColumn("[red]Compañia[/]");
            tabla.AddColumn("[blue]Capacidad[/]");
            tabla.AddColumn("[cyan]Precio Unitario[/]");
            foreach (var t in transportes)
            {
                tabla.AddRow(
                    t.TransporteId.ToString(),
                    t.Tipo,
                    t.Compania,
                    t.Capacidad.ToString(),
                    t.Precio_unitario.ToString("0.00")
                );
            }

            AnsiConsole.Write(tabla);
        }

        public static int PedirId()
        {
            Console.Write("Ingresa el ID del transporte: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void MostrarVista()
        {
            ITransporteRepository transporteRepository = new TransporteRepository();
            ITransporteService transporteService = new TransporteService(transporteRepository);

            while (true)
            {
                Console.Clear();
                int opcion = MostrarOpcionesDeTransporte();

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            var nuevo = MostrarInsertarTransporte();
                            transporteService.Insertar(nuevo);
                            Console.WriteLine("Transporte insertado correctamente.");
                            break;
                        case 2:
                            var idBuscar = PedirId();
                            var encontrado = transporteService.BuscarPorId(idBuscar);
                            MostrarTransporteBuscado(encontrado);
                            break;
                        case 3:
                            var lista = transporteService.ObtenerTodos();
                            MostrarListaDeTransportes(lista);
                            break;
                        case 4:
                            var idActualizar = PedirId();
                            var actualizar = MostrarInsertarTransporte();
                            transporteService.Actualizar(idActualizar, actualizar);
                            Console.WriteLine("Transporte actualizado.");
                            break;
                        case 5:
                            var idEliminar = PedirId();
                            transporteService.Eliminar(idEliminar);
                            Console.WriteLine("Transporte eliminado.");
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
