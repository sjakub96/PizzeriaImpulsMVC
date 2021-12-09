using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsMeat { get; set; }
        public string FirstComponent { get; set; }
        public string SecondComponent { get; set; }
        public string ThirdComponent { get; set; }
        public string FourthComponent { get; set; }
        public string FifthComponent { get; set; }
        public string SixthComponent { get; set; }
        public string SeventhComponent { get; set; }
        public string EighthComponent { get; set; }
        public string NinthComponent { get; set; }
        public string TenthComponent { get; set; }

        public ICollection<Component> Components { get; set; }
        public ICollection<PizzaSize> PizzaSizes { get; set; }
    }
}
