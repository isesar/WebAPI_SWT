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
        Korisnik Authenticate(string username, string password);
        IEnumerable<Korisnik> GetAll();
        Korisnik GetKorisnikById(int id);
        void CreateKorisnik(Korisnik user, string password);
        void UpdateKorisnik(Korisnik userParam,string password);
        void DeleteKorisnik(Korisnik user);
    }
}
