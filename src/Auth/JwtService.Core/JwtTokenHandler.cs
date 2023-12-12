using JwtService.API.Models;
using JwtService.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtService.Core;

public class JwtTokenHandler
{
    public const string JWT_SECURITY_KEY = "UltraSecret7870ANIMEKEY";
    public const int JWT_TOKEN_VALIDITY_MINS = 10;

    private readonly List<UserAccount> _userAccountList;

    public JwtTokenHandler()
    {
        _userAccountList = new List<UserAccount>
        {
            new UserAccount { UserName = "admin", Password = "admin123", Role = "Administrator" },
            new UserAccount { UserName = "user01", Password = "user01", Role = "User" },
        };
    }

    public AuthenticationResponse? GenereteToken(AuthenticationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            return null;

        /* Validation */
        var userAccount = _userAccountList
            .Where(x => x.UserName == request.UserName
            && x.Password == request.Password)
            .FirstOrDefault();

        if (userAccount == null) return null;

        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, request.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            UserName = request.UserName,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds,
            Token = token
        };
    }
}

