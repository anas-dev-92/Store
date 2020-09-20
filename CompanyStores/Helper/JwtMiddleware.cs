using DrugStore.Services.AdminsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore.Helper
{
    //في هذا الكلاس يتم التأكدهل هناك توكن في الريكوست اذا وجد يعمل 
    //صلاحية للتوكن....يستخرج اليوزر ......يوصل اليوزر الى httpcontext-item حتى يتم التعامل معه
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApSetting _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<ApSetting> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IAdminsRepository adminRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, adminRepository, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IAdminsRepository adminRepository, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var adminId = int.Parse(jwtToken.Claims.First(x => x.Type == "AdminId").Value);

                // attach user to context on successful jwt validation
                context.Items["admin"] = adminRepository.GetById(adminId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
