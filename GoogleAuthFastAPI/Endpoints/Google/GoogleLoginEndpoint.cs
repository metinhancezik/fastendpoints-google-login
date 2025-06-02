using FastEndpoints;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

namespace GoogleAuthFastAPI.Endpoints.Google
{
    public class GoogleLoginEndpoint : EndpointWithoutRequest<object>
    {
        public override void Configure()    //Endpoint noktası
        {                                   //Burada oluşturduğumuz endpointe istek geldiğinde google signin gelecek.
            Get("/api/auth/google-login");
            AllowAnonymous();
        }

        public override async Task<object> ExecuteAsync(CancellationToken ct)
        {
            var props = new AuthenticationProperties    //Login işleminden sonra hangi URL'e yönleneceğimizi seçtik
            {
                RedirectUri = "/auth/callback"
            };

            
            var challengeResult = Results.Challenge(props, new[] { GoogleDefaults.AuthenticationScheme });

            
            await challengeResult.ExecuteAsync(HttpContext);

            return new { }; // Buraya uğramıyor zaten
        }
    }
}