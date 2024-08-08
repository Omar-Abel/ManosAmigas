using ManosAmigas_Back.Models.Common;
using ManosAmigas_Back.Models;
using ManosAmigas_Back.Models.Request;
using ManosAmigas_Back.Models.Response;
using ManosAmigas_Back.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ManosAmigas_Back.Data;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponse> AuthUser(UserAuthRequest model)
        {
            UserResponse uReponse = new UserResponse();
            using (var db = new ManosAmigasDbContext())
            {
                string spassword = Encrypt.GetSHA256(model.password);

                var user = await db.Users.FirstOrDefaultAsync(x => x.Email == model.email
                && x.Password == spassword);

                if (user == null)
                {
                    return null;
                }

                uReponse.id = user.Id;
                uReponse.firstName = user.FirstName;
                uReponse.lastName = user.LastName;
                uReponse.email = user.Email;
                uReponse.accountType = user.AccountType;
                uReponse.token = GenerateToken(user);
            }

            return uReponse;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Email.ToString())
                    ]
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest model)
        {
            UserRegisterResponse uResponse = new UserRegisterResponse();

            using (var db = new ManosAmigasDbContext())
            {
                if (await db.Users.AnyAsync(x => x.Email == model.email))
                {
                    uResponse.email = model.email;
                    return null;
                }
                
                uResponse.email = model.email;

                var user = new User
                {
                    FirstName = model.firstName,
                    LastName = model.lastName,
                    Email = model.email,
                    Password = Encrypt.GetSHA256(model.password),
                    AccountType = model.accountType
                };


                db.Users.Add(user);
                await db.SaveChangesAsync();

                return uResponse;

            }

        }
    }
}
