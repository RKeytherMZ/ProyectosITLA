using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proyect_Restaurante.DataContext;
using Proyect_Restaurante.Models;
using Proyect_Restaurante.TableView;

namespace Proyect_Restaurante.Controllers
{
    public class OrdenController
    {
        private readonly RestauranteContext _context;

        public OrdenController(RestauranteContext context)
        {
            _context = context;
        }



        public void AddOrder()
        {
            try
            {

                Console.Write("ID de la mesa: ");
                int mesaId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Total a pagar: ");
                decimal total = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Estado de la orden (ej: pendiente, pagada): ");
                string estado = Console.ReadLine();

                Console.WriteLine("Descripcion de la orden: ");
                string? descripcion = Console.ReadLine();


                Orden newOrder = new Orden
                {
                    MesaID = mesaId,
                    Date = DateTime.Now,
                    Total = total,
                    State = estado,
                    Description = descripcion
                };

                _context.Ordens.Add(newOrder);
                _context.SaveChanges();

                Console.WriteLine("===========================================");
                Console.WriteLine("        ORDEN REGISTRADA CORRECTAMENTE     ");
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
                Console.WriteLine("Error de formato. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error inesperado:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
            }
        }








        public void ShowOrder()
        {
            var orders = _context.Ordens.ToList();
            TableHelpers.ShowOrdenesTable(_context.Ordens.ToList());

        }

        




        public void ModifyOrder(int id)
        {
            var order = _context.Ordens.Find(id);

            if (order == null)
            {
                Console.WriteLine("Orden no encontrado.");
                return;
            }

            ShowOrder();

            Console.Write("Nuevo ID de mesa (dejar vacío para no cambiar): ");
            string nuevaMesa = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaMesa))
                order.MesaID = Convert.ToInt32(nuevaMesa);

            Console.Write("Nuevo total (dejar vacío para no cambiar): ");
            string nuevoTotal = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoTotal))
                order.Total = Convert.ToDecimal(nuevoTotal);

            Console.Write("Nuevo estado (dejar vacío para no cambiar): ");
            string nuevoEstado = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoEstado))
                order.State = nuevoEstado;

            Console.Write("Nueva descripción (dejar vacío para no cambiar): ");
            string nuevaDescripcion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDescripcion))
                order.Description = nuevaDescripcion;

            _context.SaveChanges();
            Console.WriteLine("Orden actualizada correctamente.");
        }





        public void DeliteOrder(int id)
        {
            ShowOrder();

            var order = _context.Ordens.Find(id);

            if (order == null)
            {
                Console.WriteLine("Orden no encontrado.");
                return;
            }          

            _context.Ordens.Remove(order);
            _context.SaveChanges();

            Console.WriteLine("Orden eliminada correctamente.");

        }

    }

}

  

