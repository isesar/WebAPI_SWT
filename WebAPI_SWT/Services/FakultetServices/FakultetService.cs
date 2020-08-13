using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.FakultetServices
{
    public class FakultetService : IFakultet
    {
        private readonly STTPContext _context;

        public FakultetService(STTPContext context)
        {
            _context = context;
        }
        public void CreateFakultet(Fakultet fax)
        {
            if (fax == null)
            {
                throw new ArgumentNullException(nameof(fax));
            }
            _context.Fakultet.Add(fax);
        }

            public void DeleteFakultet(Fakultet fax)
        {
            if (fax == null)
            {
                throw new ArgumentNullException(nameof(fax));
            }
            _context.Fakultet.Remove(fax);
        }

        public IEnumerable<Fakultet> GetAll()
        {
            return _context.Fakultet.Include(i => i.FkMjestoNavigation).ToList();
        }

        public Fakultet GetFakultetById(int id)
        {
            return _context.Fakultet.Include(i => i.FkMjestoNavigation)
                                    .FirstOrDefault(p => p.FakultetId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFakultet(Fakultet fax)
        {
           //nothing
        }
    }
}
