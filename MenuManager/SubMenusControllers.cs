using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyect_Restaurante.Controllers;
using Proyect_Restaurante.Models;
using Proyect_Restaurante.TableView;
using Spectre.Console;



namespace Proyect_Restaurante.SubMenus
{
    public class SubMenusControllers
    {
        public static void SubmenuMenu(MenuController controlador)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE MENÚS");
                Console.WriteLine("1. Agregar nuevo menú");
                Console.WriteLine("2. Mostrar todos los menús");
                Console.WriteLine("3. Modificar un menú");
                Console.WriteLine("4. Eliminar un menú");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        controlador.AddMenu();
                        break;
                    case "2":
                        controlador.ShowMenus();
                        break;
                    case "3":
                        Console.Write("Ingresa el ID del menú a modificar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEdit))
                            controlador.ModifyMenu(idEdit);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "4":
                        Console.Write("Ingresa el ID del menú a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idDelite))
                            controlador.DeliteMenu(idDelite);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "5":
                        return; 
                    default:
                        Console.WriteLine(" Opción no válida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }



        public static void SubmenuMesa(MesaController controlador)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE MESAS");
                Console.WriteLine("1. Agregar nueva mesa");
                Console.WriteLine("2. Mostrar todas los mesas");
                Console.WriteLine("3. Modificar una mesa");
                Console.WriteLine("4. Eliminar una mesa");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        controlador.AddTable();
                        break;
                    case "2":
                        controlador.ShowTable();
                        break;
                    case "3":
                        Console.Write("Ingresa el ID de la mesa a modificar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEdit))
                            controlador.ModifyTable(idEdit);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "4":
                        Console.Write("Ingresa el ID de la mesa a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idDelite))
                            controlador.DeliteTable(idDelite);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine(" Opción no válida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }


        }

        public static void SubmenuOrder(OrdenController controlador)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE ORDENES");
                Console.WriteLine("1. Agregar nueva orden");
                Console.WriteLine("2. Mostrar todas las ordenes");
                Console.WriteLine("3. Modificar una orden");
                Console.WriteLine("4. Eliminar una orden");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        controlador.AddOrder();
                        break;
                    case "2":
                        controlador.ShowOrder();
                        break;
                    case "3":
                        Console.Write("Ingresa el ID de la Orden a modificar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEdit))
                            controlador.ModifyOrder(idEdit);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "4":
                        Console.Write("Ingresa el ID de la Orden a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idDelite))
                            controlador.DeliteOrder(idDelite);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine(" Opción no válida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }


        }


        public static void SubmenuPay(PagoController controlador)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE PAGOS");
                Console.WriteLine("1. Agregar nuevo pago");
                Console.WriteLine("2. Mostrar todos los pagos");
                Console.WriteLine("3. Modificar un pago");
                Console.WriteLine("4. Eliminar un pago");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        controlador.AddPay();
                        break;
                    case "2":
                        controlador.ShowPay();
                        break;
                    case "3":
                        Console.Write("Ingresa el ID del pago a modificar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEdit))
                            controlador.ModifyPay(idEdit);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "4":
                        Console.Write("Ingresa el ID del pago a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idDelite))
                            controlador.DelitePay(idDelite);
                        else
                            Console.WriteLine(" ID inválido.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine(" Opción no válida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }


        }






    }



}