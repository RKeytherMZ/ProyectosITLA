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
    public class Menu: EntityBase
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public decimal Price {  get; set; }

        [Required]
        [MaxLength(250)]
        public string Category { get; set; }
 
        public Menu() {}

        public Menu(string name, string description, decimal price, string category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            
        }

    }
}
