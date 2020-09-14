using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_SWT.Helpers
{
    public class AuthJwtTokenOptions
    {
        public const string Issuer = "SomeIssuesName";

        public const string Audience = "https://localhost:44358/api/";

        private const string Key = "supersecret_secretkey!12345";

        public static SecurityKey GetSecurityKey() =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));

    }
}
