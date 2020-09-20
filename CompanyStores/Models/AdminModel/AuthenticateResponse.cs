using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.AdminModel
{
    public class AuthenticateResponse
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Roll { get; set; }
        public int CompanyStoresId { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(Admin admin,string token)
        {
            AdminId = admin.AdminId;
            UserName = admin.UserName;
            Password = admin.Password;
            Roll = admin.Roll;
            CompanyStoresId = admin.CompanyStoresId;
            Token = token;
        }
    }
}
