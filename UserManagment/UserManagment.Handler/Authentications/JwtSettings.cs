using UserManagment.Handler.Authentications.Interfaces;

namespace UserManagment.Handler.Authentications
{
    public class JwtSettings : IJwtSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public string ExpirationDate { get; set; }
    }
}
