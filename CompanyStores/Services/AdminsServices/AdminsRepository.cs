using DrugStore.Entities;
using DrugStore.Helper;
using DrugStore.Model.AdminModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore.Services.AdminsServices
{
    public class AdminsRepository:IAdminsRepository
    {
        private readonly ApSetting _appSettings;
        private readonly DrugDbContext _dbcontext;

        public AdminsRepository(IOptions<ApSetting> appSettings, DrugDbContext dbcontext)
        {
            _appSettings = appSettings.Value;
            _dbcontext = dbcontext;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var admin = _dbcontext.Admins.SingleOrDefault(a => a.UserName == model.UserName && a.Password == model.Password);

            // return null if user not found
            if (admin == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(admin);

            return new AuthenticateResponse(admin, token);
        }
        public Admin Create(Admin admin, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_dbcontext.Admins.Any(x => x.UserName == admin.UserName))
                throw new AppException("Username \"" + admin.UserName + "\" is already taken");
            _dbcontext.Admins.Add(admin);
            _dbcontext.SaveChanges();

            return admin;
        }
        public void Update(Admin adminParam, string password = null)
        {
            var admin = _dbcontext.Admins.Find(adminParam.AdminId);

            if (admin == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(adminParam.UserName) && adminParam.UserName != admin.UserName)
            {
                // throw error if the new username is already taken
                if (_dbcontext.Admins.Any(x => x.UserName == adminParam.UserName))
                    throw new AppException("Username " + adminParam.UserName + " is already taken");

                admin.UserName = adminParam.UserName;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(adminParam.Password))
                admin.Password = adminParam.Password;
            _dbcontext.Admins.Update(admin);
            _dbcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            var admin = _dbcontext.Admins.Find(id);
            if (admin != null)
            {
                _dbcontext.Admins.Remove(admin);
                _dbcontext.SaveChanges();
            }
        }
        public IEnumerable<Admin> GetAll()
        {
            return _dbcontext.Admins.ToList();
        }

        public Admin GetById(int id)
        {
            return _dbcontext.Admins.FirstOrDefault(x => x.AdminId == id);
        }

        // helper methods

        private string generateJwtToken(Admin admin)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { new Claim("AdminId", admin.AdminId.ToString()),
                  new Claim("UserName",admin.UserName),
                  new Claim("Password",admin.Password),
                  new Claim("CompanyId",admin.CompanyStoresId.ToString()),
                  new Claim("RollId",admin.Roll.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _dbcontext.SaveChangesAsync() > 0);
        }

        public void Create(Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException(nameof(admin));
            }
            _dbcontext.Admins.Add(admin);
        }

        public void Update(Admin admin, int Id)
        {
            throw new NotImplementedException();
        }

        //private string ExeToke( )
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    string authHeader = Request.Headers["Authorization"];
        //    authHeader = authHeader.Replace("Bearer ", "");
        //    var jsonToken = handler.ReadToken(authHeader);
        //    var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

        //    var id = tokenS.Claims.First(claim => claim.Type == "nameid").Value;
        //}
    }
}
