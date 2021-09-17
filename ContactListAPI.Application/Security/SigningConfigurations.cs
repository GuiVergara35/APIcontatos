using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ContactListAPI.Application.Security
{
    public class SigningConfigurations
    {
        private const string SECRET_KEY = "c1f51f42-5727-2r68-b787-c6bcdc645025";
        public SigningCredentials SigningCredentials { get; }
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public SigningConfigurations()
        {
            SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256); ;
        }
    }
}
