using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Infrastructure.Repositories
{
    public class AdditionRepository : IAdditionRepository
    {
        private readonly Context _context;

        public AdditionRepository(Context context)
        {
            _context = context;
        }

        public int AddAddition(Addition addition)
        {
            _context.Additions.Add(addition);
            _context.SaveChanges();

            return addition.Id;
        }

        public void DeleteAddition(int additionId)
        {
            var addition = _context.Additions.Find(additionId);

            if(addition != null)
            {
                _context.Additions.Remove(addition);
                _context.SaveChanges();
            }
        }

        public IQueryable<Addition> GetAllAdditions()
        {
            var additions = _context.Additions;

            return additions;

        }
    }
}
