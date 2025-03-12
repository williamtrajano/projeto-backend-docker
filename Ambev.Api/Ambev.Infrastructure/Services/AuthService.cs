using Ambev.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using Ambev.Domain.Entities;
using Ambev.Domain.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ambev.Infrastructure.Shared;
using Microsoft.Extensions.Configuration;

namespace Ambev.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IAdminRepository _adminRepository;
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;

    public AuthService(IAdminRepository adminRepository, IConfiguration configuration)
    {
        _adminRepository = adminRepository;
        _key = configuration["Jwt:Key"];
        _issuer = configuration["Jwt:Issuer"];
        _audience = configuration["Jwt:Audience"];
    }

    public async Task<string> Authenticate(string email, string password)
    {
        var passwordHash = HashHelper.StringToHash(password);
        var admin = await _adminRepository.GetByEmailAsync(email);

        if (admin == null || admin.PasswordHash != passwordHash)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, admin.Id.ToString()),
            new Claim(ClaimTypes.Email, admin.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _issuer,  // 🔹 Pegando do appsettings.json
            Audience = _audience, // 🔹 Pegando do appsettings.json
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}