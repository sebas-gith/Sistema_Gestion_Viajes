using SGV.Entities;
using SGV.Interfaces;
using SGV.Repositories;
using SGV.Services;
using SGV.Views;
using System;
using System.Linq.Expressions;
class Program
{
    public static void Main(string[] args)
    {
        IClienteRespository clienteRepository = new ClienteRespository();
        IClienteService clienteService = new ClienteService(clienteRepository);

        while (true)
        {
            int opcion = MenuView.MostrarOpcionesDeMenu();
            switch (opcion)
            {
                case 1:
                    {
                        while (true)
                        {
                            Console.Clear();
                            int opcionesCliente = ClienteView.MostrarOpcionesDelCliente();
                            if (opcionesCliente == 1)
                            {
                                try
                                {
                                    Cliente cliente = ClienteView.MostrarInsertarCliente();
                                    clienteService.Insertar(cliente);
                                    Console.WriteLine("Cliente Ingresado exitosamente :)");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                            }else if(opcionesCliente == 2)
                            {
                                try
                                {
                                    string correo = ClienteView.MostrarBuscarPorCorreo();
                                    ClienteView.MostrarClienteBuscado(clienteService.BuscarPorCorreo(correo));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                            }
                            else if (opcionesCliente == 3) {
                                try
                                {

                                    ClienteView.MostrarClienteBuscado(clienteService.BuscarPorId(ClienteView.MostrarBuscarPorId()));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (opcionesCliente == 4)
                            {
                                ClienteView.MostrarMasDeUnCliente(clienteService.ObtenerTodos());
                            }else if(opcionesCliente == 5)
                            {
                                //Actualizar cliente
                                try
                                {

                                    int Id = ClienteView.MostrarBuscarPorId();
                                    Console.WriteLine("Antiguos datos: ");
                                    ClienteView.MostrarClienteBuscado(clienteService.BuscarPorId(Id));
                                    var cliente = ClienteView.MostrarInsertarCliente();
                                    clienteService.Actualizar(Id, cliente);
                                    Console.WriteLine("Datos actualizados exitosamente");
                                }
                                catch (Exception ex) {
                                    Console.WriteLine(ex.Message);
                                }
                                
                                
                            }else if(opcionesCliente == 6)
                            {
                                //Eliminar cliente
                                try
                                {

                                    int Id = ClienteView.MostrarBuscarPorId();
                                    Console.WriteLine("Datos a eliminar: ");
                                    ClienteView.MostrarClienteBuscado(clienteService.BuscarPorId(Id));
                                    clienteService.Eliminar(Id);
                                    Console.WriteLine("Datos Eliminados exitosamente");
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex); 
                                }
                            }
                            else if (opcionesCliente == 7)
                            {
                                break;
                            }
                            Console.WriteLine("Presione cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        
                            break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5: {
                        return;
                        break; }
                case -129:
                    {
                        Console.WriteLine("Por favor ingrese una opcion valida");
                        break;
                    }
            }
            Console.WriteLine("Presiona cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();

        }
    }
}