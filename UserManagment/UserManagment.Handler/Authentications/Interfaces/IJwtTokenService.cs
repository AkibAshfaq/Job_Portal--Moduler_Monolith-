using UserManagment.AggregateRoot.Entities;
using UserManagment.DTO.DTO;

namespace UserManagment.Handler.Authentications.Interfaces
{
    public interface IJwtTokenService
    {
        string GetJwtToken(AuthenticatedUser user);
    }
}
