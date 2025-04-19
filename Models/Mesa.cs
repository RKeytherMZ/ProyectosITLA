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
    public class Mesa: EntityBase
    {


        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public int Capacity { get; set; }  

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public Mesa() {}

        public Mesa(string number, string state, int capacity, string location)
        { 
            Number = number;
            State = state;
            Capacity = capacity;
            Location = location;

        }
    }
}
