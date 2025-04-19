using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.EntityFrameworkCore;
using Proyect_Restaurante.DataContext;
using Proyect_Restaurante.Models;
using Proyect_Restaurante.TableView;

namespace Proyect_Restaurante.Controllers
{
    public class PagoController
    {

        private readonly RestauranteContext _context;

        public PagoController(RestauranteContext context) 
        {
            _context = context;
        }

        public void AddPay()
        {
            try
            {

                Console.WriteLine("ID de la orden: ");
                int ordenId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Fecha de la orden (ej: 2025-04-16): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                {
                    Console.WriteLine(" Fecha inválida.");
                    return;
                }

                Console.WriteLine("Metodo de pago: (Tarjeta, Efectivo, Transferencia)");
                string metodo = Console.ReadLine();

                Console.WriteLine("Monto total: ");
                decimal monto = Convert.ToDecimal(Console.ReadLine());

                var orden = _context.Ordens.Find(ordenId);

                if (orden == null)
                {
                    Console.WriteLine("La orden con ese ID no existe. No se puede registrar el pago.");
                    return;
                }

                Pago newPay = new Pago
                {
                    OrdenID = ordenId,
                    DatePay = DateTime.Now,               
                    MethodPay = metodo,
                    Amount = monto
                };

                _context.Pagos.Add(newPay);
                _context.SaveChanges();

                Console.WriteLine("===========================================");
                Console.WriteLine("        PAGO REGISTRADO CORRECTAMENTE      ");
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





        public void ShowPay() 
        {
            var pays = _context.Pagos.ToList();

            TableHelpers.ShowPagosTable(_context.Pagos.ToList());

        }





        public void ModifyPay(int id)
        {
            var pay = _context.Pagos.Find(id);

            if (pay == null)
            {
                Console.WriteLine("Pago no encontrado.");
                return;
            }

            ShowPay();

            Console.WriteLine("nuevo ID de la orden: (dejar vacío para no cambiar) ");
            string nuevaOrdenId = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaOrdenId))
                pay.OrdenID = Convert.ToInt32(nuevaOrdenId);

            Console.Write("Nueva fecha de la orden (ej: 2025-04-16) (dejar vacío para no cambiar): ");
            string nuevaFechaStr = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nuevaFechaStr))
            {
                if (DateTime.TryParse(nuevaFechaStr, out DateTime nuevaFecha))
                {
                    pay.DatePay = nuevaFecha;
                }
                else
                {
                    Console.WriteLine(" Fecha inválida.");
                    return;
                }
            }


            Console.WriteLine("nuevo metodo de pago: (dejar vacío para no cambiar)");
            string nuevoMetodo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoMetodo))
                pay.MethodPay = nuevoMetodo;

            Console.WriteLine("nuevo monto total: dejar vacío para no cambiar) ");
            string nuevoMonto = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoMonto))
                pay.Amount = Convert.ToDecimal(nuevoMonto);



        }






        public void DelitePay(int id)
        {

            ShowPay();

            var pay = _context.Pagos.Find(id);

            if (pay == null)
            {
                Console.WriteLine("Pago no encontrado.");
                return;
            }

            _context.Pagos.Remove(pay);
            _context.SaveChanges();

            Console.WriteLine("Pago eliminado correctamente.");

        }

    }

}
