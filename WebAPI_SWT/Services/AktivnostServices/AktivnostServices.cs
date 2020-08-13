using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.AktivnostServices;

namespace WebAPI_SWT.Services.AktivnostDTO
{
    public class AktivnostServices : IAktivnostServices
    {
        private readonly STTPContext _context;

        public AktivnostServices(STTPContext context)
        {
            _context = context;

        }
        public void CreateAktivnost(Aktivnost activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }
            _context.Aktivnost.Add(activity);
        }

        public void DeleteAktivnost(Aktivnost activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }
            _context.Aktivnost.Remove(activity);
        }

        public Aktivnost GetAktivnostbyId(int id)
        {
            return _context.Aktivnost.Include(i => i.FkKorisnikNavigation)
                                     .FirstOrDefault(p => p.AktivnostId == id);
        }

        public IEnumerable<Aktivnost> GetAll()
        {
            return _context.Aktivnost.Include(i => i.FkKorisnikNavigation).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAktivnost(Aktivnost activity)
        {
                //naattiing
        }
    }


}

