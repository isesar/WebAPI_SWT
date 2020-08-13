using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.ZadatakServices
{
    public class ZadatakServices : IZadatakServices
    {
        private readonly STTPContext _context;

        public ZadatakServices(STTPContext context)
        {
            _context = context;
        }
        public void CreateZadatak(Zadatak zad)
        {
            if (zad == null)
            {
                throw new ArgumentNullException(nameof(zad));
            }
            _context.Zadatak.Add(zad);
        }

        public void DeleteZadatak(Zadatak zad)
        {
            if (zad == null)
            {
                throw new ArgumentNullException(nameof(zad));
            }
            _context.Zadatak.Remove(zad);
        }

        public IEnumerable<Zadatak> GetAll()
        {
            return _context.Zadatak.Include(i => i.KorisnikId).ToList();

        }

        public Zadatak GetZadatakById(int id)
        {
            return _context.Zadatak.Include(i => i.KorisnikId)
                                    .FirstOrDefault(p => p.ZadatakId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateZadatak(Zadatak zad)
        {
          //naating
        }
    }
}
