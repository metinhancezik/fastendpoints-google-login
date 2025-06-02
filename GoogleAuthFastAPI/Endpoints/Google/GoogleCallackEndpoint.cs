using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoogleAuthFastAPI.Endpoints.Google
{
    public class GoogleCallbackEndpoint : EndpointWithoutRequest
    {
        private readonly IConfiguration _config;

        public GoogleCallbackEndpoint(IConfiguration config)
        {
            _config = config;
        }

        public override void Configure()
        {
            Get("/auth/callback");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)    // Burada işlem sonrasında bilgiler geliyor.
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                await SendAsync(new { error = "Login failed" }, 400, ct);
                return;
            }

            var email = result.Principal?.FindFirstValue(ClaimTypes.Email); //Google'dan gelen email, name bilgisi
            var name = result.Principal?.FindFirstValue(ClaimTypes.Name);

            // JWT üretiyoruz
            var token = GenerateToken(email!, name ?? "");

            await SendAsync(new { token, email, name }, 200, ct);
        }

        private string GenerateToken(string email, string name)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Name, name),
            new Claim("email", email)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Authentication:Jwt:Issuer"],
                audience: _config["Authentication:Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
