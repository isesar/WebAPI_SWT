using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.FakultetServices
{
    public interface IFakultet
    {

        bool SaveChanges();
        IEnumerable<Fakultet> GetAll();
        Fakultet GetFakultetById(int id);
        void CreateFakultet(Fakultet fax);
        void UpdateFakultet(Fakultet fax);
        void DeleteFakultet(Fakultet fax);
    }
}
