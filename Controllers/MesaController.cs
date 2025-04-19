using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proyect_Restaurante.DataContext;
using Proyect_Restaurante.Models;
using Proyect_Restaurante.TableView;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyect_Restaurante.Controllers
{
    public class MesaController
    {
        private readonly RestauranteContext _context;

        public MesaController(RestauranteContext context)
        {
            _context = context;
        }

      

        public void AddTable()
        {
            try
            {
                Console.WriteLine("Numero de mesa: ");
                string numero = Console.ReadLine();

                Console.WriteLine("Estado de la mesa: ");
                string estado = Console.ReadLine();

                Console.WriteLine("Capacidad de la mesa: ");
                int capacidad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ubicacion de la mesa: ");
                string ubicacion = Console.ReadLine();

                Mesa newTable = new Mesa
                {
                    Number = numero,
                    State = estado,
                    Capacity = capacidad,
                    Location = ubicacion
                };

                _context.Mesas.Add(newTable);
                _context.SaveChanges();

                Console.WriteLine("===========================================");
                Console.WriteLine("        MESA AGREGADA CORRECTAMENTE        ");
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

      
        public void ShowTable() {
            var tables = _context.Mesas.ToList();
            TableHelpers.ShowMesasTable(_context.Mesas.ToList());

        }

        

        public void ModifyTable(int id)
        {
            ShowTable();
          
            var table = _context.Mesas.Find(id);

            if (table == null)
            {
                Console.WriteLine(" Mesa no encontrado.");
                return;
            }

            Console.Write("Nuevo número de mesa (dejar vacío para no cambiar): ");
            string numero = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(numero)) table.Number = numero;

            Console.Write("Nueva capacidad (dejar vacío para no cambiar): ");
            string capacidadStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(capacidadStr)) table.Capacity = Convert.ToInt32(capacidadStr);

            Console.Write("Nueva ubicación (dejar vacío para no cambiar): ");
            string ubicacion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ubicacion)) table.Location = ubicacion;

            _context.SaveChanges();
            Console.WriteLine(" Mesa actualizada correctamente.");

        }

      

        public void DeliteTable(int id)
        {
            ShowTable();
         
            var table = _context.Mesas.Find(id);

            if (table == null)
            {
                Console.WriteLine("Mesa no encontrada");
                return;
            }

            _context.Mesas.Remove(table);
            _context.SaveChanges();

            Console.WriteLine(" Mesa eliminado correctamente.");

        }


    }
}
