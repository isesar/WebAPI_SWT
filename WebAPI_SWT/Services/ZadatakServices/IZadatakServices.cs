using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.ZadatakServices
{
  public  interface IZadatakServices
    {
        bool SaveChanges();
        IEnumerable<Zadatak> GetAll();
        Zadatak GetZadatakById(int id);
        void CreateZadatak(Zadatak zad);
        void UpdateZadatak(Zadatak zad);
        void DeleteZadatak(Zadatak zad);
    }
}
