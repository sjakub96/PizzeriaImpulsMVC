using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public int UserPrice { get; set; }

        [Required]
        public int ComponentsPrice { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        [Required]
        public bool IsMeat { get; set; }

        [MaxLength(50)]
        public string? ImgPath { get; set; }

        public ICollection<ComponentPizza>? ComponentPizzas { get; set; }
    }
}

//Dodać imgpath przy pobieraniu obiektu i wrzucić go do tagu img w widoku
//Dodać dodawanie obrazka przy tworzeniu obiektu
