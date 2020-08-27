using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.KorisnikServices
{
    public class KorisnikRepo :IKorisnikService
    {
        private readonly STTPContext _context;
     

        public KorisnikRepo(STTPContext context)
        {
            _context = context;
         
        }

        public void CreateKorisnik(Korisnik user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Korisnik.Add(user);
        }

        public void DeleteKorisnik(Korisnik user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Korisnik.Remove(user);
        }

        public IEnumerable<Korisnik> GetAll()
        {
            return _context.Korisnik.Include(i => i.FakultetNavigation)
                                    .Include(i=>i.FirmaNavigation)
                                    .Include(i=>i.ProjektNavigation)
                                    .Include(i=>i.UlogaNavigation)
                                    .ToList();
        }

        public Korisnik GetKorisnikById(int id)
        {
            return _context.Korisnik.Include(i => i.FakultetNavigation)
                                    .Include(i => i.FirmaNavigation)
                                    .Include(i => i.ProjektNavigation)
                                    .Include(i => i.UlogaNavigation)
                                    .FirstOrDefault(p => p.KorisnikId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateKorisnik(Korisnik user)
        {
            //nothing
        }
    }

}
