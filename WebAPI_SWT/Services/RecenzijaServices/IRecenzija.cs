using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.RecenzijaServices
{
    public interface IRecenzija
    {
        bool SaveChanges();
        IEnumerable<Recenzija> GetAll();
        Recenzija GetRecenzijaById(int id);
        void CreateRecenzija (Recenzija rec);
        void UpdateRecenzija(Recenzija rec);
        void DeleteRecenzija(Recenzija rec);
    }
}
