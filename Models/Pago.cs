using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyect_Restaurante.Models;



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyect_Restaurante.AbstractClass;



namespace Proyect_Restaurante.Models
{
    public class Pago: EntityBase
    {


        [Required]
        public int OrdenID { get; set; }

        [Required]
        public DateTime DatePay {  get; set; }

        [Required]
        [MaxLength(100)]
        public string MethodPay { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [ForeignKey("OrdenID")]
        public Orden Orden {  get; set; }

        public Pago() {}

        public Pago(int ordenID, DateTime datepay, string methodPay, decimal amount)
        {
            OrdenID = ordenID;
            DatePay = datepay;
            MethodPay = methodPay;
            Amount = amount;

        }

    }
}
