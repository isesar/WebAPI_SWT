using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.FirmaServices
{
    public class FirmaService : IFirmaService
    {
        private readonly STTPContext _context;

        public FirmaService(STTPContext context)
        {
            _context = context;
        }
        public void CreateFirma(Firma firma)
        {
            if (firma == null)
            {
                throw new ArgumentNullException(nameof(firma));
            }
            _context.Firma.Add(firma);

        }

        public void DeleteFirma(Firma firma)
        {
            if (firma == null)
            {
                throw new ArgumentNullException(nameof(firma));
            }
            _context.Firma.Remove(firma);

        }

        public IEnumerable<Firma> GetAll()
        {
            return _context.Firma.Include(i => i.FkMjestoNavigation).ToList();

        }

        public Firma GetFirmaById(int id)
        {
            return _context.Firma.Include(i => i.FkMjestoNavigation)
                                    .FirstOrDefault(p => p.FirmaId == id);

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFirma(Firma firma)
        {
            //nothing
        }
    }
}
