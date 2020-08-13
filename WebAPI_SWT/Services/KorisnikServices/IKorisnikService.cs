using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.KorisnikServices
{
    public interface IKorisnikService
    {
        bool SaveChanges();
        IEnumerable<Korisnik> GetAll();
        Korisnik GetKorisnikById(int id);
        void CreateKorisnik(Korisnik user);
        void UpdateKorisnik(Korisnik user);
        void DeleteKorisnik(Korisnik user);
    }
}
