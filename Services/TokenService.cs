using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace moontest1.Services
{
    // responsible for generating JWT tokens.
    public class TokenService
    {
        // field holds the symmetric key used to sign the JWT.
        private readonly SymmetricSecurityKey _signingKey;

        // Constructor accepts a secret string and converts it into a symmetric key.
            // our secret key is in program.cs
        public TokenService(string secretKey)
        {
            // The secret key must be at least 32 characters long for HmacSha256 to work.
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }
        // This method creates and returns a JWT as a string.
        public string CreateToken(string username, string roleName)
        {
            var claims = new[]
            {
                // 'sub' (subject) claim — username/userId 
                new Claim(JwtRegisteredClaimNames.Sub, username),
                
                // Role claim — lets you do role-based auth
                new Claim(ClaimTypes.Role, roleName),
                
                // 'jti' (JWT ID) — a unique identifier for the token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Create the signing credentials using the key and the HMAC SHA256 algorithm.
            var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

            // Create the actual JWT token object with metadata and claims.
            var token = new JwtSecurityToken(
               issuer: "https://localhost:7027",       // Who issued the token
                audience: "https://localhost:7027",     // Who the token is intended for 
                claims: claims,                         // Embed the user claims into the token
                expires: DateTime.UtcNow.AddMinutes(30), // Token is valid for 30 minutes
                signingCredentials: creds                // Sign the token with the credentials
            );

            // Convert the JwtSecurityToken object to a string that can be returned to the client.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}