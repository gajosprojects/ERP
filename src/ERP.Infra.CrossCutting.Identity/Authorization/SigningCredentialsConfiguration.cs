using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ERP.Infra.CrossCutting.Identity.Authorization
{
    public class SigningCredentialsConfiguration
    {
        public SigningCredentials SigningCredentials { get; }
        public readonly IConfiguration _configuration;

        public SigningCredentialsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AUTHORIZATION_SECRET_KEY"])), SecurityAlgorithms.HmacSha256);
        }
    }
}
