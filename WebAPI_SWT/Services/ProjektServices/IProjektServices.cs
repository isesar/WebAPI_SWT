using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.KorisnikServices
{
    public interface IProjektServices
    {
        bool SaveChanges();
        IEnumerable<Projekt> GetAll();
        Projekt GetProjektById(int id);
        void CreateProject(Projekt project);
        void UpdateProjekt(Projekt project);
        void DeleteProjekt(Projekt project);
    }
}
