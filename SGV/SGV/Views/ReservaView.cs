using SGV.Entities;
using SGV.Interfaces;
using SGV.Repositories;
using SGV.Repositories.SGV.Repositories;
using SGV.Services;
using Spectre.Console;
using System;
using System.Collections.Generic;

namespace SGV.Views
{
    public class ReservaView
    {
        public static int MostrarOpcionesDeReserva()
        {
            int opcion;
            MenuView.MostrarLogo("Administrar_Reserva");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar por Id");
            Console.WriteLine("3. Obtener todas las Reservas");
            Console.WriteLine("4. Actualizar Reserva");
            Console.WriteLine("5. Eliminar Reserva");
            Console.WriteLine("6. Salir");
            Console.Write("¿Qué deseas hacer? ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Opción inválida.");
                opcion = -1;
            }

            return opcion;
        }

        public static Reserva MostrarInsertarReserva()
        {
            int idCliente, idDestino, idTransporte, cantidadPersonas;
            DateTime fechaReserva;

            Console.Write("ID Cliente: ");
            idCliente = Convert.ToInt32(Console.ReadLine());

            Console.Write("ID Destino: ");
            idDestino = Convert.ToInt32(Console.ReadLine());

            Console.Write("ID Transporte: ");
            idTransporte = Convert.ToInt32(Console.ReadLine());

            Console.Write("Fecha de Reserva (yyyy-mm-dd): ");
            fechaReserva = DateTime.Parse(Console.ReadLine());

            Console.Write("Cantidad de Personas: ");
            cantidadPersonas = Convert.ToInt32(Console.ReadLine());

            return new Reserva
            {
                IdCliente = idCliente,
                IdDestino = idDestino,
                IdTransporte = idTransporte,
                FechaReserva = fechaReserva,
                CantidadPersonas = cantidadPersonas
            };
        }

        public static void MostrarReservaBuscada(Reserva reserva)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Cliente[/]");
            tabla.AddColumn("[red]Destino[/]");
            tabla.AddColumn("[blue]Transporte[/]");
            tabla.AddColumn("[cyan]Fecha[/]");
            tabla.AddColumn("[pink]Personas[/]");
            tabla.AddColumn("[yellow]Total[/]");

            tabla.AddRow(
                reserva.IdReserva.ToString(),
                reserva.IdCliente.ToString(),
                reserva.IdDestino.ToString(),
                reserva.IdTransporte.ToString(),
                reserva.FechaReserva.ToShortDateString(),
                reserva.CantidadPersonas.ToString(),
                reserva.Total.ToString("0.00")
            );

            AnsiConsole.Write(tabla);
        }

        public static void MostrarMasDeUnaReserva(List<Reserva> reservas)
        {
            var tabla = new Table();
            tabla.Border(TableBorder.Rounded);
            tabla.AddColumn("[yellow]ID[/]");
            tabla.AddColumn("[green]Cliente[/]");
            tabla.AddColumn("[red]Destino[/]");
            tabla.AddColumn("[blue]Transporte[/]");
            tabla.AddColumn("[cyan]Fecha[/]");
            tabla.AddColumn("[red]Personas[/]");
            tabla.AddColumn("[yellow]Total[/]");

            foreach (var reserva in reservas)
            {
                tabla.AddRow(
                    reserva.IdReserva.ToString(),
                    reserva.IdCliente.ToString(),
                    reserva.IdDestino.ToString(),
                    reserva.IdTransporte.ToString(),
                    reserva.FechaReserva.ToShortDateString(),
                    reserva.CantidadPersonas.ToString(),
                    reserva.Total.ToString("0.00")
                );
            }

            AnsiConsole.Write(tabla);
        }

        public static int MostrarBuscarPorId()
        {
            Console.Write("Ingresa el ID de la reserva: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void MostrarVista()
        {
            IReservaRepository reservaRepository = new ReservaRepository();
            IReservaService reservaService = new ReservaService(reservaRepository);

            while (true)
            {
                Console.Clear();
                int opcion = MostrarOpcionesDeReserva();

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            var nuevaReserva = MostrarInsertarReserva();
                            reservaService.Insertar(nuevaReserva);
                            Console.WriteLine("Reserva insertada exitosamente.");
                            break;
                        case 2:
                            var idBusqueda = MostrarBuscarPorId();
                            var reservaBuscada = reservaService.BuscarPorId(idBusqueda);
                            MostrarReservaBuscada(reservaBuscada);
                            break;
                        case 3:
                            var reservas = reservaService.ObtenerTodos();
                            MostrarMasDeUnaReserva(reservas);
                            break;
                        case 4:
                            var idActualizar = MostrarBuscarPorId();
                            var antigua = reservaService.BuscarPorId(idActualizar);
                            Console.WriteLine("Reserva actual:");
                            MostrarReservaBuscada(antigua);
                            var actualizada = MostrarInsertarReserva();
                            reservaService.Actualizar(idActualizar, actualizada);
                            Console.WriteLine("Reserva actualizada.");
                            break;
                        case 5:
                            var idEliminar = MostrarBuscarPorId();
                            reservaService.Eliminar(idEliminar);
                            Console.WriteLine("Reserva eliminada.");
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
