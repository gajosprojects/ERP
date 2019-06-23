using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ERP.Infra.CrossCutting.Identity.Authorization
{
    public class SigningCredentialsConfiguration
    {
        private const string SecretKey = "ZjM5ZhGJr1F2zu90GcZoNWXMBczTU6UfV8ums7SWmXjBK0RduZwBXCH5JxCDrMaNz9B6wLdVIOaNOl5tdKfHIhtcbNyl8pMmFD50nRW3.ERP-Gajos-Projects;ZO1ainsSfJUyGcXj2fEhZZeQiYcVfjE7P4exZbQP9Md7KTMnJbV92p65qwucrf9KfLFooXW9AVhrLPjmxmfNK5Jfqpqxg6GRke20Bj8mfv";
        public static readonly SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}
