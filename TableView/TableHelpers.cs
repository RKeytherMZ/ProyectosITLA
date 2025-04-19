using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Proyect_Restaurante.Models;


namespace Proyect_Restaurante.TableView
{
    public static class TableHelpers
    {
      public static void ShowMenusTable(List<Menu> menus)
        {
            var table = new Table();
            table.Border = TableBorder.Rounded;

            table.AddColumn("ID");
        table.AddColumn("Nombre");
        table.AddColumn("Precio");
        table.AddColumn("Descripción");
        table.AddColumn("Categoría");

        foreach (var menu in menus)
        {
            table.AddRow(
                menu.Id.ToString(),
                menu.Name,
                $"[green]RD${menu.Price:0.00}[/]",
                menu.Description,
                menu.Category
            );
        }

    AnsiConsole.Write(table);
    }

        public static void ShowMesasTable(List<Mesa> mesas)
        {
            var table = new Table();

            table.Border = TableBorder.Rounded;
            table.AddColumn("ID");
            table.AddColumn("Número");
            table.AddColumn("Capacidad");
            table.AddColumn("Estado");

            foreach (var mesa in mesas)
            {
                table.AddRow(
                    mesa.Id.ToString(),
                    mesa.Number.ToString(),
                    mesa.Capacity.ToString(),
                    mesa.State.ToString().ToLower() == "disponible" ? "[green]Disponible[/]" : "[red]Ocupada[/]"
                );
            }

            AnsiConsole.Write(table);
        }


        public static void ShowOrdenesTable(List<Orden> ordenes)
        {
            var table = new Table();

            table.Border = TableBorder.Rounded;
            table.AddColumn("[cyan]ID[/]");
            table.AddColumn("[cyan]Mesa ID[/]");
            table.AddColumn("[cyan]Fecha[/]");
            table.AddColumn("[cyan]Total[/]");

            foreach (var orden in ordenes)
            {
                table.AddRow(
                    orden.Id.ToString(),
                    orden.MesaID.ToString(),
                    orden.Date.ToString("dd/MM/yyyy HH:mm"),
                    orden.Total.ToString("C")
                );
            }

            AnsiConsole.Write(table);
        }

        public static void ShowPagosTable(List<Pago> pagos)
        {
            var table = new Table();

            table.Border = TableBorder.Rounded;
            table.AddColumn("[green]ID[/]");
            table.AddColumn("[green]Orden ID[/]");
            table.AddColumn("[green]Fecha de Pago[/]");
            table.AddColumn("[green]Método de Pago[/]");
            table.AddColumn("[green]Monto[/]");

            foreach (var pago in pagos)
            {
                table.AddRow(
                    pago.Id.ToString(),
                    pago.OrdenID.ToString(),
                    pago.DatePay.ToString("dd/MM/yyyy HH:mm"),
                    pago.MethodPay,
                    pago.Amount.ToString("C")
                );
            }

            AnsiConsole.Write(table);
        }



    }
}
