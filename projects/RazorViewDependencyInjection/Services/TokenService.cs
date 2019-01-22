using RazorViewDependencyInjection.Contracts;

namespace RazorViewDependencyInjection.Services
{
    public class TokenService : ITokenService
    {
        public string ApiToken => "Fake Token";
    }
}
