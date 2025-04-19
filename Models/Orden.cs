using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Proyect_Restaurante.Models;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyect_Restaurante.AbstractClass;


namespace Proyect_Restaurante.Models
{
    public class Orden: EntityBase
    {

        [Required]
        public int MesaID { get; set; }

        [Required]
        public DateTime Date {  get; set; }

        [Required]
        public decimal Total {  get; set; }

        [Required]
        [MaxLength(60)]
        public string State { get; set; }

        [ForeignKey("MesaID")]
        public Mesa Mesa { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }


        public Orden() { } 

        public Orden(int mesaId, DateTime date, decimal total, string state, string description )
        {
            MesaID = mesaId;
            Date = date;
            Total = total;
            State = state;
            Description = description;

        }

    }
}
