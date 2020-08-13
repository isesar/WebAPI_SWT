using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.RecenzijaServices
{
    public class RecenzijaServices : IRecenzija
    {
        private readonly STTPContext _context;

        public RecenzijaServices(STTPContext context)
        {
            _context = context;
        }
        public void CreateRecenzija(Recenzija rec)
        {
            if (rec == null)
            {
                throw new ArgumentNullException(nameof(rec));
            }
            _context.Recenzija.Add(rec);

        }

        public void DeleteRecenzija(Recenzija rec)
        {
            if (rec == null)
            {
                throw new ArgumentNullException(nameof(rec));
            }
            _context.Recenzija.Remove(rec);
        }

        public IEnumerable<Recenzija> GetAll()
        {
            return _context.Recenzija.Include(i => i.FkKorisnikNavigation).Include(i=>i.Aktivnost).ToList();
        }

        public Recenzija GetRecenzijaById(int id)
        {
            return _context.Recenzija.Include(i => i.FkKorisnikNavigation).Include(i => i.Aktivnost)
                                       .FirstOrDefault(p => p.RecenzijaId == id);

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRecenzija(Recenzija rec)
        {
           //nothing
        }
    }
}
