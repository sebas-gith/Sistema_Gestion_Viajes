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
        

        while (true)
        {
            int opcion = MenuView.MostrarOpcionesDeMenu();
            switch (opcion)
            {
                case 1:
                       ClienteView.MostrarVista();
                       break;
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
                        DestinoView.MostrarVista();
                        break;
                    }
                case 5: 
                    {
                        return;
                        break; 
                    }
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