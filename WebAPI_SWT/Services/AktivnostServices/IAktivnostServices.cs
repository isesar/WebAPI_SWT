using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.AktivnostServices
{
    public interface IAktivnostServices
    {
        bool SaveChanges();
        IEnumerable<Aktivnost> GetAll();
        Aktivnost GetAktivnostbyId(int id);
        void CreateAktivnost(Aktivnost activity);
        void UpdateAktivnost (Aktivnost activity);
        void DeleteAktivnost(Aktivnost activity);

    }
}
