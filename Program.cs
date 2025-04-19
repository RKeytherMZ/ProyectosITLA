using System;
using Proyect_Restaurante.Controllers;
using Proyect_Restaurante.DataContext;
using Proyect_Restaurante.SubMenus;
using Microsoft.EntityFrameworkCore;
using Proyect_Restaurante.Models;
using Spectre.Console;


class Program
{
    static void Main(string[] args)
    {

        var context = new RestauranteContext(); 

        var menuController = new MenuController(context);
        var mesaController = new MesaController(context);
        var ordenController = new OrdenController(context);
        var pagoController = new PagoController(context);


        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("     SISTEMA DE GESTIÓN DEL RESTAURANTE    ");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Menú");
            Console.WriteLine("2. Mesa");
            Console.WriteLine("3. Orden");
            Console.WriteLine("4. Pago");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Digite el número de la opción deseada:");


            try
            {
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        SubMenusControllers.SubmenuMenu(menuController);
                        break;
                    case 2:
                        SubMenusControllers.SubmenuMesa(mesaController);
                        break;
                    case 3:
                        SubMenusControllers.SubmenuOrder(ordenController);
                        break;
                    case 4:
                        SubMenusControllers.SubmenuPay(pagoController);
                        break;
                    
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número válido.");
                Console.ReadKey();
            }           
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                Console.ReadKey();
            }

        }

    }
}



