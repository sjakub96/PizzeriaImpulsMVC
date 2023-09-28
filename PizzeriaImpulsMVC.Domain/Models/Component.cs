using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class Component
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsMeat { get; set; }

        public ICollection<ComponentPizza>? ComponentPizzas { get; set; }
    }
}
