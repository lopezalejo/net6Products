using ARAINV.Infrastructure.Wrappers;
using MediatR;

namespace ARAINV.Infrastructure.DTOs.Users
{
    public class UserDTO : IRequest<ApiResponse<UserDTO>>
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
        public Boolean? deleted { get; set; }

    }
}
