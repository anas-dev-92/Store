using DrugStore.Entities;
using DrugStore.Model.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.AdminsServices
{
    public interface IAdminsRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        Admin Create(Admin admin, string password);
        void Update(Admin admin, string password = null);
        void Delete(int id);
        Task<bool> SaveChanges();
    }
}
