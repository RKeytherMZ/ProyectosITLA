using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyect_Restaurante.DataContext;
using Proyect_Restaurante.Models;
using Proyect_Restaurante.TableView;
using Spectre.Console;


namespace Proyect_Restaurante.Controllers
{
    public class MenuController
    {
        private readonly RestauranteContext _context;

        public MenuController(RestauranteContext context)
        {
            _context = context;
        }

        public void AddMenu()
        {
            try
            {
                Console.Write("Nombre del plato: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                decimal precio = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();

                Console.Write("Categoría: ");
                string categoria = Console.ReadLine();


                Menu newMenu = new Menu
                {
                    Name = nombre,
                    Price = precio,
                    Description = descripcion,
                    Category = categoria
                };

                _context.Menus.Add(newMenu);
                _context.SaveChanges();

                Console.WriteLine("===========================================");
                Console.WriteLine("        MENU AGREGADO CORRECTAMENTE        ");
                Console.WriteLine("===========================================");
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine(" Error al guardar en la base de datos:");
                Console.WriteLine(dbEx.Message);
                Console.WriteLine(dbEx.InnerException?.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato. Asegúrate de ingresar un número válido en el precio.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error inesperado:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
            }
        }

       
        public void ShowMenus()
        {
            var menus = _context.Menus.ToList();
            TableHelpers.ShowMenusTable(_context.Menus.ToList());

        }
       
        public void ModifyMenu(int id)
        {
            ShowMenus();
           
            var menu = _context.Menus.Find(id);

            if (menu == null)
            {
                Console.WriteLine(" Menú no encontrado.");
                return;
            }

            Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) menu.Name = nombre;

            Console.Write("Nuevo precio (dejar vacío para no cambiar): ");
            string precioStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(precioStr)) menu.Price = Convert.ToDecimal(precioStr);

            Console.Write("Nueva descripción (dejar vacío para no cambiar): ");
            string descripcion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(descripcion)) menu.Description = descripcion;

            _context.SaveChanges();
            Console.WriteLine(" Menú actualizado correctamente.");
        }

        
        public void DeliteMenu(int id)
        {
            ShowMenus();
          
            var menu = _context.Menus.Find(id);

            if (menu == null)
            {
                Console.WriteLine(" Menú no encontrado.");
                return;
            }

            _context.Menus.Remove(menu);
            _context.SaveChanges();

            Console.WriteLine(" Menú eliminado correctamente.");

        }
    }

}

    

