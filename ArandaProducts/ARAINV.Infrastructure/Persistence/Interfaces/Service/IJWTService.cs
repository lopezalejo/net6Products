using ARAINV.Infrastructure.DTOs.Users;

namespace ARAINV.Infrastructure.Persistence.Interfaces.Service
{
    public interface IJWTService
    {
        public string GenerarToken(UserDTO user);
    }
}
