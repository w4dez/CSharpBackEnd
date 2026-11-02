namespace Game.ServiceLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Game.DataAccessLayer;
using GameDomain;

public class AuthService
{       private readonly IConfiguration _configuration;

    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

private string GenerateJwtToken(UserDto user)
{
    JwtSecurityTokenHandler tokenHandler = new 
        JwtSecurityTokenHandler();

    byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

    Claim[] claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, 
            user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

    SecurityTokenDescriptor tokenDescriptor = new 
        SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(2),
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"],
        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        )
    };

    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}


    public GameDomain.LoginResponseDto? Login(LoginRequestDto loginRequest)
{ 
    // 1. Find user in the database
    // NOTE: In a real application, a password comparison would also 
     //  take place here!
    UserDto? user = _userRepository.GetByEmail(loginRequest.Email);

    if (user == null)
        return null; // User not found

    // 2. Generate token
    string token = GenerateJwtToken(user);
    return new LoginResponseDto { Token = token };
}

}
