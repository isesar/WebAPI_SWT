using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.KorisnikServices;

namespace WebAPI_SWT.Services.ProjektServices
{
    public class ProjektServices : IProjektServices
    {
        private readonly STTPContext _context;

        public ProjektServices(STTPContext context)
        {
            _context = context;
        }
        public void CreateProject(Projekt project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }
            _context.Projekt.Add(project);
        }

        public void DeleteProjekt(Projekt project)
        {
            if(project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }
            _context.Projekt.Remove(project);
        }

        public IEnumerable<Projekt> GetAll()
        {
            return _context.Projekt.Include(i => i.FkFirmaNavigation).ThenInclude(x=>x.Korisnik).ThenInclude(i=>i.Zadatak).ToList();
        }

        public Projekt GetProjektById(int id)
        {
            return _context.Projekt.Include(i => i.FkFirmaNavigation)
                                   .FirstOrDefault(p => p.ProjektId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProjekt(Projekt project)
        {
           //gfdkd
        }
    }
}
